using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Game
{
    public partial class WinningForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IServiceProvider _serviceProvider;

        public WinningForm(string message, IServiceProvider serviceProvider)
        {
            InitializeComponent(); 

            _serviceProvider = serviceProvider;

            if (lbl_winner != null)
            {
                lbl_winner.Text = message;
                logger.Info($"Форма победы открыта: {message}");
            }
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            logger.Debug("Кнопка 'Новая игра' нажата");
            var mainMenuForm = _serviceProvider.GetRequiredService<GameForm>();
            mainMenuForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Debug("Переход к статистике");
            var statsForm = _serviceProvider.GetRequiredService<StatisticsForm>();
            statsForm.Show();
            this.Hide();
        }
    }
}
