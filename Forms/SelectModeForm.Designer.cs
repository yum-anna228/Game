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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectModeForm));
            btn_2players = new Button();
            btn_viewStatistics = new Button();
            btn_Exit = new Button();
            SuspendLayout();
            // 
            // btn_2players
            // 
            resources.ApplyResources(btn_2players, "btn_2players");
            btn_2players.BackColor = Color.Transparent;
            btn_2players.FlatAppearance.BorderSize = 0;
            btn_2players.ForeColor = Color.White;
            btn_2players.Name = "btn_2players";
            btn_2players.UseVisualStyleBackColor = false;
            btn_2players.Click += btn_2players_Click;
            // 
            // btn_viewStatistics
            // 
            resources.ApplyResources(btn_viewStatistics, "btn_viewStatistics");
            btn_viewStatistics.BackColor = Color.Transparent;
            btn_viewStatistics.FlatAppearance.BorderSize = 0;
            btn_viewStatistics.ForeColor = Color.White;
            btn_viewStatistics.Name = "btn_viewStatistics";
            btn_viewStatistics.UseVisualStyleBackColor = false;
            btn_viewStatistics.Click += btn_viewStatistics_Click;
            // 
            // btn_Exit
            // 
            resources.ApplyResources(btn_Exit, "btn_Exit");
            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.FlatAppearance.BorderSize = 0;
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Name = "btn_Exit";
            btn_Exit.UseVisualStyleBackColor = false;
            // 
            // SelectModeForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Снимок_экрана_2025_06_02_213959;
            Controls.Add(btn_Exit);
            Controls.Add(btn_viewStatistics);
            Controls.Add(btn_2players);
            DoubleBuffered = true;
            Name = "SelectModeForm";
            Load += SelectModeForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_2players;
        private Button btn_viewStatistics;
        private Button btn_Exit;
    }
}