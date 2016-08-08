namespace RangeFinder
{
    partial class RangeFinderOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangeFinderOverlay));
            this.panHandle = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panHandle
            // 
            this.panHandle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panHandle.Location = new System.Drawing.Point(499, 450);
            this.panHandle.Name = "panHandle";
            this.panHandle.Size = new System.Drawing.Size(25, 23);
            this.panHandle.TabIndex = 1;
            this.panHandle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panHandle_MouseClick);
            this.panHandle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panHandle_MouseDown);
            // 
            // RangeFinderOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(720, 720);
            this.Controls.Add(this.panHandle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RangeFinderOverlay";
            this.Text = "Range Finder";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.RangeFinderOverlay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RangeFinderOverlay_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHandle;

    }
}

