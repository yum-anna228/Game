namespace Game
{
    partial class RuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleForm));
            lbl_rule = new Label();
            SuspendLayout();
            // 
            // lbl_rule
            // 
            lbl_rule.AutoSize = true;
            lbl_rule.BackColor = Color.Transparent;
            lbl_rule.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_rule.ForeColor = Color.White;
            lbl_rule.Location = new Point(52, 37);
            lbl_rule.Name = "lbl_rule";
            lbl_rule.Size = new Size(127, 38);
            lbl_rule.TabIndex = 0;
            lbl_rule.Text = "Правила";
            // 
            // RuleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_rule);
            DoubleBuffered = true;
            Name = "RuleForm";
            Text = "RuleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_rule;
    }
}