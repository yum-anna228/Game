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
            InitializeComponent();

            _db = db;
            _gameSessionId = sessionId;
            _playerInGameId = playerInGameId;
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
                await _gameLogic.MakeAttackAsync(_playerInGameId, selectedCard);
                LoadPlayerCards(); // Обновляем руку после хода
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

        private void btnBit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы нажали 'Бито'");
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы нажали 'Взять'");
        }

        public void SetPlayerInGame(Guid sessionId, Guid playerInGameId)
        {
            _gameSessionId = sessionId;
            _playerInGameId = playerInGameId;
        }
    }
}
