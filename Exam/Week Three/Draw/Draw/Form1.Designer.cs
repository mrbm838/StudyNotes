namespace Draw
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
            this.listView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.btDraw = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.获奖人员名单 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(60, 117);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(256, 638);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "所有人员名单";
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox.Location = new System.Drawing.Point(497, 117);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(232, 524);
            this.textBox.TabIndex = 2;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(497, 728);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(206, 26);
            this.comboBox.TabIndex = 3;
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(752, 721);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(119, 39);
            this.btDraw.TabIndex = 4;
            this.btDraw.Text = "开始抽奖";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1017, 117);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(295, 524);
            this.dataGridView.TabIndex = 5;
            // 
            // 获奖人员名单
            // 
            this.获奖人员名单.AutoSize = true;
            this.获奖人员名单.Location = new System.Drawing.Point(1039, 70);
            this.获奖人员名单.Name = "获奖人员名单";
            this.获奖人员名单.Size = new System.Drawing.Size(116, 18);
            this.获奖人员名单.TabIndex = 6;
            this.获奖人员名单.Text = "获奖人员名单";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(1067, 692);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(206, 37);
            this.btSave.TabIndex = 7;
            this.btSave.Text = "保存获奖名单";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 908);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.获奖人员名单);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btDraw);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label 获奖人员名单;
        private System.Windows.Forms.Button btSave;
    }
}

