using Microsoft.EntityFrameworkCore;
using NLog;

namespace Game
{
    /// <summary>
    /// Форма регистрации
    /// </summary>
    public partial class RegistrForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IAuthService _authService;
        private readonly GameDbContext _db;

        public RegistrForm(IAuthService authService, GameDbContext db)
        {
            InitializeComponent();

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _db = db ?? throw new ArgumentNullException(nameof(db));

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

                var loginForm = new LoginForm(_authService, _db);
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

            var loginForm = new LoginForm(_authService, _db);
            loginForm.Show();
            this.Hide();
        }
    }
}