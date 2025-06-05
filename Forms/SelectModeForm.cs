using NLog;
using System.Diagnostics;
using System.Globalization;

namespace Game
{
    /// <summary>
    /// Форма, позволяющая пользователю выбрать режим игры: 2 игрока или 3 игрока,
    /// а также перейти к просмотру статистики
    /// </summary>
    public partial class SelectModeForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly GameDbContext _db;
        private User _currentUser;

        public SelectModeForm(GameDbContext db)
        {
            if (db == null)
                throw new ArgumentNullException(nameof(db));
            // Проверяем сохранённый язык пользователя
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            InitializeComponent();
            _db = db;
            logger.Info("Форма выбора режима загружена");
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        private void btn_2players_Click(object sender, EventArgs e)
        {
            logger.Debug("Выбран режим на 2 игрока");
            StartGame(2);
        }

        private void btn_3players_Click(object sender, EventArgs e)
        {
            logger.Debug("Выбран режим на 3 игрока");
            StartGame(3);
        }

        private void SelectModeForm_Load(object sender, EventArgs e)
        {
            logger.Trace("Форма SelectModeForm загружена");
        }

        private void btn_viewStatistics_Click(object sender, EventArgs e)
        {
            logger.Info("Переход к статистике");
            var statsForm = new StatisticsForm(_db);
            statsForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Начинает новую игровую сессию с заданным количеством игроков
        /// Создаёт сессию, игроков, колоду карт и запускает клиентские процессы
        /// </summary>
        private void StartGame(int playerCount)
        {
            logger.Info($"Начало игры с {playerCount} игроками");

            if (_currentUser == null)
            {
                logger.Warn("Ошибка: пользователь не установлен");
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
                logger.Error(ex, "Ошибка при сохранении данных в БД");
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
                logger.Fatal(ex, "Ошибка при запуске клиентских процессов");
                MessageBox.Show($"Ошибка при запуске клиента: {ex.Message}");
            }

            this.Close();
        }

        /// <summary>
        /// Получает ID второго пользователя (не текущего)
        /// Если такой пользователь не найден, создаёт бота и сохраняет в БД
        /// </summary>
        private Guid GetSecondUserId(Guid currentUserId)
        {
            logger.Trace("Поиск второго пользователя");
            var user = _db.Users.FirstOrDefault(u => u.Id != currentUserId);
            if (user == null)
            {
                logger.Warn("Второй пользователь не найден — создаём бота");
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = "Bot",
                    PasswordHash = new PasswordHasher().HashPassword("password")
                };
                _db.Users.Add(user);
                _db.SaveChanges();
            }
            logger.Debug($"ID второго игрока: {user.Id}");
            return user.Id;
        }

        /// <summary>
        /// Возвращает случайную масть, которая будет козырной в текущей игре
        /// </summary>
        private string GetRandomTrumpSuit()
        {
            var suits = new[] { "♠", "♥", "♦", "♣" };
            return suits[new Random().Next(suits.Length)];
        }
    }
}