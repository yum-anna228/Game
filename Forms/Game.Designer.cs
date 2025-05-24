using System;


namespace Game
{
    partial class Game
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
            btn_Game = new Button();
            btn_Rules = new Button();
            btn_language = new Button();
            SuspendLayout();
            // 
            // btn_Game
            // 
            btn_Game.BackColor = Color.Transparent;
            btn_Game.FlatAppearance.BorderSize = 0;
            btn_Game.FlatStyle = FlatStyle.Flat;
            btn_Game.Location = new Point(342, 296);
            btn_Game.Name = "btn_Game";
            btn_Game.Size = new Size(113, 44);
            btn_Game.TabIndex = 0;
            btn_Game.UseVisualStyleBackColor = false;
            // 
            // btn_Rules
            // 
            btn_Rules.BackColor = Color.Transparent;
            btn_Rules.FlatAppearance.BorderSize = 0;
            btn_Rules.FlatStyle = FlatStyle.Flat;
            btn_Rules.Location = new Point(326, 336);
            btn_Rules.Name = "btn_Rules";
            btn_Rules.Size = new Size(145, 48);
            btn_Rules.TabIndex = 1;
            btn_Rules.UseVisualStyleBackColor = false;
            // 
            // btn_language
            // 
            btn_language.BackColor = Color.Transparent;
            btn_language.FlatAppearance.BorderSize = 0;
            btn_language.FlatStyle = FlatStyle.Flat;
            btn_language.Location = new Point(18, 390);
            btn_language.Name = "btn_language";
            btn_language.Size = new Size(94, 48);
            btn_language.TabIndex = 2;
            btn_language.UseVisualStyleBackColor = false;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.главная_форма;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_language);
            Controls.Add(btn_Rules);
            Controls.Add(btn_Game);
            DoubleBuffered = true;
            Name = "Game";
            Text = "Game";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Game;
        private Button btn_Rules;
        private Button btn_language;
    }
}
