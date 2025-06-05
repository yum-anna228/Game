using System.Globalization;

namespace Game
{
    public partial class RuleForm : Form
    {
        public RuleForm()
        {
            // Проверяем сохранённый язык пользователя
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            InitializeComponent();
        }
    }
}
