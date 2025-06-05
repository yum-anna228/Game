using System.Globalization;

namespace Game
{
    public partial class RuleForm : Form
    {
        public RuleForm()
        {
            var cultureName = Properties.Settings.Default.Language ?? "ru-RU";
            var culture = new CultureInfo(cultureName);
            InitializeComponent();
        }
    }
}
