namespace Game
{
    partial class NotificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnExit = new Button();
            btn_Stay = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label3.Name = "label3";
            // 
            // btnExit
            // 
            resources.ApplyResources(btnExit, "btnExit");
            btnExit.BackColor = Color.Transparent;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.ForeColor = Color.White;
            btnExit.Name = "btnExit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btn_Stay
            // 
            resources.ApplyResources(btn_Stay, "btn_Stay");
            btn_Stay.BackColor = Color.Transparent;
            btn_Stay.FlatAppearance.BorderSize = 0;
            btn_Stay.ForeColor = Color.White;
            btn_Stay.Name = "btn_Stay";
            btn_Stay.UseVisualStyleBackColor = false;
            btn_Stay.Click += btn_Stay_Click;
            // 
            // NotificationForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Снимок_экрана_2025_06_02_213959;
            Controls.Add(btn_Stay);
            Controls.Add(btnExit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "NotificationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnExit;
        private Button btn_Stay;
    }
}