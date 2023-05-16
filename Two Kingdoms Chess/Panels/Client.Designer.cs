namespace Two_Kingdoms_Chess.Panels
{
    partial class Client
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
            label2 = new Label();
            port = new TextBox();
            connect = new Button();
            SuspendLayout();
            // 
            // ipAddress
            // 
            ipAddress.Location = new Point(148, 328);
            ipAddress.Name = "ipAddress";
            ipAddress.Size = new Size(340, 27);
            ipAddress.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(296, 305);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "IP Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 358);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // port
            // 
            port.Location = new Point(148, 381);
            port.Name = "port";
            port.Size = new Size(340, 27);
            port.TabIndex = 2;
            // 
            // connect
            // 
            connect.Location = new Point(275, 414);
            connect.Name = "connect";
            connect.Size = new Size(94, 29);
            connect.TabIndex = 4;
            connect.Text = "Connect";
            connect.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(connect);
            Controls.Add(label2);
            Controls.Add(port);
            Controls.Add(label1);
            Controls.Add(ipAddress);
            Name = "Client";
            Size = new Size(700, 700);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ipAddress;
        private Label label1;
        private Label label2;
        private TextBox port;
        private Button connect;
    }
}
