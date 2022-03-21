namespace Weekly_Check_2
{
    partial class Form1
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
            this.dataGradView = new System.Windows.Forms.DataGridView();
            this.btRead = new System.Windows.Forms.Button();
            this.btPicture = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btOpenScan = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGradView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGradView
            // 
            this.dataGradView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGradView.Location = new System.Drawing.Point(38, 58);
            this.dataGradView.Name = "dataGradView";
            this.dataGradView.RowHeadersWidth = 62;
            this.dataGradView.RowTemplate.Height = 30;
            this.dataGradView.Size = new System.Drawing.Size(652, 461);
            this.dataGradView.TabIndex = 0;
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(38, 12);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(133, 39);
            this.btRead.TabIndex = 1;
            this.btRead.Text = "读取文本数据";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // btPicture
            // 
            this.btPicture.Location = new System.Drawing.Point(38, 527);
            this.btPicture.Name = "btPicture";
            this.btPicture.Size = new System.Drawing.Size(112, 50);
            this.btPicture.TabIndex = 2;
            this.btPicture.Text = "读取图片";
            this.btPicture.UseVisualStyleBackColor = true;
            this.btPicture.Click += new System.EventHandler(this.btPicture_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(38, 585);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(670, 515);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(302, 525);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(112, 50);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "存图片";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btOpenScan
            // 
            this.btOpenScan.Location = new System.Drawing.Point(302, 12);
            this.btOpenScan.Name = "btOpenScan";
            this.btOpenScan.Size = new System.Drawing.Size(133, 39);
            this.btOpenScan.TabIndex = 5;
            this.btOpenScan.Text = "打开扫码窗口";
            this.btOpenScan.UseVisualStyleBackColor = true;
            this.btOpenScan.Click += new System.EventHandler(this.btOpenScan_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(1143, 58);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(563, 1042);
            this.richTextBox.TabIndex = 6;
            this.richTextBox.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(766, 58);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 1042);
            this.textBox1.TabIndex = 7;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1718, 1183);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.btOpenScan);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btPicture);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.dataGradView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGradView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGradView;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.Button btPicture;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btOpenScan;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

