namespace Game
{
    partial class WinningForm
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
            lbl_Ura = new Label();
            lbl_winner = new Label();
            btn_NewGame = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lbl_Ura
            // 
            lbl_Ura.AutoSize = true;
            lbl_Ura.BackColor = Color.Transparent;
            lbl_Ura.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_Ura.ForeColor = Color.White;
            lbl_Ura.Location = new Point(297, 94);
            lbl_Ura.Name = "lbl_Ura";
            lbl_Ura.Size = new Size(0, 106);
            lbl_Ura.TabIndex = 0;
            // 
            // lbl_winner
            // 
            lbl_winner.AutoSize = true;
            lbl_winner.BackColor = Color.Transparent;
            lbl_winner.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_winner.ForeColor = Color.White;
            lbl_winner.Location = new Point(22, 207);
            lbl_winner.Name = "lbl_winner";
            lbl_winner.Size = new Size(0, 54);
            lbl_winner.TabIndex = 1;
            // 
            // btn_NewGame
            // 
            btn_NewGame.Anchor = AnchorStyles.Bottom;
            btn_NewGame.BackColor = Color.Transparent;
            btn_NewGame.FlatAppearance.BorderSize = 0;
            btn_NewGame.FlatStyle = FlatStyle.Flat;
            btn_NewGame.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn_NewGame.ForeColor = Color.White;
            btn_NewGame.Location = new Point(314, 301);
            btn_NewGame.Name = "btn_NewGame";
            btn_NewGame.Size = new Size(204, 48);
            btn_NewGame.TabIndex = 2;
            btn_NewGame.Text = "Новая игра";
            btn_NewGame.UseVisualStyleBackColor = false;
            btn_NewGame.Click += btn_NewGame_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.White;
            button1.Location = new Point(317, 355);
            button1.Name = "button1";
            button1.Size = new Size(201, 83);
            button1.TabIndex = 3;
            button1.Text = "Статистика";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // WinningForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Снимок_экрана_2025_06_02_213959;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btn_NewGame);
            Controls.Add(lbl_winner);
            Controls.Add(lbl_Ura);
            DoubleBuffered = true;
            Name = "WinningForm";
            Text = "WinningForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Ura;
        private Label lbl_winner;
        private Button btn_NewGame;
        private Button button1;
    }
}