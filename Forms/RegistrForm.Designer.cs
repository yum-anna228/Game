
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
            btn_Registr1.BackColor = Color.Transparent;
            btn_Registr1.FlatAppearance.BorderSize = 0;
            btn_Registr1.FlatStyle = FlatStyle.Flat;
            btn_Registr1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn_Registr1.ForeColor = Color.White;
            btn_Registr1.Location = new Point(224, 359);
            btn_Registr1.Name = "btn_Registr1";
            btn_Registr1.Size = new Size(357, 69);
            btn_Registr1.TabIndex = 0;
            btn_Registr1.Text = "Зарегистрироваться";
            btn_Registr1.UseVisualStyleBackColor = false;
            btn_Registr1.Click += btn_Registr1_Click;
            // 
            // btn_Enter1
            // 
            btn_Enter1.BackColor = Color.Transparent;
            btn_Enter1.FlatAppearance.BorderSize = 0;
            btn_Enter1.FlatStyle = FlatStyle.Flat;
            btn_Enter1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn_Enter1.ForeColor = Color.White;
            btn_Enter1.Location = new Point(653, 41);
            btn_Enter1.Name = "btn_Enter1";
            btn_Enter1.Size = new Size(111, 51);
            btn_Enter1.TabIndex = 1;
            btn_Enter1.Text = "Войти";
            btn_Enter1.UseVisualStyleBackColor = false;
            btn_Enter1.Click += btn_Enter1_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(123, 79, 53);
            txtPassword.Font = new Font("Montserrat Thin", 28.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPassword.ForeColor = SystemColors.Window;
            txtPassword.Location = new Point(60, 213);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(676, 66);
            txtPassword.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(123, 79, 53);
            txtConfirmPassword.Font = new Font("Montserrat Thin", 28.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtConfirmPassword.ForeColor = SystemColors.Window;
            txtConfirmPassword.Location = new Point(60, 307);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(676, 66);
            txtConfirmPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(123, 79, 53);
            txtUsername.Font = new Font("Montserrat Thin", 28.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUsername.ForeColor = SystemColors.Window;
            txtUsername.Location = new Point(60, 124);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(674, 66);
            txtUsername.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(399, 49);
            label1.Name = "label1";
            label1.Size = new Size(248, 38);
            label1.TabIndex = 6;
            label1.Text = "Уже есть аккаунт?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(60, 96);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 7;
            label2.Text = "Имя пользователя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(60, 185);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 8;
            label3.Text = "Пароль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.White;
            label4.Location = new Point(58, 279);
            label4.Name = "label4";
            label4.Size = new Size(165, 25);
            label4.TabIndex = 9;
            label4.Text = "Повторите пароль";
            // 
            // RegistrForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.фон;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
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
            Text = "RegistrForm";
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