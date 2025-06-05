using NLog;
using System.Globalization;

namespace Game
{

    /// <summary>
    /// îñíîâíàÿ ôîðìà ïðèëîæåíèÿ
    /// </summary>
    public partial class GameForm : Form
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IAuthService _authService;
        private readonly GameDbContext _db;


        public GameForm(IAuthService authService, GameDbContext db)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                var culture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
            }
            InitializeComponent();
            _authService = authService;
            _db = db;

            UpdateLanguageButtonText();

        }



        private void btn_Game_Click(object sender, EventArgs e)
        {
            logger.Debug("Êíîïêà 'Èãðàòü' íàæàòà");
            var loginForm = new LoginForm(_authService, _db);
            loginForm.FormClosed += (s, args) =>
            {
                logger.Info("LoginForm çàêðûòà");
                this.Show();
            };
            loginForm.Show();
            this.Hide();
        }

        private void btn_language_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "ru-RU")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            }

            Properties.Settings.Default.Language = Thread.CurrentThread.CurrentUICulture.Name;
            Properties.Settings.Default.Save();

            Application.Restart();
        }

        private void UpdateLanguageButtonText()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                btn_language.Text = "Русский";
            }
            else
            {
                btn_language.Text = "English";
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = Thread.CurrentThread.CurrentUICulture.Name;
            Properties.Settings.Default.Save();
        }
    }
}