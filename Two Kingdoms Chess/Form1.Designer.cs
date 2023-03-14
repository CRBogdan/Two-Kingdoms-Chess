namespace Two_Kingdoms_Chess
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            vsHuman = new Button();
            SuspendLayout();
            // 
            // vsHuman
            // 
            vsHuman.Location = new Point(12, 12);
            vsHuman.Name = "vsHuman";
            vsHuman.Size = new Size(94, 29);
            vsHuman.TabIndex = 0;
            vsHuman.Text = "Vs Human";
            vsHuman.UseVisualStyleBackColor = true;
            vsHuman.Click += vsHuman_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 567);
            Controls.Add(vsHuman);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button vsHuman;
    }
}