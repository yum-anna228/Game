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
            btn_Enter = new Button();
            btn_Registr = new Button();
            SuspendLayout();
            // 
            // btn_Enter
            // 
            btn_Enter.BackColor = Color.Transparent;
            btn_Enter.FlatAppearance.BorderSize = 0;
            btn_Enter.FlatStyle = FlatStyle.Flat;
            btn_Enter.Location = new Point(293, 340);
            btn_Enter.Name = "btn_Enter";
            btn_Enter.Size = new Size(181, 73);
            btn_Enter.TabIndex = 0;
            btn_Enter.UseVisualStyleBackColor = false;
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
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Registr);
            Controls.Add(btn_Enter);
            DoubleBuffered = true;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Enter;
        private Button btn_Registr;
    }
}