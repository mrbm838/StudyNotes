namespace Weekly_Check_2
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
            this.btScan = new System.Windows.Forms.Button();
            this.tBBarcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btScan
            // 
            this.btScan.Location = new System.Drawing.Point(88, 49);
            this.btScan.Name = "btScan";
            this.btScan.Size = new System.Drawing.Size(155, 76);
            this.btScan.TabIndex = 0;
            this.btScan.Text = "扫码";
            this.btScan.UseVisualStyleBackColor = true;
            this.btScan.Click += new System.EventHandler(this.btScan_Click);
            // 
            // tBBarcode
            // 
            this.tBBarcode.Location = new System.Drawing.Point(88, 165);
            this.tBBarcode.Multiline = true;
            this.tBBarcode.Name = "tBBarcode";
            this.tBBarcode.Size = new System.Drawing.Size(391, 233);
            this.tBBarcode.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 761);
            this.Controls.Add(this.tBBarcode);
            this.Controls.Add(this.btScan);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btScan;
        private System.Windows.Forms.TextBox tBBarcode;
    }
}