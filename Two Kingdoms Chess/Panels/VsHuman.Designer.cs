namespace Two_Kingdoms_Chess
{
    partial class VsHuman
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
            pieces = new ListView();
            SuspendLayout();
            // 
            // pieces
            // 
            pieces.Location = new Point(3, 3);
            pieces.Name = "pieces";
            pieces.Size = new Size(917, 182);
            pieces.TabIndex = 0;
            pieces.UseCompatibleStateImageBehavior = false;
            // 
            // VsHuman
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            Controls.Add(pieces);
            Name = "VsHuman";
            Size = new Size(923, 592);
            ResumeLayout(false);
        }

        #endregion

        private ListView pieces;
    }
}
