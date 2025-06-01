using System.Data;
using System.Reflection;

namespace Game
{
    public partial class GameTableFormFor2Players : Form
    {
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
            LoadPlayerCards();
            ShowTrump();
        }

        private Image GetCardImage(string imageName)
        {
            try
            {
                // Полное имя ресурса
                string resourceName = "Game.Resources." + imageName;

                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch
            {
                // Возвращаем null, если не найдено
                return null;
            }

            return null;
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
                string imageName = $"{card.Rank}_{card.Suit}.png";
                var image = GetCardImage(imageName);

                // Если изображение не найдено, используем обратную сторону
                if (image == null)
                {
                    image = GetCardImage("BackOfCard.png");
                }

                var pictureBox = new PictureBox
                {
                    Width = 80,
                    Height = 120,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = image, // Теперь только image, без BackOfCard
                    Tag = card
                };

                pictureBox.Click += CardPictureBox_Click;
                flowLayoutPanelYourCards.Controls.Add(pictureBox);
            }
        }

        private async void CardPictureBox_Click(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb?.Tag is Card selectedCard)
            {
                var player = _db.PlayerInGames.Find(_playerInGameId);

                if (player == null) return;

                if (player.IsAttacker)
                {
                    await _gameLogic.MakeAttackAsync(_playerInGameId, selectedCard);
                }
                else if (player.IsDefender)
                {
                    var lastAttackCard = _db.Cards.FirstOrDefault(c => c.TurnId.HasValue && c.GameSessionId == _gameSessionId);
                    if (lastAttackCard != null)
                    {
                        await _gameLogic.MakeDefenceAsync(_playerInGameId, selectedCard, lastAttackCard);
                    }
                }

                LoadPlayerCards();
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            var playedCards = _db.Cards
                .Where(c => c.TurnId.HasValue && c.GameSessionId == _gameSessionId)
                .ToList();

            flowLayoutPanelTable.Controls.Clear();

            foreach (var card in playedCards)
            {
                string imageName = $"{card.Rank}_{card.Suit}.png";
                var image = GetCardImage(imageName) ?? GetCardImage("BackOfCard.png");

                var pictureBox = new PictureBox
                {
                    Width = 80,
                    Height = 120,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = image
                };

                flowLayoutPanelTable.Controls.Add(pictureBox);
            }
        }

        private async void btnNextTurn_Click(object sender, EventArgs e)
        {
            await _gameLogic.EndBoutAsync(GetNextPlayerId());
            MessageBox.Show("Ход передан");
            LoadPlayerCards();
            UpdateTable();
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
                card.TurnId = null;
                card.PlayerInGameId = Guid.Empty; // освобождаем карты
            }

            _db.Cards.UpdateRange(playedCards);
            await _db.SaveChangesAsync();

            LoadPlayerCards();
            UpdateTable();
            SwitchTurn(); // смени ход
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

        private async void SwitchTurn()
        {
            var players = _db.PlayerInGames
                .Where(p => p.GameSessionId == _gameSessionId)
                .ToList();

            foreach (var p in players)
            {
                p.IsAttacker = !p.IsAttacker;
                p.IsDefender = !p.IsDefender;
            }

            _db.PlayerInGames.UpdateRange(players);
            await _db.SaveChangesAsync();
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
        }
    }
}
