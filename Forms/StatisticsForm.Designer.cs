namespace Game
{
    partial class StatisticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            label1 = new Label();
            flowLayoutPanelStats = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // flowLayoutPanelStats
            // 
            resources.ApplyResources(flowLayoutPanelStats, "flowLayoutPanelStats");
            flowLayoutPanelStats.BackColor = Color.Transparent;
            flowLayoutPanelStats.ForeColor = Color.White;
            flowLayoutPanelStats.Name = "flowLayoutPanelStats";
            // 
            // StatisticsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanelStats);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StatisticsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanelStats;
    }
}