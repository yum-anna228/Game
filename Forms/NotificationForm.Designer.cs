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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnExit = new Button();
            btn_Stay = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(201, 122);
            label1.Name = "label1";
            label1.Size = new Size(416, 37);
            label1.TabIndex = 0;
            label1.Text = "Вы уверены, что хотите выйти?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.White;
            label2.Location = new Point(255, 159);
            label2.Name = "label2";
            label2.Size = new Size(318, 38);
            label2.TabIndex = 1;
            label2.Text = "Это приведет к вашему";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.White;
            label3.Location = new Point(235, 197);
            label3.Name = "label3";
            label3.Size = new Size(363, 38);
            label3.TabIndex = 2;
            label3.Text = "проигрышу автоматически";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(174, 309);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(135, 60);
            btnExit.TabIndex = 3;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btn_Stay
            // 
            btn_Stay.BackColor = Color.Transparent;
            btn_Stay.FlatAppearance.BorderSize = 0;
            btn_Stay.FlatStyle = FlatStyle.Flat;
            btn_Stay.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btn_Stay.ForeColor = Color.White;
            btn_Stay.Location = new Point(493, 302);
            btn_Stay.Name = "btn_Stay";
            btn_Stay.Size = new Size(171, 74);
            btn_Stay.TabIndex = 4;
            btn_Stay.Text = "Остаться";
            btn_Stay.UseVisualStyleBackColor = false;
            btn_Stay.Click += btn_Stay_Click;
            // 
            // Notification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Снимок_экрана_2025_06_02_213959;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Stay);
            Controls.Add(btnExit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Notification";
            Text = "Notification";
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