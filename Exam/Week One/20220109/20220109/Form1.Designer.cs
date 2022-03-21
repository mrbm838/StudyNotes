namespace _20220109
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
            this.btRead = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btShowPic = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btSavePic = new System.Windows.Forms.Button();
            this.btOpenScan = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(29, 12);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(169, 69);
            this.btRead.TabIndex = 0;
            this.btRead.Text = "读取文本数据";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(29, 88);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(584, 468);
            this.dataGridView.TabIndex = 1;
            // 
            // btShowPic
            // 
            this.btShowPic.Location = new System.Drawing.Point(29, 562);
            this.btShowPic.Name = "btShowPic";
            this.btShowPic.Size = new System.Drawing.Size(133, 49);
            this.btShowPic.TabIndex = 2;
            this.btShowPic.Text = "读取图片";
            this.btShowPic.UseVisualStyleBackColor = true;
            this.btShowPic.Click += new System.EventHandler(this.btShowPic_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(29, 618);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(584, 468);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // btSavePic
            // 
            this.btSavePic.Location = new System.Drawing.Point(259, 563);
            this.btSavePic.Name = "btSavePic";
            this.btSavePic.Size = new System.Drawing.Size(133, 49);
            this.btSavePic.TabIndex = 4;
            this.btSavePic.Text = "存图片";
            this.btSavePic.UseVisualStyleBackColor = true;
            this.btSavePic.Click += new System.EventHandler(this.btSavePic_Click);
            // 
            // btOpenScan
            // 
            this.btOpenScan.Location = new System.Drawing.Point(300, 12);
            this.btOpenScan.Name = "btOpenScan";
            this.btOpenScan.Size = new System.Drawing.Size(169, 69);
            this.btOpenScan.TabIndex = 5;
            this.btOpenScan.Text = "打开扫码窗口";
            this.btOpenScan.UseVisualStyleBackColor = true;
            this.btOpenScan.Click += new System.EventHandler(this.btOpenScan_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(1020, 88);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(507, 924);
            this.richTextBox.TabIndex = 6;
            this.richTextBox.Text = "";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(691, 88);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(250, 916);
            this.textBox.TabIndex = 7;
            this.textBox.Click += new System.EventHandler(this.textBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 1098);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.btOpenScan);
            this.Controls.Add(this.btSavePic);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btShowPic);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btRead);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btShowPic;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btSavePic;
        private System.Windows.Forms.Button btOpenScan;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.TextBox textBox;
    }
}

