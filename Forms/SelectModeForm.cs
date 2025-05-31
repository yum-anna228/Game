using System.Diagnostics;

namespace Game
{
    public partial class SelectModeForm : Form
    {
        private readonly GameDbContext _db;

        public SelectModeForm(GameDbContext db)
        {
            _db = db;
        }

        private readonly User _currentUser;
        public SelectModeForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
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
            var session = new GameSession
            {
                Id = Guid.NewGuid(),
                StartTime = DateTime.Now,
                TrumpSuit = GetRandomTrumpSuit(),
                IsFinished = false
            };

            _db.GameSessions.Add(session);
            _db.SaveChanges();

            Process.Start(Application.ExecutablePath, $"{playerCount} {session.Id}");
            Process.Start(Application.ExecutablePath, $"{playerCount} {session.Id}");

            Application.Exit();
        }

        private string GetRandomTrumpSuit()
        {
            var suits = new[] { "♠", "♥", "♦", "♣" };
            return suits[new Random().Next(suits.Length)];
        }
    }
}
