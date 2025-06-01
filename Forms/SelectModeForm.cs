using System.Diagnostics;

namespace Game
{
    public partial class SelectModeForm : Form
    {
        private readonly GameDbContext _db;
        private  User _currentUser;
        private readonly IServiceProvider _serviceProvider;

        public SelectModeForm(GameDbContext db, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db;
            _serviceProvider = serviceProvider;
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }


        private void btn_2players_Click(object sender, EventArgs e)
        {
            StartGame(2);
        }

        private void btn_3players_Click(object sender, EventArgs e)
        {
            StartGame(3);
        }

        private void SelectModeForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_viewStatistics_Click(object sender, EventArgs e)
        {
            var statsForm = new StatisticsForm(); // ваша форма статистики
            statsForm.Show();
            this.Hide();
        }

        private void StartGame(int playerCount)
        {
            MessageBox.Show("StartGame начат");

            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка: пользователь не установлен.");
                return;
            }

            var session = new GameSession
            {
                Id = Guid.NewGuid(),
                StartTime = DateTime.UtcNow,
                TrumpSuit = GetRandomTrumpSuit(),
                IsFinished = false
            };

            _db.GameSessions.Add(session);

            var players = new List<PlayerInGame>();

            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new PlayerInGame
                {
                    Id = Guid.NewGuid(),
                    UserId = i == 0 ? _currentUser.Id : GetSecondUserId(_currentUser.Id),
                    GameSessionId = session.Id,
                    Position = i,
                    IsAttacker = i == 0,
                    IsDefender = i == 1
                });
            }

            _db.PlayerInGames.AddRange(players);

            var deckService = new DeckService(session.TrumpSuit);
            var cards = deckService.CreateDeck(session.Id, players.Select(p => p.Id).ToList());
            _db.Cards.AddRange(cards);

            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении в БД: {ex.Message}");
                return;
            }

            MessageBox.Show($"Сессия: {session.Id}\nИгрок 1: {players[0].Id}\nИгрок 2: {players[1].Id}");

            try
            {
                Process.Start(Application.ExecutablePath, $"--session {session.Id} --player {players[0].Id}");
                Process.Start(Application.ExecutablePath, $"--session {session.Id} --player {players[1].Id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске клиента: {ex.Message}");
            }

            this.Close(); // вместо Application.Exit()
        }

        private Guid GetSecondUserId(Guid currentUserId)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id != currentUserId);
            if (user == null)
            {
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = "Bot",
                    PasswordHash = new PasswordHasher().HashPassword("password")
                };
                _db.Users.Add(user);
                _db.SaveChanges();
            }
            return user.Id;
        }

        private string GetRandomTrumpSuit()
        {
            var suits = new[] { "♠️", "♥️", "♦️", "♣️" };
            return suits[new Random().Next(suits.Length)];
        }
    }
}
