using Microsoft.Extensions.DependencyInjection;
using NLog;

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
        private readonly IServiceProvider _serviceProvider;
        private Guid? _gameSessionId;

        public LoginForm(IAuthService authService, GameDbContext db, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authService = authService;
            _db = db;
            _serviceProvider = serviceProvider;
        }

        
        public LoginForm(IAuthService authService, GameDbContext db, Guid? gameSessionId, IServiceProvider serviceProvider)
            : this(authService, db, serviceProvider)
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
                MessageBox.Show("Введите логин и пароль.");
                logger.Warn("Логин или пароль не введены");
                return;
            }

            var user = await _authService.LoginAsync(username, password);
            if (user == null)
            {
                logger.Warn($"Неудачная попытка входа для пользователя '{username}'");
                MessageBox.Show("Неверный логин или пароль");
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

                var scope = _serviceProvider.CreateScope();
                var scopedProvider = scope.ServiceProvider;

                var gameForm = _serviceProvider.GetRequiredService<GameTableFormFor2Players>();
                gameForm.SetPlayerInGame(_gameSessionId.Value, playerInGame.Id);
                gameForm.Show();
                this.Hide();
            }
            else
            {
                logger.Info("Переход к выбору режима игры");
                var selectModeForm = _serviceProvider.GetRequiredService<SelectModeForm>();
                selectModeForm.SetCurrentUser(user);
                selectModeForm.Show();
                this.Hide();
            }
        }

        private void btn_Registr_Click(object sender, EventArgs e)
        {
            logger.Info("Кнопка 'Зарегистрироваться' нажата");
            var registForm = _serviceProvider.GetRequiredService<RegistrForm>();
            registForm.Show();
            this.Hide();
        }

    }
}
