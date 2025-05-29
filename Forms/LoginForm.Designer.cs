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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btn_Login = new Button();
            btn_Registr = new Button();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
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
            // txtLogin
            // 
            txtLogin.Location = new Point(61, 157);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(674, 27);
            txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(65, 260);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(670, 27);
            txtPassword.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(btn_Registr);
            Controls.Add(btn_Login);
            DoubleBuffered = true;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private Button btn_Registr;
        private TextBox txtLogin;
        private TextBox txtPassword;
    }
}