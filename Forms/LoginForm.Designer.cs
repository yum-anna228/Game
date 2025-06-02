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
            btn_Login.BackColor = Color.Transparent;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(310, 341);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(181, 73);
            btn_Login.TabIndex = 0;
            btn_Login.Text = "Войти";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Registr
            // 
            btn_Registr.BackColor = Color.Transparent;
            btn_Registr.FlatAppearance.BorderSize = 0;
            btn_Registr.FlatStyle = FlatStyle.Flat;
            btn_Registr.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn_Registr.ForeColor = Color.White;
            btn_Registr.Location = new Point(478, 77);
            btn_Registr.Name = "btn_Registr";
            btn_Registr.Size = new Size(323, 47);
            btn_Registr.TabIndex = 1;
            btn_Registr.Text = "Зарегистрироваться";
            btn_Registr.UseVisualStyleBackColor = false;
            btn_Registr.Click += btn_Registr_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.ImageScalingSize = new Size(20, 20);
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(61, 4);
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(123, 79, 53);
            txtPassword.Font = new Font("Montserrat Thin", 28.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPassword.ForeColor = SystemColors.Window;
            txtPassword.Location = new Point(55, 242);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(691, 66);
            txtPassword.TabIndex = 3;
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.FromArgb(123, 79, 53);
            txtLogin.Font = new Font("Montserrat Thin", 28.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLogin.ForeColor = SystemColors.Window;
            txtLogin.Location = new Point(55, 147);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(691, 66);
            txtLogin.TabIndex = 3;
            // 
            // lbl_account
            // 
            lbl_account.AutoSize = true;
            lbl_account.BackColor = Color.Transparent;
            lbl_account.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_account.ForeColor = Color.White;
            lbl_account.Location = new Point(287, 83);
            lbl_account.Name = "lbl_account";
            lbl_account.Size = new Size(195, 38);
            lbl_account.TabIndex = 4;
            lbl_account.Text = "Нет аккаунта?";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.BackColor = Color.Transparent;
            lbl_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_name.ForeColor = Color.White;
            lbl_name.Location = new Point(55, 116);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(182, 28);
            lbl_name.TabIndex = 5;
            lbl_name.Text = "Имя пользователя";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.BackColor = Color.Transparent;
            lbl_password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lbl_password.ForeColor = Color.White;
            lbl_password.Location = new Point(55, 211);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(81, 28);
            lbl_password.TabIndex = 6;
            lbl_password.Text = "Пароль";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_name);
            Controls.Add(lbl_account);
            Controls.Add(txtLogin);
            Controls.Add(txtPassword);
            Controls.Add(btn_Registr);
            Controls.Add(btn_Login);
            Controls.Add(lbl_password);
            DoubleBuffered = true;
            Name = "LoginForm";
            Text = "Вход";
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