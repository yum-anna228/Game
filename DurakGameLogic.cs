using Microsoft.EntityFrameworkCore;

namespace Game
{
    public class DurakGameLogic
    {
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
        }

        /// <summary>
        /// перемешивает колоду
        /// </summary>
        private void ShuffleDeck()
        {
            var random = new Random();
            _deck = _deck.OrderBy(c => random.Next()).ToList();
        }

        /// <summary>
        /// Раздаёт по 6 карт каждому игроку в начале игры
        /// </summary>
        public void DealCards()
        {
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
                }
            }

            _db.SaveChanges();
        }

        /// <summary>
        /// Выполняет атакующий ход: создаёт запись о ходе и устанавливает карту как использованную
        /// </summary>
        public async Task MakeAttackAsync(Guid playerInGameId, Card card)
        {
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
        }

        /// <summary>
        /// Выполняет защитный ход: проверяет возможность отбить атаку и сохраняет карту защиты
        /// </summary>
        public async Task MakeDefenceAsync(Guid defenderId, Card defendCard, Card attackCard)
        {
            if (!CanBeat(attackCard, defendCard))
            {
                MessageBox.Show("Этой картой отбить нельзя");
                return;
            }

            defendCard.TurnId = attackCard.TurnId;
            defendCard.PlayerInGameId = defenderId;

            _db.Cards.Update(defendCard);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Проверяет, может ли одна карта побить другую согласно правилам игры "Дурак"
        /// </summary>
        public bool CanBeat(Card attackCard, Card defendCard)
        {
            // Если масти одинаковые — сравниваем по значению
            if (defendCard.Suit == attackCard.Suit && GetRankValue(defendCard.Rank) > GetRankValue(attackCard.Rank))
                return true;

            // Если карта отбивающего — козырная, а атакующая — нет
            if (defendCard.Suit == _trumpSuit && attackCard.Suit != _trumpSuit)
                return true;

            return false;
        }

        /// <summary>
        /// Возвращает числовое значение ранга карты для сравнения
        /// </summary>
        private int GetRankValue(string rank)
        {
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

        public void NewRound()
        {

        }
    }
}