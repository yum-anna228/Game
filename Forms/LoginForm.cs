using Microsoft.Extensions.DependencyInjection;
using System;

namespace Game
{
    public partial class LoginForm : Form
    {
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

        // Конструктор с сессией
        public LoginForm(IAuthService authService, GameDbContext db, Guid? gameSessionId, IServiceProvider serviceProvider)
            : this(authService, db, serviceProvider)
        {
            _gameSessionId = gameSessionId;
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            var user = await _authService.LoginAsync(username, password);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

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

                // Получаем форму через DI — так как GameDbContext внедрён через DI
                var scope = _serviceProvider.CreateScope();
                var scopedProvider = scope.ServiceProvider;

                var gameForm = _serviceProvider.GetRequiredService<GameTableFormFor2Players>();
                gameForm.SetPlayerInGame(_gameSessionId.Value, playerInGame.Id);
                gameForm.Show();
                this.Hide();
            }
            else
            {
                var selectModeForm = _serviceProvider.GetRequiredService<SelectModeForm>();
                selectModeForm.SetCurrentUser(user);
                selectModeForm.Show();
                this.Hide();
            }
        }

        private void btn_Registr_Click(object sender, EventArgs e)
        {
            var registForm = _serviceProvider.GetRequiredService<RegistrForm>();
            registForm.Show();
            this.Hide();
        }

    }
}
