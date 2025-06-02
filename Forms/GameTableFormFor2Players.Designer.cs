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
            button1 = new Button();
            flowLayoutPanelOpponentCards = new FlowLayoutPanel();
            flowLayoutPanelYourCards = new FlowLayoutPanel();
            flowLayoutPanelTable = new FlowLayoutPanel();
            lblTrumpSuit = new Label();
            btnBit = new Button();
            btnTake = new Button();
            btnNextTurn = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(18, 12);
            button1.Name = "button1";
            button1.Size = new Size(41, 39);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelOpponentCards
            // 
            flowLayoutPanelOpponentCards.Location = new Point(288, 24);
            flowLayoutPanelOpponentCards.Name = "flowLayoutPanelOpponentCards";
            flowLayoutPanelOpponentCards.Size = new Size(184, 79);
            flowLayoutPanelOpponentCards.TabIndex = 1;
            // 
            // flowLayoutPanelYourCards
            // 
            flowLayoutPanelYourCards.Location = new Point(289, 346);
            flowLayoutPanelYourCards.Name = "flowLayoutPanelYourCards";
            flowLayoutPanelYourCards.Size = new Size(183, 81);
            flowLayoutPanelYourCards.TabIndex = 2;
            // 
            // flowLayoutPanelTable
            // 
            flowLayoutPanelTable.Location = new Point(192, 124);
            flowLayoutPanelTable.Name = "flowLayoutPanelTable";
            flowLayoutPanelTable.Size = new Size(405, 194);
            flowLayoutPanelTable.TabIndex = 3;
            // 
            // lblTrumpSuit
            // 
            lblTrumpSuit.AutoSize = true;
            lblTrumpSuit.Location = new Point(628, 52);
            lblTrumpSuit.Name = "lblTrumpSuit";
            lblTrumpSuit.Size = new Size(50, 20);
            lblTrumpSuit.TabIndex = 4;
            lblTrumpSuit.Text = "label1";
            // 
            // btnBit
            // 
            btnBit.BackColor = Color.Transparent;
            btnBit.FlatAppearance.BorderSize = 0;
            btnBit.FlatStyle = FlatStyle.Flat;
            btnBit.Location = new Point(546, 345);
            btnBit.Name = "btnBit";
            btnBit.Size = new Size(94, 29);
            btnBit.TabIndex = 5;
            btnBit.UseVisualStyleBackColor = false;
            btnBit.Click += btnBit_Click;
            // 
            // btnTake
            // 
            btnTake.BackColor = Color.Transparent;
            btnTake.FlatAppearance.BorderSize = 0;
            btnTake.FlatStyle = FlatStyle.Flat;
            btnTake.Location = new Point(546, 370);
            btnTake.Name = "btnTake";
            btnTake.Size = new Size(94, 29);
            btnTake.TabIndex = 6;
            btnTake.UseVisualStyleBackColor = false;
            btnTake.Click += btnTake_Click;
            // 
            // btnNextTurn
            // 
            btnNextTurn.BackColor = Color.Transparent;
            btnNextTurn.FlatAppearance.BorderSize = 0;
            btnNextTurn.FlatStyle = FlatStyle.Flat;
            btnNextTurn.Location = new Point(539, 401);
            btnNextTurn.Name = "btnNextTurn";
            btnNextTurn.Size = new Size(107, 29);
            btnNextTurn.TabIndex = 7;
            btnNextTurn.UseVisualStyleBackColor = false;
            btnNextTurn.Click += btnNextTurn_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(69, 91);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "label1";
            // 
            // GameTableFormFor2Players
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(btnNextTurn);
            Controls.Add(btnTake);
            Controls.Add(btnBit);
            Controls.Add(lblTrumpSuit);
            Controls.Add(flowLayoutPanelTable);
            Controls.Add(flowLayoutPanelYourCards);
            Controls.Add(flowLayoutPanelOpponentCards);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "GameTableFormFor2Players";
            Text = "GameTableFormFor2Players";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private FlowLayoutPanel flowLayoutPanelOpponentCards;
        private FlowLayoutPanel flowLayoutPanelYourCards;
        private FlowLayoutPanel flowLayoutPanelTable;
        private Label lblTrumpSuit;
        private Button btnBit;
        private Button btnTake;
        private Button btnNextTurn;
        private Label lblStatus;
    }
}