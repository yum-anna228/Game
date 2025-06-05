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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinningForm));
            lbl_Ura = new Label();
            lbl_winner = new Label();
            btn_NewGame = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lbl_Ura
            // 
            resources.ApplyResources(lbl_Ura, "lbl_Ura");
            lbl_Ura.BackColor = Color.Transparent;
            lbl_Ura.ForeColor = Color.White;
            lbl_Ura.Name = "lbl_Ura";
            // 
            // lbl_winner
            // 
            resources.ApplyResources(lbl_winner, "lbl_winner");
            lbl_winner.BackColor = Color.Transparent;
            lbl_winner.ForeColor = Color.White;
            lbl_winner.Name = "lbl_winner";
            // 
            // btn_NewGame
            // 
            resources.ApplyResources(btn_NewGame, "btn_NewGame");
            btn_NewGame.BackColor = Color.Transparent;
            btn_NewGame.FlatAppearance.BorderSize = 0;
            btn_NewGame.ForeColor = Color.White;
            btn_NewGame.Name = "btn_NewGame";
            btn_NewGame.UseVisualStyleBackColor = false;
            btn_NewGame.Click += btn_NewGame_Click;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.White;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // WinningForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Снимок_экрана_2025_06_02_213959;
            Controls.Add(button1);
            Controls.Add(btn_NewGame);
            Controls.Add(lbl_winner);
            Controls.Add(lbl_Ura);
            DoubleBuffered = true;
            Name = "WinningForm";
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