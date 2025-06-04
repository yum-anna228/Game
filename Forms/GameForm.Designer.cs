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
            btn_Game = new Button();
            btn_Rules = new Button();
            btn_language = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Game
            // 
            btn_Game.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Game.BackColor = Color.Transparent;
            btn_Game.FlatAppearance.BorderSize = 0;
            btn_Game.FlatStyle = FlatStyle.Flat;
            btn_Game.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn_Game.ForeColor = Color.White;
            btn_Game.Location = new Point(396, 352);
            btn_Game.Name = "btn_Game";
            btn_Game.Size = new Size(141, 51);
            btn_Game.TabIndex = 0;
            btn_Game.Text = "Играть";
            btn_Game.UseVisualStyleBackColor = false;
            btn_Game.Click += btn_Game_Click;
            // 
            // btn_Rules
            // 
            btn_Rules.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Rules.BackColor = Color.Transparent;
            btn_Rules.FlatAppearance.BorderSize = 0;
            btn_Rules.FlatStyle = FlatStyle.Flat;
            btn_Rules.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn_Rules.ForeColor = Color.White;
            btn_Rules.Location = new Point(396, 409);
            btn_Rules.Name = "btn_Rules";
            btn_Rules.Size = new Size(145, 48);
            btn_Rules.TabIndex = 1;
            btn_Rules.Text = "Правила";
            btn_Rules.UseVisualStyleBackColor = false;
            // 
            // btn_language
            // 
            btn_language.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_language.BackColor = Color.Transparent;
            btn_language.FlatAppearance.BorderSize = 0;
            btn_language.FlatStyle = FlatStyle.Flat;
            btn_language.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn_language.ForeColor = Color.White;
            btn_language.Location = new Point(25, 448);
            btn_language.Name = "btn_language";
            btn_language.Size = new Size(94, 48);
            btn_language.TabIndex = 2;
            btn_language.Text = "ENG";
            btn_language.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("NSimSun", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(242, 186);
            label1.Name = "label1";
            label1.Size = new Size(439, 80);
            label1.TabIndex = 3;
            label1.Text = "Дурак";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.главное_окно;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(901, 523);
            Controls.Add(label1);
            Controls.Add(btn_language);
            Controls.Add(btn_Rules);
            Controls.Add(btn_Game);
            DoubleBuffered = true;
            Name = "GameForm";
            Text = "Game";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Game;
        private Button btn_Rules;
        private Button btn_language;
        private Label label1;
    }
}
