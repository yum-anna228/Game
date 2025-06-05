using Microsoft.EntityFrameworkCore;
using NLog;

namespace Game
{
    public partial class StatisticsForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly GameDbContext _db;

        public StatisticsForm(GameDbContext db)
        {
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            InitializeComponent();
            _db = db;

            Load += StatisticsForm_Load;
        }

        private async void StatisticsForm_Load(object sender, EventArgs e)
        {
            logger.Debug("Загрузка формы статистики");
            await LoadStatistics();
        }

        private async Task LoadStatistics()
        {
            var statsList = await _db.PlayerStatistics
                .Include(s => s.User)
                .ToListAsync();

            logger.Info($"Загружено {statsList.Count} записей статистики");
            flowLayoutPanelStats.Controls.Clear();

            foreach (var stat in statsList)
            {
                var label = new Label
                {
                    Text = $"Игрок: {stat.User.Username} | Побед: {stat.GamesWon} | Поражений: {stat.GamesLost} | Ничьих: {stat.GamesDraw}",
                    Width = 400,
                    Height = 30,
                    Font = new Font("Arial", 10),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                flowLayoutPanelStats.Controls.Add(label);
                logger.Trace($"Добавлена статистика для пользователя: {stat.User.Username}");
            }
        }
    }
}