using System.Data;

namespace Game
{
    public partial class GameTableFormFor2Players : Form
    {
        private System.Windows.Forms.Timer _uiUpdateTimer;
        private readonly GameDbContext _db;
        private  Guid _gameSessionId;
        private  Guid _playerInGameId;

        private readonly DurakGameLogic _gameLogic;

        public GameTableFormFor2Players(Guid sessionId, Guid playerInGameId, GameDbContext db)
        {
            if (db == null)
            {
                MessageBox.Show("Ошибка: База данных не инициализирована");
                return;
            }

            InitializeComponent(); // Теперь после проверки

            _db = db;
            _gameSessionId = sessionId;
            _playerInGameId = playerInGameId;

            var session = _db.GameSessions.Find(sessionId);
            if (session == null)
            {
                MessageBox.Show("Ошибка при запуске формы: Сессия не найдена");
                return;
            }

            _gameLogic = new DurakGameLogic(_db, _gameSessionId);
            StartUIUpdateTimer();
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

            //LoadPlayerCards();
            //UpdateTable();
            await SwitchTurnAsync(); // Смена хода после бита
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
        }

        private void UpdateStatus()
        {
            var player = _db.PlayerInGames.Find(_playerInGameId);
            if (player != null)
            {
                lblStatus.Text = player.IsAttacker ? "Вы атакуете" : "Вы защищаетесь";
            }
        }

        public void SetPlayerInGame(Guid sessionId, Guid playerInGameId)
        {
            if (_db == null)
            {
                MessageBox.Show("Ошибка: База данных не инициализирована");
                return;
            }

            _gameSessionId = sessionId;
            _playerInGameId = playerInGameId;

            var session = _db.GameSessions.Find(sessionId);
            if (session == null)
            {
                MessageBox.Show("Ошибка: Сессия не найдена");
                return;
            }

            LoadPlayerCards();
            ShowTrump();
            UpdateStatus();
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
        }
    }
}
