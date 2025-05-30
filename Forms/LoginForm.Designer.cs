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
            SuspendLayout();
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Transparent;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Location = new Point(293, 340);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(181, 73);
            btn_Login.TabIndex = 0;
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Registr
            // 
            btn_Registr.BackColor = Color.Transparent;
            btn_Registr.FlatAppearance.BorderSize = 0;
            btn_Registr.FlatStyle = FlatStyle.Flat;
            btn_Registr.Location = new Point(536, 80);
            btn_Registr.Name = "btn_Registr";
            btn_Registr.Size = new Size(210, 47);
            btn_Registr.TabIndex = 1;
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
            txtPassword.Location = new Point(63, 238);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Пароль";
            txtPassword.Size = new Size(683, 66);
            txtPassword.TabIndex = 3;
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.FromArgb(123, 79, 53);
            txtLogin.Font = new Font("Montserrat Thin", 28.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLogin.ForeColor = SystemColors.Window;
            txtLogin.Location = new Point(63, 133);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Имя пользователя";
            txtLogin.Size = new Size(683, 66);
            txtLogin.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(txtLogin);
            Controls.Add(txtPassword);
            Controls.Add(btn_Registr);
            Controls.Add(btn_Login);
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
        //private TransparentHintedTextBox txtLogin;
        //private TransparentHintedTextBox txtPassword;
    }
}