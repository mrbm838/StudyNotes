namespace _20220226
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
            this.tBox_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBox_Buffer = new System.Windows.Forms.TextBox();
            this.tBox_Output = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tBox_Input
            // 
            this.tBox_Input.Location = new System.Drawing.Point(362, 145);
            this.tBox_Input.Name = "tBox_Input";
            this.tBox_Input.Size = new System.Drawing.Size(412, 28);
            this.tBox_Input.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buffer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Output";
            // 
            // tBox_Buffer
            // 
            this.tBox_Buffer.Location = new System.Drawing.Point(501, 215);
            this.tBox_Buffer.Name = "tBox_Buffer";
            this.tBox_Buffer.Size = new System.Drawing.Size(80, 28);
            this.tBox_Buffer.TabIndex = 4;
            // 
            // tBox_Output
            // 
            this.tBox_Output.Location = new System.Drawing.Point(362, 304);
            this.tBox_Output.Name = "tBox_Output";
            this.tBox_Output.Size = new System.Drawing.Size(412, 28);
            this.tBox_Output.TabIndex = 5;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(501, 410);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(106, 49);
            this.btRun.TabIndex = 6;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 693);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.tBox_Output);
            this.Controls.Add(this.tBox_Buffer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBox_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBox_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBox_Buffer;
        private System.Windows.Forms.TextBox tBox_Output;
        private System.Windows.Forms.Button btRun;
    }
}

