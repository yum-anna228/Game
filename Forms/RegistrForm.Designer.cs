
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
            SuspendLayout();
            // 
            // btn_Registr1
            // 
            btn_Registr1.BackColor = Color.Transparent;
            btn_Registr1.FlatAppearance.BorderSize = 0;
            btn_Registr1.FlatStyle = FlatStyle.Flat;
            btn_Registr1.Location = new Point(224, 359);
            btn_Registr1.Name = "btn_Registr1";
            btn_Registr1.Size = new Size(357, 69);
            btn_Registr1.TabIndex = 0;
            btn_Registr1.UseVisualStyleBackColor = false;
            btn_Registr1.Click += btn_Registr1_Click;
            // 
            // btn_Enter1
            // 
            btn_Enter1.BackColor = Color.Transparent;
            btn_Enter1.FlatAppearance.BorderSize = 0;
            btn_Enter1.FlatStyle = FlatStyle.Flat;
            btn_Enter1.Location = new Point(653, 41);
            btn_Enter1.Name = "btn_Enter1";
            btn_Enter1.Size = new Size(94, 38);
            btn_Enter1.TabIndex = 1;
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
            txtConfirmPassword.Location = new Point(60, 301);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(676, 66);
            txtConfirmPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(123, 79, 53);
            txtUsername.Font = new Font("Montserrat Thin", 28.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUsername.Location = new Point(60, 124);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(674, 66);
            txtUsername.TabIndex = 5;
            // 
            // RegistrForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(txtUsername);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(btn_Enter1);
            Controls.Add(btn_Registr1);
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
    }
}