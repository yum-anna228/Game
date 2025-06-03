using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Game
{
    public partial class GameTableFormFor2Players : Form
    {
        private System.Windows.Forms.Timer _uiUpdateTimer;
        private readonly GameDbContext _db;
        private Guid _gameSessionId;
        private Guid _playerInGameId;
        private readonly IServiceProvider _serviceProvider;
        private DurakGameLogic _gameLogic;
        private bool _deckFinished = false;


        public GameTableFormFor2Players(GameDbContext db, IServiceProvider serviceProvider)
        {
            if (db == null)
            {
                MessageBox.Show("Ошибка: База данных не инициализирована");
                return;
            }

            InitializeComponent(); // Теперь после проверки

            _serviceProvider = serviceProvider;
            _db = db;
            StartUIUpdateTimer();
            LoadPlayerCards();
            ShowTrump();
            UpdateStatus();
        }

        public void SetPlayerInGame(Guid sessionId, Guid playerInGameId)
        {
            _gameSessionId = sessionId;
            _playerInGameId = playerInGameId;

            var session = _db.GameSessions.Find(sessionId);
            if (session == null)
            {
                MessageBox.Show("Ошибка: Сессия не найдена");
                return;
            }

            _gameLogic = new DurakGameLogic(_db, _gameSessionId);
            _deckFinished = false;

            LoadPlayerCards();
            ShowTrump();
            UpdateStatus();
        }

        private void StartUIUpdateTimer()
        {
            _uiUpdateTimer = new System.Windows.Forms.Timer(); // Это System.Windows.Forms.Timer
            _uiUpdateTimer.Interval = 1000; // Интервал обновления UI в мс
            _uiUpdateTimer.Tick += (s, e) =>
            {
                // Вызываем UI-обновление в потоке интерфейса
                this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    LoadPlayerCards();
                    UpdateTable();
                    UpdateStatus();
                });
            };
            _uiUpdateTimer.Start();
        }


        private void LoadPlayerCards()
        {
            var cards = _db.Cards
                .Where(c => c.PlayerInGameId == _playerInGameId && c.GameSessionId == _gameSessionId)
                .Take(6)
                .ToList();

            flowLayoutPanelYourCards.Controls.Clear();

            foreach (var card in cards)
            {
                var btn = new Button
                {
                    Text = $"{card.Suit}{card.Rank}",
                    Width = 80,
                    Height = 120,
                    Font = new Font("Arial", 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = card
                };

                btn.Click += CardButton_Click;
                flowLayoutPanelYourCards.Controls.Add(btn);
            }
        }

        private async void CardButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var card = btn?.Tag as Card;

            if (card == null) return;

            var player = _db.PlayerInGames.Find(_playerInGameId);
            if (player == null) return;

            if (player.IsAttacker)
            {
                await _gameLogic.MakeAttackAsync(_playerInGameId, card);
            }
            else if (player.IsDefender)
            {
                var lastAttackCard = _db.Cards.FirstOrDefault(c => c.TurnId.HasValue && c.GameSessionId == _gameSessionId);
                if (lastAttackCard != null)
                {
                    await _gameLogic.MakeDefenceAsync(_playerInGameId, card, lastAttackCard);
                }
            }

            await _db.SaveChangesAsync(); // Сохраняем все изменения в БД
            LoadPlayerCards();
            UpdateTable();
            UpdateStatus();
            await DrawCardsIfNeeded();
            //await CheckWinCondition();
        }

        private void UpdateTable()
        {
            var playedCards = _db.Cards
                .Where(c => c.TurnId.HasValue && c.GameSessionId == _gameSessionId)
                .ToList();

            flowLayoutPanelTable.Controls.Clear();

            foreach (var card in playedCards)
            {
                var label = new Label
                {
                    Text = $"{card.Suit}{card.Rank}",
                    Width = 80,
                    Height = 120,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };

                flowLayoutPanelTable.Controls.Add(label);
            }
        }

        private async void btnNextTurn_Click(object sender, EventArgs e)
        {
            await SwitchTurnAsync();
            LoadPlayerCards();
            UpdateTable();
            UpdateStatus();
        }

        private Guid GetNextPlayerId()
        {
            return _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .FirstOrDefault(p => p.Id != _playerInGameId)?.Id ?? Guid.Empty;
        }

        private void ShowTrump()
        {
            var session = _db.GameSessions.Find(_gameSessionId);
            if (session != null)
                lblTrumpSuit.Text = $"Козырь: {session.TrumpSuit}";
        }

        private async void btnBit_Click(object sender, EventArgs e)
        {
            var playedCards = _db.Cards.Where(c => c.TurnId.HasValue).ToList();
            if (playedCards.Count == 0) return;

            foreach (var card in playedCards)
            {
                // Убираем TurnId, чтобы показать, что карта больше не на столе
                card.TurnId = null;

                // Не делаем PlayerInGameId = null — это нарушает внешний ключ
            }

            _db.Cards.UpdateRange(playedCards);
            await _db.SaveChangesAsync();

            await SwitchTurnAsync(); // Смена хода после бита
            //await CheckWinCondition();
        }

        private async void btnTake_Click(object sender, EventArgs e)
        {
            var playedCards = _db.Cards.Where(c => c.TurnId.HasValue).ToList();
            if (playedCards.Count == 0) return;

            foreach (var card in playedCards)
            {
                card.TurnId = null;
                card.PlayerInGameId = _playerInGameId;
            }

            _db.Cards.UpdateRange(playedCards);
            await _db.SaveChangesAsync();

            LoadPlayerCards();
            UpdateTable();
            //await CheckWinCondition();
        }

        private async Task SwitchTurnAsync()
        {
            var players = _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .ToList();

            if (players.Count != 2)
            {
                MessageBox.Show("Неверное количество игроков");
                return;
            }

            var attacker = players.FirstOrDefault(p => p.IsAttacker);
            var defender = players.FirstOrDefault(p => p.IsDefender);

            if (attacker == null || defender == null)
            {
                MessageBox.Show("Не определены роли игроков");
                return;
            }

            // Меняем роли местами
            attacker.IsAttacker = false;
            defender.IsAttacker = true;

            attacker.IsDefender = true;
            defender.IsDefender = false;

            _db.PlayerInGames.UpdateRange(players);
            await _db.SaveChangesAsync();
            await DrawCardsIfNeeded();
            await CheckWinCondition();
        }

        private void UpdateStatus()
        {
            var player = _db.PlayerInGames.Find(_playerInGameId);
            if (player != null)
            {
                lblStatus.Text = player.IsAttacker ? "Вы атакуете" : "Вы защищаетесь";
            }
        }


        private async Task DrawCardsIfNeeded()
        {
            var playerCards = _db.Cards
                .Where(c => c.PlayerInGameId == _playerInGameId)
                .ToList();

            int cardsNeeded = 6 - playerCards.Count;
            if (cardsNeeded <= 0) return;

            var availableCards = _db.Cards
                .Where(c => c.PlayerInGameId == null || c.PlayerInGameId == Guid.Empty)
                .Take(cardsNeeded)
                .ToList();

            foreach (var card in availableCards)
            {
                card.PlayerInGameId = _playerInGameId;
            }

            _db.Cards.UpdateRange(availableCards);
            await _db.SaveChangesAsync();

            LoadPlayerCards();
            UpdateStatus();

            await CheckWinCondition();
        }

        private async Task CheckWinCondition()
        {
            if (_deckFinished) return;

            var players = await _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .ToListAsync();

            if (players.Count != 2) return;

            var player1 = players[0];
            var player2 = players[1];

            var player1Cards = await _db.Cards
                .CountAsync(c => c.PlayerInGameId == player1.Id && c.TurnId == null);
            var player2Cards = await _db.Cards
                .CountAsync(c => c.PlayerInGameId == player2.Id && c.TurnId == null);

            var remainingDeckCount = await _db.Cards
                .CountAsync(c => c.PlayerInGameId == null);

            // **Определение победителя только если колода полностью пуста**
            if (remainingDeckCount == 0)
            {
                if (player1Cards == 0 && player2Cards == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Ничья! Оба игрока не имеют карт.");
                    });
                    _deckFinished = true;
                    return;
                }

                if (player1Cards > player2Cards)
                {
                    await HandleGameEnd(player1.Id == _playerInGameId);
                    return;
                }
                else if (player2Cards > player1Cards)
                {
                    await HandleGameEnd(player2.Id == _playerInGameId);
                    return;
                }
            }
        }





        private async Task HandleGameEnd(bool isWinner)
        {
            string message = isWinner ? "🎉 Ура! Вы выиграли!" : "😭 К сожалению, вы проиграли.";

            await UpdatePlayerStatistics(isWinner);

            this.Invoke((MethodInvoker)delegate
            {
                using (var winLoseForm = new WinningForm(message, _serviceProvider))
                {
                    winLoseForm.ShowDialog(this);
                }
            });

            _deckFinished = true;
        }

        private async Task UpdatePlayerStatistics(bool isWinner)
        {
            var userInGame = _db.PlayerInGames.Find(_playerInGameId);
            if (userInGame == null) return;

            var user = _db.Users.Find(userInGame.UserId);
            if (user == null) return;

            var stats = await _db.PlayerStatistics
                .FirstOrDefaultAsync(s => s.UserId == user.Id);

            if (stats == null)
            {
                // Если статистики нет — создаём новую запись
                stats = new PlayerStatistics
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    GamesWon = isWinner ? 1 : 0,
                    GamesLost = isWinner ? 0 : 1,
                    GamesDraw = 0
                };
                _db.PlayerStatistics.Add(stats);
            }
            else
            {
                // Или обновляем существующую
                if (isWinner)
                    stats.GamesWon++;
                else
                    stats.GamesLost++;
                _db.PlayerStatistics.Update(stats);
            }

            await _db.SaveChangesAsync();
        }

        private async void btn_Home_Click(object sender, EventArgs e)
        {
            using (var notificationForm = new NotificationForm())
            {
                notificationForm.ShowDialog(this);

                if (notificationForm.ConfirmExit)
                {
                    // Игрок выбрал "Выйти"
                    await HandleGameEnd(false); // Игрок проигрывает автоматически
                    this.Close(); // Закрываем форму игры
                }
            }
        }

        private void btn_ruls_Click(object sender, EventArgs e)
        {
            var rulesForm = new RuleForm();
            rulesForm.ShowDialog(this); // Чтобы блокировать игру до закрытия
        }
    }
}
