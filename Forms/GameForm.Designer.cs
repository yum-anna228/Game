using System;


namespace Game
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            btn_Game = new Button();
            btn_Rules = new Button();
            btn_language = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Game
            // 
            resources.ApplyResources(btn_Game, "btn_Game");
            btn_Game.BackColor = Color.Transparent;
            btn_Game.FlatAppearance.BorderSize = 0;
            btn_Game.ForeColor = Color.White;
            btn_Game.Name = "btn_Game";
            btn_Game.UseVisualStyleBackColor = false;
            btn_Game.Click += btn_Game_Click;
            // 
            // btn_Rules
            // 
            resources.ApplyResources(btn_Rules, "btn_Rules");
            btn_Rules.BackColor = Color.Transparent;
            btn_Rules.FlatAppearance.BorderSize = 0;
            btn_Rules.ForeColor = Color.White;
            btn_Rules.Name = "btn_Rules";
            btn_Rules.UseVisualStyleBackColor = false;
            btn_Rules.Click += btn_Rules_Click;
            // 
            // btn_language
            // 
            resources.ApplyResources(btn_language, "btn_language");
            btn_language.BackColor = Color.Transparent;
            btn_language.FlatAppearance.BorderSize = 0;
            btn_language.ForeColor = Color.White;
            btn_language.Name = "btn_language";
            btn_language.UseVisualStyleBackColor = false;
            btn_language.Click += btn_language_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.главное_окно;
            Controls.Add(label1);
            Controls.Add(btn_language);
            Controls.Add(btn_Rules);
            Controls.Add(btn_Game);
            DoubleBuffered = true;
            Name = "GameForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Game;
        private Button btn_Rules;
        private Button btn_language;
        private Label label1;
    }
}
