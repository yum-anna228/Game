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
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(23, 12);
            button1.Name = "button1";
            button1.Size = new Size(41, 39);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanelOpponentCards
            // 
            flowLayoutPanelOpponentCards.BackColor = Color.Transparent;
            flowLayoutPanelOpponentCards.Location = new Point(288, 24);
            flowLayoutPanelOpponentCards.Name = "flowLayoutPanelOpponentCards";
            flowLayoutPanelOpponentCards.Size = new Size(303, 111);
            flowLayoutPanelOpponentCards.TabIndex = 1;
            // 
            // flowLayoutPanelYourCards
            // 
            flowLayoutPanelYourCards.BackColor = Color.Transparent;
            flowLayoutPanelYourCards.Location = new Point(183, 356);
            flowLayoutPanelYourCards.Name = "flowLayoutPanelYourCards";
            flowLayoutPanelYourCards.Size = new Size(480, 150);
            flowLayoutPanelYourCards.TabIndex = 2;
            // 
            // flowLayoutPanelTable
            // 
            flowLayoutPanelTable.BackColor = Color.Transparent;
            flowLayoutPanelTable.Location = new Point(200, 141);
            flowLayoutPanelTable.Name = "flowLayoutPanelTable";
            flowLayoutPanelTable.Size = new Size(463, 209);
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
            btnBit.Location = new Point(702, 356);
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
            btnTake.Location = new Point(716, 399);
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
            btnNextTurn.Location = new Point(695, 441);
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
            // GameTableFormFor2Players
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.игровой_стол;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(880, 518);
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