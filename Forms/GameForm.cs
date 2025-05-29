namespace Game
{
    public partial class GameForm : Form
    {
        private readonly IAuthService _authService;

        public GameForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }
        

        private void btn_Game_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_authService);
            loginForm.FormClosed += (s, args) => this.Show(); // Показать снова, если нужно
            loginForm.Show();
            this.Hide();
        }
    }
}
