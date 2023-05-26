namespace Two_Kingdoms_Chess
{
    partial class MainMenu
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
            button1 = new Button();
            server = new Button();
            client = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Vs Human";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // server
            // 
            server.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            server.Location = new Point(3, 38);
            server.Name = "server";
            server.Size = new Size(94, 29);
            server.TabIndex = 2;
            server.Text = "Server";
            server.UseVisualStyleBackColor = true;
            server.Click += server_Click;
            // 
            // client
            // 
            client.Location = new Point(3, 73);
            client.Name = "client";
            client.Size = new Size(94, 29);
            client.TabIndex = 3;
            client.Text = "Client";
            client.UseVisualStyleBackColor = true;
            client.Click += client_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(client);
            Controls.Add(server);
            Controls.Add(button1);
            Name = "MainMenu";
            Size = new Size(700, 700);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button server;
        private Button client;
    }
}
