using Microsoft.EntityFrameworkCore;
using NLog;

namespace Game
{
    public class DurakGameLogic
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly GameDbContext _db;
        private readonly Guid _gameSessionId;
        private List<Card> _deck = new();
        private readonly string _trumpSuit;

        private static readonly Dictionary<string, int> RankValues = new()
        {
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "T", 10 },
            { "J", 11 },
            { "Q", 12 },
            { "K", 13 },
            { "A", 14 }
        };

        public DurakGameLogic(GameDbContext db, Guid gameSessionId)
        {
            _db = db;
            _gameSessionId = gameSessionId;

            var session = db.GameSessions.Find(gameSessionId);
            if (session == null)
                throw new ArgumentException("Сессия не найдена");

            _trumpSuit = session.TrumpSuit;
            InitializeDeck();
            ShuffleDeck();
            DealCards();
        }

        private void InitializeDeck()
        {
            logger.Trace("Инициализация новой колоды");
            var suits = new[] { "♠", "♥", "♦", "♣" };
            var ranks = new[] { "6", "7", "8", "9", "T", "J", "Q", "K", "A" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    _deck.Add(new Card
                    {
                        Id = Guid.NewGuid(),
                        Suit = suit,
                        Rank = rank,
                        IsTrump = suit == _trumpSuit,
                        GameSessionId = _gameSessionId,
                        TurnId = null
                    });
                }
            }

            logger.Debug($"Создана колода из {_deck.Count} карт");
        }

        /// <summary>
        /// перемешивает колоду
        /// </summary>
        private void ShuffleDeck()
        {
            logger.Debug("Перемешивание колоды...");
            var random = new Random();
            _deck = _deck.OrderBy(c => random.Next()).ToList();

            logger.Info("Колода успешно перемешана");
        }

        /// <summary>
        /// Раздаёт по 6 карт каждому игроку в начале игры
        /// </summary>
        public  void DealCards()
        {
            logger.Debug("Раздача карт игрокам...");
            var players = _db.PlayerInGames
        .Where(p => p.GameSessionId == _gameSessionId)
        .ToList();

            int cardsPerPlayer = 6;

            for (int i = 0; i < players.Count; i++)
            {
                var player = players[i];

                // Берём 6 карт для игрока
                for (int j = 0; j < cardsPerPlayer; j++)
                {
                    if (_deck.Count == 0) break;

                    var card = _deck[0];
                    card.PlayerInGameId = player.Id;
                    card.TurnId = null;
                    _deck.RemoveAt(0);

                    _db.Cards.Add(card);
                };
            }

            _db.SaveChanges();
            logger.Info($"Карты успешно разданы для {players.Count} игроков");
        }

        /// <summary>
        /// Выполняет атакующий ход: создаёт запись о ходе и устанавливает карту как использованную
        /// </summary>
        public async Task MakeAttackAsync(Guid playerInGameId, Card card)
        {
            logger.Debug($"Игрок {playerInGameId} делает атаку картой {card.Suit}{card.Rank}");
            var turn = new Turn
            {
                Id = Guid.NewGuid(),
                GameSessionId = _gameSessionId,
                AttackerPlayerInGameId = playerInGameId,
                DefenderPlayerInGameId = GetNextPlayer(playerInGameId),
                Timestamp = DateTime.UtcNow
            };

            card.TurnId = turn.Id;
            card.PlayerInGameId = playerInGameId;

            await _db.Turns.AddAsync(turn);
            _db.Cards.Update(card);
            await _db.SaveChangesAsync();
            logger.Info($"Атака создана: {card.Suit}{card.Rank}, ход ID: {turn.Id}");
        }

        /// <summary>
        /// Выполняет защитный ход: проверяет возможность отбить атаку и сохраняет карту защиты
        /// </summary>
        public async Task MakeDefenceAsync(Guid defenderId, Card defendCard, Card attackCard)
        {
            if (!CanBeat(attackCard, defendCard))
            {
                logger.Warn("Карта не может отбить атаку");
                return;
            }

            defendCard.TurnId = attackCard.TurnId;
            defendCard.PlayerInGameId = defenderId;

            _db.Cards.Update(defendCard);
            await _db.SaveChangesAsync();
        }

        private string GetTrumpSuit()
        {
            var session = _db.GameSessions.Find(_gameSessionId);
            return session?.TrumpSuit;
        }

        /// <summary>
        /// Проверяет, может ли одна карта побить другую согласно правилам игры "Дурак"
        /// </summary>
        public bool CanBeat(Card attackCard, Card defendCard)
        {
            if (attackCard == null || defendCard == null)
            {
                logger.Warn("Не переданы карты для проверки");
                MessageBox.Show("Ошибка: Одна из карт не найдена");
                return false;
            }

            string trumpSuit = GetTrumpSuit();
            if (string.IsNullOrEmpty(trumpSuit))
            {
                logger.Error("Козырь не определён");
                MessageBox.Show("Ошибка: Козырь не задан");
                return false;
            }

            // Для логирования
            logger.Debug($"CanBeat: Атака={attackCard.Suit}{attackCard.Rank}, Защита={defendCard.Suit}{defendCard.Rank}, Козырь={trumpSuit}");

            // 1. Обе карты козырные → старшая побеждает
            if (defendCard.Suit == trumpSuit && attackCard.Suit == trumpSuit)
            {
                bool canBeat = GetRankValue(defendCard.Rank) > GetRankValue(attackCard.Rank);
                logger.Debug($"Сравнение козырей: {defendCard.Suit}{defendCard.Rank} против {attackCard.Suit}{attackCard.Rank} → {(canBeat ? "можно отбить" : "нельзя")}");
                return canBeat;
            }

            // 2. Защитная карта — козырь, атакующая — нет
            if (defendCard.Suit == trumpSuit && attackCard.Suit != trumpSuit)
            {
                logger.Trace("Козырная карта используется для защиты");
                return true;
            }

            // 3. Атакующая карта — козырь, защитная — нет
            if (attackCard.Suit == trumpSuit && defendCard.Suit != trumpSuit)
            {
                logger.Warn("Атакующая карта — козырная, защитная — нет");
                MessageBox.Show("❌ Нельзя отбивать не козырной картой козырную");
                return false;
            }

            // 4. Масти совпадают → сравниваем по старшинству
            if (defendCard.Suit == attackCard.Suit)
            {
                bool canBeat = GetRankValue(defendCard.Rank) > GetRankValue(attackCard.Rank);
                logger.Debug($"Сравнение мастей: {defendCard.Suit}{defendCard.Rank} против {attackCard.Suit}{attackCard.Rank} → {(canBeat ? "можно отбить" : "нельзя")}");
                return canBeat;
            }

            // 5. Разные масти, ни одна не козырь
            logger.Warn($"Невозможно отбить {attackCard.Suit}{attackCard.Rank} картой {defendCard.Suit}{defendCard.Rank}");
            MessageBox.Show("❌ Этой картой нельзя отбить - масти не совпадают и карта не козырь");
            return false;
        }

        /// <summary>
        /// Возвращает числовое значение ранга карты для сравнения
        /// </summary>
        private int GetRankValue(string rank)
        {
            logger.Trace($"Получено значение ранга для '{rank}'");
            return RankValues.TryGetValue(rank, out var value) ? value : 0;
        }

        /// <summary>
        /// Получает идентификатор следующего игрока по порядку
        /// </summary>
        private Guid GetNextPlayer(Guid currentId)
        {
            var players = _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .OrderBy(p => p.Position)
                .ToList();

            int index = players.FindIndex(p => p.Id == currentId);

            return players[(index + 1) % players.Count].Id;
        }

        /// <summary>
        ///  Возвращает список карт, находящихся на руках у указанного игрока и не участвующих в текущем ходе
        /// </summary>
        public List<Card> GetPlayerCards(Guid playerInGameId)
        {
            return _db.Cards
                .Where(c => c.PlayerInGameId == playerInGameId && c.TurnId == null)
                .ToList();
        }

        /// <summary>
        /// Завершает бой: все карты из текущего хода передаются обороняющемуся игроку
        /// </summary>
        public async Task EndBoutAsync(Guid defenderId)
        {
            logger.Warn("Вызван метод EndBoutAsync — все карты достаются обороняющемуся");
            var boutCards = await _db.Cards
                .Where(c => c.TurnId != null)
                .ToListAsync();

            foreach (var card in boutCards)
            {
                card.PlayerInGameId = defenderId;
                card.TurnId = null;
                _db.Cards.Update(card);
            }

            await _db.SaveChangesAsync();
        }

    }
}