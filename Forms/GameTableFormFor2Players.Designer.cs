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
            btn_Home.FlatStyle = FlatStyle.Flat;
            btn_Home.ForeColor = Color.White;
            btn_Home.Location = new Point(28, 24);
            btn_Home.Name = "btn_Home";
            btn_Home.Size = new Size(41, 39);
            btn_Home.TabIndex = 0;
            btn_Home.UseVisualStyleBackColor = false;
            btn_Home.Click += btn_Home_Click;
            // 
            // flowLayoutPanelOpponentCards
            // 
            flowLayoutPanelOpponentCards.BackColor = Color.Transparent;
            flowLayoutPanelOpponentCards.Location = new Point(301, 24);
            flowLayoutPanelOpponentCards.Name = "flowLayoutPanelOpponentCards";
            flowLayoutPanelOpponentCards.Size = new Size(303, 111);
            flowLayoutPanelOpponentCards.TabIndex = 1;
            // 
            // flowLayoutPanelYourCards
            // 
            flowLayoutPanelYourCards.BackColor = Color.Transparent;
            flowLayoutPanelYourCards.Location = new Point(133, 388);
            flowLayoutPanelYourCards.Name = "flowLayoutPanelYourCards";
            flowLayoutPanelYourCards.Size = new Size(623, 150);
            flowLayoutPanelYourCards.TabIndex = 2;
            // 
            // flowLayoutPanelTable
            // 
            flowLayoutPanelTable.BackColor = Color.Transparent;
            flowLayoutPanelTable.Location = new Point(215, 141);
            flowLayoutPanelTable.Name = "flowLayoutPanelTable";
            flowLayoutPanelTable.Size = new Size(505, 241);
            flowLayoutPanelTable.TabIndex = 3;
            // 
            // lblTrumpSuit
            // 
            lblTrumpSuit.AutoSize = true;
            lblTrumpSuit.BackColor = Color.Transparent;
            lblTrumpSuit.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTrumpSuit.ForeColor = Color.White;
            lblTrumpSuit.Location = new Point(69, 220);
            lblTrumpSuit.Name = "lblTrumpSuit";
            lblTrumpSuit.Size = new Size(0, 41);
            lblTrumpSuit.TabIndex = 4;
            // 
            // btnBit
            // 
            btnBit.BackColor = Color.Transparent;
            btnBit.FlatAppearance.BorderSize = 0;
            btnBit.FlatStyle = FlatStyle.Flat;
            btnBit.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnBit.ForeColor = Color.White;
            btnBit.Location = new Point(782, 384);
            btnBit.Name = "btnBit";
            btnBit.Size = new Size(121, 53);
            btnBit.TabIndex = 5;
            btnBit.Text = "Бито";
            btnBit.UseVisualStyleBackColor = false;
            btnBit.Click += btnBit_Click;
            // 
            // btnTake
            // 
            btnTake.BackColor = Color.Transparent;
            btnTake.FlatAppearance.BorderSize = 0;
            btnTake.FlatStyle = FlatStyle.Flat;
            btnTake.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnTake.ForeColor = Color.White;
            btnTake.Location = new Point(782, 431);
            btnTake.Name = "btnTake";
            btnTake.Size = new Size(107, 47);
            btnTake.TabIndex = 6;
            btnTake.Text = "Взять";
            btnTake.UseVisualStyleBackColor = false;
            btnTake.Click += btnTake_Click;
            // 
            // btnNextTurn
            // 
            btnNextTurn.BackColor = Color.Transparent;
            btnNextTurn.FlatAppearance.BorderSize = 0;
            btnNextTurn.FlatStyle = FlatStyle.Flat;
            btnNextTurn.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnNextTurn.ForeColor = Color.White;
            btnNextTurn.Location = new Point(762, 484);
            btnNextTurn.Name = "btnNextTurn";
            btnNextTurn.Size = new Size(152, 50);
            btnNextTurn.TabIndex = 7;
            btnNextTurn.Text = "Дальше";
            btnNextTurn.UseVisualStyleBackColor = false;
            btnNextTurn.Click += btnNextTurn_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(663, 24);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 41);
            lblStatus.TabIndex = 8;
            // 
            // btn_ruls
            // 
            btn_ruls.BackColor = Color.Transparent;
            btn_ruls.FlatAppearance.BorderSize = 0;
            btn_ruls.FlatStyle = FlatStyle.Flat;
            btn_ruls.Location = new Point(69, 23);
            btn_ruls.Name = "btn_ruls";
            btn_ruls.Size = new Size(42, 40);
            btn_ruls.TabIndex = 9;
            btn_ruls.UseVisualStyleBackColor = false;
            btn_ruls.Click += btn_ruls_Click;
            // 
            // GameTableFormFor2Players
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.игровой_стол;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(961, 560);
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
            Text = "GameTableFormFor2Players";
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