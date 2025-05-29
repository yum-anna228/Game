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
    }
}
