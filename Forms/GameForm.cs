using NLog;

namespace Game
{

    /// <summary>
    /// основная форма приложения
    /// </summary>
    public partial class GameForm : Form
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IAuthService _authService;
        private readonly GameDbContext _db;
        private readonly IServiceProvider _serviceProvider;


        public GameForm(IAuthService authService, GameDbContext db, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authService = authService;
            _db = db;
            _serviceProvider = serviceProvider;
        }
        

        private void btn_Game_Click(object sender, EventArgs e)
        {
            logger.Debug("Кнопка 'Играть' нажата");
            var loginForm = new LoginForm(_authService, _db, _serviceProvider);
            loginForm.FormClosed += (s, args) =>
            {
                logger.Info("LoginForm закрыта");
                this.Show(); 
            };
            loginForm.Show();
            this.Hide();
        }
    }
}
