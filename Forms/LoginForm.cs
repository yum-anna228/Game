using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.ComponentModel;
using System.Globalization;

namespace Game
{
    /// <summary>
    /// форма аутентификации пользователя в приложение
    /// </summary>
    public partial class LoginForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IAuthService _authService;
        private readonly GameDbContext _db;
        private Guid? _gameSessionId;

        public LoginForm(IAuthService authService, GameDbContext db)
        {
            // Проверяем сохранённый язык пользователя
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            InitializeComponent();
            _authService = authService;
            _db = db;
        }

        public LoginForm(IAuthService authService, GameDbContext db, Guid? gameSessionId)
            : this(authService, db)
        {
            _gameSessionId = gameSessionId;
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            logger.Trace("Нажата кнопка 'Войти'");
            string username = txtLogin.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(Properties.Resources.EmptyLoginOrPassword);
                logger.Warn("Логин или пароль не введены");
                return;
            }

            var user = await _authService.LoginAsync(username, password);
            if (user == null)
            {
                logger.Warn($"Неудачная попытка входа для пользователя '{username}'");
                MessageBox.Show(Properties.Resources.InvalidCredentials);
                return;
            }
            logger.Info($"Пользователь '{username}' успешно вошёл");

            if (_gameSessionId.HasValue)
            {
                var existingPlayersCount = _db.PlayerInGames.Count(p => p.GameSessionId == _gameSessionId.Value);

                var playerInGame = new PlayerInGame
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    GameSessionId = _gameSessionId.Value,
                    Position = existingPlayersCount + 1,
                    IsAttacker = false,
                    IsDefender = false
                };

                _db.PlayerInGames.Add(playerInGame);
                await _db.SaveChangesAsync();

                var gameTableForm = new GameTableFormFor2Players(_db);
                gameTableForm.SetPlayerInGame(_gameSessionId.Value, playerInGame.Id);
                gameTableForm.Show();
                this.Hide();
            }
            else
            {
                logger.Info("Переход к выбору режима игры");
                var selectModeForm = new SelectModeForm(_db);
                selectModeForm.SetCurrentUser(user);
                selectModeForm.Show();
                this.Hide();
            }
        }

        private void btn_Registr_Click(object sender, EventArgs e)
        {
            var registForm = new RegistrForm(_authService, _db);
            registForm.Show();
            this.Hide();
        }

    }
}
