namespace Game
{
    public partial class RegistrForm : Form
    {
        private readonly IAuthService _authService;

        public RegistrForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
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
                var loginForm = new LoginForm(_authService);
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
            var loginForm = new LoginForm(_authService);
            loginForm.Show();
            this.Hide();
        }
    }
}
