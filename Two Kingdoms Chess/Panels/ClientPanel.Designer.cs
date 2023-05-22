namespace Two_Kingdoms_Chess
{
    partial class ClientPanel
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
            ipAddress = new TextBox();
            label1 = new Label();
            connect = new Button();
            SuspendLayout();
            // 
            // ipAddress
            // 
            ipAddress.Location = new Point(3, 23);
            ipAddress.Name = "ipAddress";
            ipAddress.Size = new Size(340, 27);
            ipAddress.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "IP Address";
            // 
            // connect
            // 
            connect.Location = new Point(3, 56);
            connect.Name = "connect";
            connect.Size = new Size(94, 29);
            connect.TabIndex = 4;
            connect.Text = "Connect";
            connect.UseVisualStyleBackColor = true;
            connect.Click += connect_Click;
            // 
            // ClientPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(connect);
            Controls.Add(label1);
            Controls.Add(ipAddress);
            Name = "ClientPanel";
            Size = new Size(700, 700);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ipAddress;
        private Label label1;
        private Button connect;
    }
}
