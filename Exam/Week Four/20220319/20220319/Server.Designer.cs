namespace _20220319
{
    partial class Server
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
            this.components = new System.ComponentModel.Container();
            this.listView = new System.Windows.Forms.ListView();
            this.客户端列表 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tBIP = new System.Windows.Forms.TextBox();
            this.tBPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBMSG = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.btBuild = new System.Windows.Forms.Button();
            this.timerJudge = new System.Windows.Forms.Timer(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(22, 58);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(288, 694);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // 客户端列表
            // 
            this.客户端列表.AutoSize = true;
            this.客户端列表.Location = new System.Drawing.Point(98, 24);
            this.客户端列表.Name = "客户端列表";
            this.客户端列表.Size = new System.Drawing.Size(98, 18);
            this.客户端列表.TabIndex = 1;
            this.客户端列表.Text = "客户端列表";
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(331, 78);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(44, 18);
            this.IP.TabIndex = 2;
            this.IP.Text = "IP：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(601, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(395, 172);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 22);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "启用心跳";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tBIP
            // 
            this.tBIP.Location = new System.Drawing.Point(369, 73);
            this.tBIP.Name = "tBIP";
            this.tBIP.Size = new System.Drawing.Size(216, 28);
            this.tBIP.TabIndex = 5;
            this.tBIP.Text = "127.0.0.2";
            // 
            // tBPort
            // 
            this.tBPort.Location = new System.Drawing.Point(655, 75);
            this.tBPort.Name = "tBPort";
            this.tBPort.Size = new System.Drawing.Size(100, 28);
            this.tBPort.TabIndex = 6;
            this.tBPort.Text = "9001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "发送的数据：";
            // 
            // tBMSG
            // 
            this.tBMSG.Location = new System.Drawing.Point(511, 315);
            this.tBMSG.Name = "tBMSG";
            this.tBMSG.Size = new System.Drawing.Size(337, 28);
            this.tBMSG.TabIndex = 8;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(502, 434);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(161, 44);
            this.btSend.TabIndex = 9;
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(395, 633);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(162, 59);
            this.btCreate.TabIndex = 10;
            this.btCreate.Text = "打开客户端页面";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(999, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "接收到Log";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(905, 58);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(367, 677);
            this.richTextBox.TabIndex = 13;
            this.richTextBox.Text = "";
            // 
            // btBuild
            // 
            this.btBuild.Location = new System.Drawing.Point(777, 68);
            this.btBuild.Name = "btBuild";
            this.btBuild.Size = new System.Drawing.Size(94, 38);
            this.btBuild.TabIndex = 14;
            this.btBuild.Text = "创建";
            this.btBuild.UseVisualStyleBackColor = true;
            this.btBuild.Click += new System.EventHandler(this.btBuild_Click);
            // 
            // timerJudge
            // 
            this.timerJudge.Tick += new System.EventHandler(this.timerJudge_Tick);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(593, 172);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(124, 22);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "发送心跳包";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 797);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.btBuild);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tBMSG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBPort);
            this.Controls.Add(this.tBIP);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.客户端列表);
            this.Controls.Add(this.listView);
            this.Name = "Server";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label 客户端列表;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tBIP;
        private System.Windows.Forms.TextBox tBPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBMSG;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button btBuild;
        private System.Windows.Forms.Timer timerJudge;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

