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
            resources.ApplyResources(lbl_rule, "lbl_rule");
            lbl_rule.BackColor = Color.Transparent;
            lbl_rule.ForeColor = Color.White;
            lbl_rule.Name = "lbl_rule";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // RuleForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(lbl_rule);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RuleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_rule;
        private Label label1;
    }
}