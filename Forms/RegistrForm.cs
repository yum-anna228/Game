using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Game
{

    /// <summary>
    /// форма регистрации
    /// </summary>
    public partial class RegistrForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IAuthService _authService;
        private readonly GameDbContext _db;
        private readonly IServiceProvider _serviceProvider;

        public RegistrForm(IAuthService authService, GameDbContext db, IServiceProvider serviceProvider)
        {
            _authService = authService;
            _db = db;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            logger.Info("Форма регистрации загружена");
        }

        private async void btn_Registr1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            logger.Debug($"Попытка регистрации пользователя: {username}");

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                logger.Warn("Не все поля заполнены при регистрации");
                return;
            }

            // Проверка совпадения паролей
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                logger.Warn("Пароли не совпадают");
                return;
            }

            // Регистрация пользователя
            bool success = await _authService.RegisterAsync(username, password);
            if (success)
            {
                logger.Info($"Пользователь '{username}' успешно зарегистрирован");
                MessageBox.Show("Регистрация успешна!");
                var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                logger.Error($"Ошибка регистрации для пользователя '{username}' — возможно, пользователь уже существует");
                MessageBox.Show("Ошибка регистрации. Возможно, пользователь с таким именем уже существует.");
            }
        }

        private void btn_Enter1_Click(object sender, EventArgs e)
        {
            logger.Debug("Кнопка 'Войти' нажата — переход на форму входа");
            var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
            this.Hide();
        }
    }
}
