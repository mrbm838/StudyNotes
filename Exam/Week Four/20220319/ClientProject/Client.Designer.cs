namespace _20220319
{
    partial class Client
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
            this.tBContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBPort = new System.Windows.Forms.TextBox();
            this.tBMSG = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.btConn = new System.Windows.Forms.Button();
            this.btDisconn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tBContent
            // 
            this.tBContent.Location = new System.Drawing.Point(30, 40);
            this.tBContent.Multiline = true;
            this.tBContent.Name = "tBContent";
            this.tBContent.Size = new System.Drawing.Size(740, 194);
            this.tBContent.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // tBIP
            // 
            this.tBIP.Location = new System.Drawing.Point(68, 274);
            this.tBIP.Name = "tBIP";
            this.tBIP.Size = new System.Drawing.Size(213, 28);
            this.tBIP.TabIndex = 2;
            this.tBIP.Text = "127.0.0.2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // tBPort
            // 
            this.tBPort.Location = new System.Drawing.Point(392, 274);
            this.tBPort.Name = "tBPort";
            this.tBPort.Size = new System.Drawing.Size(82, 28);
            this.tBPort.TabIndex = 4;
            this.tBPort.Text = "9001";
            // 
            // tBMSG
            // 
            this.tBMSG.Location = new System.Drawing.Point(30, 346);
            this.tBMSG.Name = "tBMSG";
            this.tBMSG.Size = new System.Drawing.Size(373, 28);
            this.tBMSG.TabIndex = 5;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(432, 340);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(139, 37);
            this.btSend.TabIndex = 6;
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btConn
            // 
            this.btConn.Location = new System.Drawing.Point(529, 274);
            this.btConn.Name = "btConn";
            this.btConn.Size = new System.Drawing.Size(98, 37);
            this.btConn.TabIndex = 7;
            this.btConn.Text = "连接";
            this.btConn.UseVisualStyleBackColor = true;
            this.btConn.Click += new System.EventHandler(this.btConn_Click);
            // 
            // btDisconn
            // 
            this.btDisconn.Location = new System.Drawing.Point(672, 274);
            this.btDisconn.Name = "btDisconn";
            this.btDisconn.Size = new System.Drawing.Size(98, 37);
            this.btDisconn.TabIndex = 8;
            this.btDisconn.Text = "断开";
            this.btDisconn.UseVisualStyleBackColor = true;
            this.btDisconn.Click += new System.EventHandler(this.btDisconn_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 414);
            this.Controls.Add(this.btDisconn);
            this.Controls.Add(this.btConn);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tBMSG);
            this.Controls.Add(this.tBPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBContent);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBPort;
        private System.Windows.Forms.TextBox tBMSG;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btConn;
        private System.Windows.Forms.Button btDisconn;
    }
}