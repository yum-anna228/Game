using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class WinningForm : Form
    {

        private readonly IServiceProvider _serviceProvider;

        public WinningForm(string message, IServiceProvider serviceProvider)
        {
            InitializeComponent(); // Автоматически генерируется Visual Studio

            _serviceProvider = serviceProvider;

            // Установите текст метки, если она добавлена через дизайнер
            if (lbl_winner != null)
            {
                lbl_winner.Text = message;
            }
        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {
            var mainMenuForm = _serviceProvider.GetRequiredService<GameForm>();
            mainMenuForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем форму статистики
            var statsForm = _serviceProvider.GetRequiredService<StatisticsForm>();
            statsForm.Show();
            this.Hide();
        }
    }
}
