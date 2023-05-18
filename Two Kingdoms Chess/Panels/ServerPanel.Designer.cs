namespace Two_Kingdoms_Chess
{
    partial class ServerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IP = new Label();
            SuspendLayout();
            // 
            // IP
            // 
            IP.AutoSize = true;
            IP.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            IP.Location = new Point(3, 0);
            IP.Name = "IP";
            IP.Size = new Size(43, 41);
            IP.TabIndex = 0;
            IP.Text = "IP";
            // 
            // ServerPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(IP);
            Name = "ServerPanel";
            Size = new Size(700, 608);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IP;
    }
}
