namespace Weekly_Check_1
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btRead = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btScan = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 54);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(563, 395);
            this.dataGridView.TabIndex = 0;
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(12, 12);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(149, 36);
            this.btRead.TabIndex = 1;
            this.btRead.Text = "读取文本数据";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(13, 455);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(98, 36);
            this.btLoad.TabIndex = 2;
            this.btLoad.Text = "读取图片";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(167, 455);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(98, 36);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "存图片";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 500);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(578, 431);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // btScan
            // 
            this.btScan.Location = new System.Drawing.Point(205, 12);
            this.btScan.Name = "btScan";
            this.btScan.Size = new System.Drawing.Size(149, 36);
            this.btScan.TabIndex = 5;
            this.btScan.Text = "打开扫码窗口";
            this.btScan.UseVisualStyleBackColor = true;
            this.btScan.Click += new System.EventHandler(this.btScan_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(880, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(411, 832);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "log";
            this.richTextBox1.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(623, 66);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 832);
            this.textBox1.TabIndex = 8;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 1061);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btScan);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btScan;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

