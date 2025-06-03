namespace Game
{
    public partial class NotificationForm : Form
    {
        public bool ConfirmExit { get; private set; }

        public NotificationForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ConfirmExit = true;
            Close();
        }

        private void btn_Stay_Click(object sender, EventArgs e)
        {
            ConfirmExit = false;
            Close();
        }
    }
}
