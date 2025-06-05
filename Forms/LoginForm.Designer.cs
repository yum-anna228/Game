namespace Game
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btn_Login = new Button();
            btn_Registr = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip3 = new ContextMenuStrip(components);
            txtPassword = new TextBox();
            txtLogin = new TextBox();
            lbl_account = new Label();
            lbl_name = new Label();
            lbl_password = new Label();
            SuspendLayout();
            // 
            // btn_Login
            // 
            resources.ApplyResources(btn_Login, "btn_Login");
            btn_Login.BackColor = Color.Transparent;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.ForeColor = Color.White;
            btn_Login.Name = "btn_Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Registr
            // 
            resources.ApplyResources(btn_Registr, "btn_Registr");
            btn_Registr.BackColor = Color.Transparent;
            btn_Registr.FlatAppearance.BorderSize = 0;
            btn_Registr.ForeColor = Color.White;
            btn_Registr.Name = "btn_Registr";
            btn_Registr.UseVisualStyleBackColor = false;
            btn_Registr.Click += btn_Registr_Click;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // contextMenuStrip2
            // 
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            // 
            // contextMenuStrip3
            // 
            resources.ApplyResources(contextMenuStrip3, "contextMenuStrip3");
            contextMenuStrip3.ImageScalingSize = new Size(20, 20);
            contextMenuStrip3.Name = "contextMenuStrip3";
            // 
            // txtPassword
            // 
            resources.ApplyResources(txtPassword, "txtPassword");
            txtPassword.BackColor = Color.FromArgb(123, 79, 53);
            txtPassword.ForeColor = SystemColors.Window;
            txtPassword.Name = "txtPassword";
            // 
            // txtLogin
            // 
            resources.ApplyResources(txtLogin, "txtLogin");
            txtLogin.BackColor = Color.FromArgb(123, 79, 53);
            txtLogin.ForeColor = SystemColors.Window;
            txtLogin.Name = "txtLogin";
            // 
            // lbl_account
            // 
            resources.ApplyResources(lbl_account, "lbl_account");
            lbl_account.BackColor = Color.Transparent;
            lbl_account.ForeColor = Color.White;
            lbl_account.Name = "lbl_account";
            // 
            // lbl_name
            // 
            resources.ApplyResources(lbl_name, "lbl_name");
            lbl_name.BackColor = Color.Transparent;
            lbl_name.ForeColor = Color.White;
            lbl_name.Name = "lbl_name";
            // 
            // lbl_password
            // 
            resources.ApplyResources(lbl_password, "lbl_password");
            lbl_password.BackColor = Color.Transparent;
            lbl_password.ForeColor = Color.White;
            lbl_password.Name = "lbl_password";
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.фон;
            Controls.Add(lbl_name);
            Controls.Add(lbl_account);
            Controls.Add(txtLogin);
            Controls.Add(txtPassword);
            Controls.Add(btn_Registr);
            Controls.Add(btn_Login);
            Controls.Add(lbl_password);
            DoubleBuffered = true;
            Name = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private Button btn_Registr;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ContextMenuStrip contextMenuStrip3;
        private TextBox txtPassword;
        private TextBox txtLogin;
        private Label lbl_account;
        private Label lbl_name;
        private Label lbl_password;
        //private TransparentHintedTextBox txtLogin;
        //private TransparentHintedTextBox txtPassword;
    }
}