using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace _20220109
{
    public partial class Form1 : Form
    {
        string currentDir = Directory.GetCurrentDirectory();

        // 监听
        TcpListener tcpListener = null;
        // 通讯
        TcpClient server = null;

        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            tcpListener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 60000);
            tcpListener.Start();

            Thread thListen = new Thread(Listen);
            thListen.IsBackground = true;
            thListen.Start();
        }
        // 连接客户端
        public void Listen()
        {
            while (true)
            {
                try
                {
                    server = tcpListener.AcceptTcpClient();
                    ShowMSG("接收到：" + "客户端连接上了");
                    Thread thTalk = new Thread(Talk);
                    thTalk.IsBackground = true;
                    thTalk.Start();
                }
                catch { }
            }
        }
        // 与客户端通讯
        public void Talk()
        {
            while (true)
            {
                try
                {
                    NetworkStream stream = server.GetStream();
                    byte[] recByte = new byte[128];
                    stream.Read(recByte, 0, recByte.Length);
                    string msgRec = Encoding.UTF8.GetString(recByte).Trim('\0');
                    ShowMSG("接收到：" + msgRec);

                    string msgSend = msgRec + ",1";
                    byte[] sendByte = Encoding.UTF8.GetBytes(msgSend);
                    stream.Write(sendByte, 0, sendByte.Length);
                    ShowMSG("回复客户端：" + msgSend);
                }
                catch {}
            }
            
        }
        // 显示并保存Log
        public void ShowMSG(string msg)
        {
            string msgStr = String.Format("{0}  {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), msg);
            richTextBox.AppendText(msgStr + Environment.NewLine);
            string logFile = currentDir.Replace(@"20220109\bin\Debug", "CommLog.txt");
            File.AppendAllText(logFile, msgStr + "\r\n");
        }

        // 读取文本数据
        private void btRead_Click(object sender, EventArgs e)
        {
            string txtRead = currentDir.Replace(@"20220109\bin\Debug", "1.txt");
            string[] allLines = File.ReadAllLines(txtRead);
            for (int i = 0; i < allLines.Length; i++)
            {
                string[] items = allLines[i].Split(',');

                if (i == 0)
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        dataGridView.Columns.Add(items[j], items[j]);
                    }
                }
                else
                {
                    dataGridView.Rows.Add(items);
                }

            }
        }
        // 读取图片
        private void btShowPic_Click(object sender, EventArgs e)
        {
            string picFile = currentDir.Replace(@"20220109\bin\Debug", "Picture");
            OpenFileDialog openPic = new OpenFileDialog();
            openPic.Filter = "图片文件|*.png; *.jpg";
            openPic.InitialDirectory = picFile;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (openPic.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(openPic.FileName);
            }
        }
        // 存图片
        private void btSavePic_Click(object sender, EventArgs e)
        {
            string saveFile = currentDir.Replace(@"20220109\bin\Debug", "Save");
            if (!Directory.Exists(saveFile))
            {
                Directory.CreateDirectory(saveFile);
            }
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Save(string.Format("{0}\\{1}.png", saveFile, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));
            }
        }
        // 扫码窗口
        private void btOpenScan_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            Thread thCount = new Thread(Count);
            thCount.IsBackground = true;
            thCount.Start();
        }
        // 计数
        public void Count()
        {
            int num = 1;
            while (true)
            {
                Thread.Sleep(1000);
                textBox.AppendText(num++.ToString() + "\r\n");
            }
        }
    }
}
