namespace Game
{
    partial class SelectModeForm
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
            btn_2players = new Button();
            btn_viewStatistics = new Button();
            btn_Exit = new Button();
            SuspendLayout();
            // 
            // btn_2players
            // 
            btn_2players.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_2players.BackColor = Color.Transparent;
            btn_2players.FlatAppearance.BorderSize = 0;
            btn_2players.FlatStyle = FlatStyle.Flat;
            btn_2players.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            btn_2players.ForeColor = Color.White;
            btn_2players.Location = new Point(187, 124);
            btn_2players.Name = "btn_2players";
            btn_2players.Size = new Size(409, 91);
            btn_2players.TabIndex = 0;
            btn_2players.Text = "Новая игра";
            btn_2players.UseVisualStyleBackColor = false;
            btn_2players.Click += btn_2players_Click;
            // 
            // btn_viewStatistics
            // 
            btn_viewStatistics.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_viewStatistics.BackColor = Color.Transparent;
            btn_viewStatistics.FlatAppearance.BorderSize = 0;
            btn_viewStatistics.FlatStyle = FlatStyle.Flat;
            btn_viewStatistics.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn_viewStatistics.ForeColor = Color.White;
            btn_viewStatistics.Location = new Point(152, 221);
            btn_viewStatistics.Name = "btn_viewStatistics";
            btn_viewStatistics.Size = new Size(518, 52);
            btn_viewStatistics.TabIndex = 2;
            btn_viewStatistics.Text = "Посмотреть мою статистику";
            btn_viewStatistics.UseVisualStyleBackColor = false;
            btn_viewStatistics.Click += btn_viewStatistics_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.FlatAppearance.BorderSize = 0;
            btn_Exit.FlatStyle = FlatStyle.Flat;
            btn_Exit.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Location = new Point(414, 369);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(342, 47);
            btn_Exit.TabIndex = 3;
            btn_Exit.Text = "Выйти из аккаунта";
            btn_Exit.UseVisualStyleBackColor = false;
            // 
            // SelectModeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Снимок_экрана_2025_06_02_213959;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Exit);
            Controls.Add(btn_viewStatistics);
            Controls.Add(btn_2players);
            DoubleBuffered = true;
            Name = "SelectModeForm";
            Text = "SelectModeForm";
            Load += SelectModeForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_2players;
        private Button btn_viewStatistics;
        private Button btn_Exit;
    }
}