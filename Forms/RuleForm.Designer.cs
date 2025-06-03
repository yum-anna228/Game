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
            label1 = new Label();
            SuspendLayout();
            // 
            // lbl_rule
            // 
            lbl_rule.AutoSize = true;
            lbl_rule.BackColor = Color.Transparent;
            lbl_rule.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_rule.ForeColor = Color.White;
            lbl_rule.Location = new Point(58, 43);
            lbl_rule.Name = "lbl_rule";
            lbl_rule.Size = new Size(127, 38);
            lbl_rule.TabIndex = 0;
            lbl_rule.Text = "Правила";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(72, 98);
            label1.Name = "label1";
            label1.Size = new Size(657, 322);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // RuleForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(900, 518);
            Controls.Add(label1);
            Controls.Add(lbl_rule);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "RuleForm";
            Text = "RuleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_rule;
        private Label label1;
    }
}