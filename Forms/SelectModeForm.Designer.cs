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
            btn_2gamers = new Button();
            SuspendLayout();
            // 
            // btn_2gamers
            // 
            btn_2gamers.BackColor = Color.Transparent;
            btn_2gamers.FlatAppearance.BorderSize = 0;
            btn_2gamers.FlatStyle = FlatStyle.Flat;
            btn_2gamers.Location = new Point(171, 186);
            btn_2gamers.Name = "btn_2gamers";
            btn_2gamers.Size = new Size(189, 91);
            btn_2gamers.TabIndex = 0;
            btn_2gamers.UseVisualStyleBackColor = false;
            // 
            // SelectModeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_2gamers);
            DoubleBuffered = true;
            Name = "SelectModeForm";
            Text = "SelectModeForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_2gamers;
    }
}