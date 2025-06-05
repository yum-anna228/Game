
namespace Game
{
    partial class RegistrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrForm));
            btn_Registr1 = new Button();
            btn_Enter1 = new Button();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btn_Registr1
            // 
            resources.ApplyResources(btn_Registr1, "btn_Registr1");
            btn_Registr1.BackColor = Color.Transparent;
            btn_Registr1.FlatAppearance.BorderSize = 0;
            btn_Registr1.ForeColor = Color.White;
            btn_Registr1.Name = "btn_Registr1";
            btn_Registr1.UseVisualStyleBackColor = false;
            btn_Registr1.Click += btn_Registr1_Click;
            // 
            // btn_Enter1
            // 
            resources.ApplyResources(btn_Enter1, "btn_Enter1");
            btn_Enter1.BackColor = Color.Transparent;
            btn_Enter1.FlatAppearance.BorderSize = 0;
            btn_Enter1.ForeColor = Color.White;
            btn_Enter1.Name = "btn_Enter1";
            btn_Enter1.UseVisualStyleBackColor = false;
            btn_Enter1.Click += btn_Enter1_Click;
            // 
            // txtPassword
            // 
            resources.ApplyResources(txtPassword, "txtPassword");
            txtPassword.BackColor = Color.FromArgb(123, 79, 53);
            txtPassword.ForeColor = SystemColors.Window;
            txtPassword.Name = "txtPassword";
            // 
            // txtConfirmPassword
            // 
            resources.ApplyResources(txtConfirmPassword, "txtConfirmPassword");
            txtConfirmPassword.BackColor = Color.FromArgb(123, 79, 53);
            txtConfirmPassword.ForeColor = SystemColors.Window;
            txtConfirmPassword.Name = "txtConfirmPassword";
            // 
            // txtUsername
            // 
            resources.ApplyResources(txtUsername, "txtUsername");
            txtUsername.BackColor = Color.FromArgb(123, 79, 53);
            txtUsername.ForeColor = SystemColors.Window;
            txtUsername.Name = "txtUsername";
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
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Name = "label4";
            // 
            // RegistrForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.фон;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(btn_Enter1);
            Controls.Add(btn_Registr1);
            Controls.Add(label3);
            Controls.Add(label4);
            DoubleBuffered = true;
            Name = "RegistrForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Registr1;
        private Button btn_Enter1;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}