using NLog;
using System.Globalization;

namespace Game
{
    public partial class NotificationForm : Form
    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Результат: true — игрок выбрал выйти, false — остаться
        /// </summary>
        public bool ConfirmExit { get; private set; }

        public NotificationForm()
        {
            // Проверяем сохранённый язык пользователя
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            InitializeComponent();
            logger.Info("Форма уведомления (NotificationForm) загружена");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            logger.Warn("Игрок выбрал 'Выйти'");
            ConfirmExit = true;
            Close();
        }

        private void btn_Stay_Click(object sender, EventArgs e)
        {
            logger.Debug("Игрок выбрал 'Остаться'");
            ConfirmExit = false;
            Close();
        }
    }
}
