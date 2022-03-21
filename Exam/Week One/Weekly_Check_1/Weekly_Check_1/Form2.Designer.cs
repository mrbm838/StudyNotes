namespace Weekly_Check_1
{
    partial class Form2
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
            this.btStartScan = new System.Windows.Forms.Button();
            this.lbBarcode = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btStartScan
            // 
            this.btStartScan.Location = new System.Drawing.Point(127, 57);
            this.btStartScan.Name = "btStartScan";
            this.btStartScan.Size = new System.Drawing.Size(177, 56);
            this.btStartScan.TabIndex = 0;
            this.btStartScan.Text = "扫码";
            this.btStartScan.UseVisualStyleBackColor = true;
            this.btStartScan.Click += new System.EventHandler(this.btStartScan_Click);
            // 
            // lbBarcode
            // 
            this.lbBarcode.FormattingEnabled = true;
            this.lbBarcode.ItemHeight = 18;
            this.lbBarcode.Location = new System.Drawing.Point(127, 132);
            this.lbBarcode.Name = "lbBarcode";
            this.lbBarcode.Size = new System.Drawing.Size(302, 220);
            this.lbBarcode.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbBarcode);
            this.Controls.Add(this.btStartScan);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStartScan;
        private System.Windows.Forms.ListBox lbBarcode;
    }
}