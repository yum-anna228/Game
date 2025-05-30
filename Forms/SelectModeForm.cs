namespace Game
{
    public partial class SelectModeForm : Form
    {
        private readonly User _currentUser;
        public SelectModeForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void btn_2players_Click(object sender, EventArgs e)
        {
            //StartGame(2);
        }

        private void btn_3players_Click(object sender, EventArgs e)
        {

        }

        private void SelectModeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
