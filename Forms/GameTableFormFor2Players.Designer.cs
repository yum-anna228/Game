namespace Game
{
    partial class GameTableFormFor2Players
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameTableFormFor2Players));
            btn_Home = new Button();
            flowLayoutPanelOpponentCards = new FlowLayoutPanel();
            flowLayoutPanelYourCards = new FlowLayoutPanel();
            flowLayoutPanelTable = new FlowLayoutPanel();
            lblTrumpSuit = new Label();
            btnBit = new Button();
            btnTake = new Button();
            btnNextTurn = new Button();
            lblStatus = new Label();
            btn_ruls = new Button();
            SuspendLayout();
            // 
            // btn_Home
            // 
            btn_Home.BackColor = Color.Transparent;
            btn_Home.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btn_Home, "btn_Home");
            btn_Home.ForeColor = Color.White;
            btn_Home.Name = "btn_Home";
            btn_Home.UseVisualStyleBackColor = false;
            btn_Home.Click += btn_Home_Click;
            // 
            // flowLayoutPanelOpponentCards
            // 
            flowLayoutPanelOpponentCards.BackColor = Color.Transparent;
            resources.ApplyResources(flowLayoutPanelOpponentCards, "flowLayoutPanelOpponentCards");
            flowLayoutPanelOpponentCards.Name = "flowLayoutPanelOpponentCards";
            // 
            // flowLayoutPanelYourCards
            // 
            flowLayoutPanelYourCards.BackColor = Color.Transparent;
            resources.ApplyResources(flowLayoutPanelYourCards, "flowLayoutPanelYourCards");
            flowLayoutPanelYourCards.Name = "flowLayoutPanelYourCards";
            // 
            // flowLayoutPanelTable
            // 
            flowLayoutPanelTable.BackColor = Color.Transparent;
            resources.ApplyResources(flowLayoutPanelTable, "flowLayoutPanelTable");
            flowLayoutPanelTable.Name = "flowLayoutPanelTable";
            // 
            // lblTrumpSuit
            // 
            resources.ApplyResources(lblTrumpSuit, "lblTrumpSuit");
            lblTrumpSuit.BackColor = Color.Transparent;
            lblTrumpSuit.ForeColor = Color.White;
            lblTrumpSuit.Name = "lblTrumpSuit";
            // 
            // btnBit
            // 
            resources.ApplyResources(btnBit, "btnBit");
            btnBit.BackColor = Color.Transparent;
            btnBit.FlatAppearance.BorderSize = 0;
            btnBit.ForeColor = Color.White;
            btnBit.Name = "btnBit";
            btnBit.UseVisualStyleBackColor = false;
            btnBit.Click += btnBit_Click;
            // 
            // btnTake
            // 
            resources.ApplyResources(btnTake, "btnTake");
            btnTake.BackColor = Color.Transparent;
            btnTake.FlatAppearance.BorderSize = 0;
            btnTake.ForeColor = Color.White;
            btnTake.Name = "btnTake";
            btnTake.UseVisualStyleBackColor = false;
            btnTake.Click += btnTake_Click;
            // 
            // btnNextTurn
            // 
            resources.ApplyResources(btnNextTurn, "btnNextTurn");
            btnNextTurn.BackColor = Color.Transparent;
            btnNextTurn.FlatAppearance.BorderSize = 0;
            btnNextTurn.ForeColor = Color.White;
            btnNextTurn.Name = "btnNextTurn";
            btnNextTurn.UseVisualStyleBackColor = false;
            btnNextTurn.Click += btnNextTurn_Click;
            // 
            // lblStatus
            // 
            resources.ApplyResources(lblStatus, "lblStatus");
            lblStatus.BackColor = Color.Transparent;
            lblStatus.ForeColor = Color.White;
            lblStatus.Name = "lblStatus";
            // 
            // btn_ruls
            // 
            btn_ruls.BackColor = Color.Transparent;
            btn_ruls.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btn_ruls, "btn_ruls");
            btn_ruls.Name = "btn_ruls";
            btn_ruls.UseVisualStyleBackColor = false;
            btn_ruls.Click += btn_ruls_Click;
            // 
            // GameTableFormFor2Players
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.игровой_стол;
            Controls.Add(btn_ruls);
            Controls.Add(lblStatus);
            Controls.Add(btnNextTurn);
            Controls.Add(btnTake);
            Controls.Add(btnBit);
            Controls.Add(lblTrumpSuit);
            Controls.Add(flowLayoutPanelTable);
            Controls.Add(flowLayoutPanelYourCards);
            Controls.Add(flowLayoutPanelOpponentCards);
            Controls.Add(btn_Home);
            DoubleBuffered = true;
            Name = "GameTableFormFor2Players";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Home;
        private FlowLayoutPanel flowLayoutPanelOpponentCards;
        private FlowLayoutPanel flowLayoutPanelYourCards;
        private FlowLayoutPanel flowLayoutPanelTable;
        private Label lblTrumpSuit;
        private Button btnBit;
        private Button btnTake;
        private Button btnNextTurn;
        private Label lblStatus;
        private Button btn_ruls;
    }
}