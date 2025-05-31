using System.Data;

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
        }

        private void LoadPlayerCards()
        {
            var cards = _gameLogic.GetPlayerCards(_playerInGameId);

            flowLayoutPanelYourCards.Controls.Clear();

            foreach (var card in cards.Take(6))
            {
                var btn = new Button
                {
                    Text = $"{card.Suit}{card.Rank}",
                    Width = 60,
                    Height = 90,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
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

            await _gameLogic.MakeAttackAsync(_playerInGameId, card);
            LoadPlayerCards();
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
