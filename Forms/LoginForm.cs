using Microsoft.Extensions.DependencyInjection;

namespace Game
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;

        public LoginForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
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
            if (user != null)
            {
                MessageBox.Show("Вы успешно вошли!");
                var selectModeForm = new SelectModeForm(user);
                selectModeForm.Show();
                this.Hide();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void btn_Registr_Click(object sender, EventArgs e)
        {
            var registForm = new RegistrForm(_authService);
            registForm.Show();
            this.Hide(); // Скрываем текущую форму
        }

    }
}
