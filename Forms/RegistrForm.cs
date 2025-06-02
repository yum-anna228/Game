using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Game
{

    /// <summary>
    /// форма регистрации
    /// </summary>
    public partial class RegistrForm : Form
    {
        private readonly IAuthService _authService;
        private readonly GameDbContext _db;
        private readonly IServiceProvider _serviceProvider;

        public RegistrForm(IAuthService authService, GameDbContext db, IServiceProvider serviceProvider)
        {
            _authService = authService;
            _db = db;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private async void btn_Registr1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            // Проверка совпадения паролей
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            // Регистрация пользователя
            bool success = await _authService.RegisterAsync(username, password);
            if (success)
            {
                MessageBox.Show("Регистрация успешна!");
                var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка регистрации. Возможно, пользователь с таким именем уже существует.");
            }
        }

        private void btn_Enter1_Click(object sender, EventArgs e)
        {
            var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
            this.Hide();
        }
    }
}
