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
            btn_3players = new Button();
            SuspendLayout();
            // 
            // btn_2players
            // 
            btn_2players.BackColor = Color.Transparent;
            btn_2players.FlatAppearance.BorderSize = 0;
            btn_2players.FlatStyle = FlatStyle.Flat;
            btn_2players.Location = new Point(171, 186);
            btn_2players.Name = "btn_2players";
            btn_2players.Size = new Size(189, 91);
            btn_2players.TabIndex = 0;
            btn_2players.UseVisualStyleBackColor = false;
            // 
            // btn_3players
            // 
            btn_3players.BackColor = Color.Transparent;
            btn_3players.FlatAppearance.BorderSize = 0;
            btn_3players.FlatStyle = FlatStyle.Flat;
            btn_3players.Location = new Point(426, 186);
            btn_3players.Name = "btn_3players";
            btn_3players.Size = new Size(209, 93);
            btn_3players.TabIndex = 1;
            btn_3players.UseVisualStyleBackColor = false;
            // 
            // SelectModeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_3players);
            Controls.Add(btn_2players);
            DoubleBuffered = true;
            Name = "SelectModeForm";
            Text = "SelectModeForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_2players;
        private Button btn_3players;
    }
}