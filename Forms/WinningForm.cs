using NLog;
using System.Globalization;

namespace Game
{
    public partial class WinningForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly GameDbContext _db;

        public WinningForm(string message, GameDbContext db)
        {
            if (db == null)
                throw new ArgumentNullException(nameof(db));
            // Проверяем сохранённый язык пользователя
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            InitializeComponent();
            _db = db;

            if (lbl_winner != null)
            {
                lbl_winner.Text = message;
                logger.Info($"Форма победы открыта: {message}");
            }
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            logger.Debug("Кнопка 'Новая игра' нажата");

            // Предположим, что authService уже где-то доступен или получается другим способом
            var authService = new AuthService(
                new UserRepository(_db),
                new PasswordHasher()
            );

            var mainMenuForm = new GameForm(authService, _db);
            mainMenuForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Debug("Переход к статистике");

            var statsForm = new StatisticsForm(_db);
            statsForm.Show();
            this.Hide();
        }
    }
}