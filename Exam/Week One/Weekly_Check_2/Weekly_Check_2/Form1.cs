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
using System.Net;
using System.Threading;

namespace Weekly_Check_2
{
    public partial class Form1 : Form
    {
        // 监听
        TcpListener listener = null;
        // 通讯
        TcpClient server = null;

        string dir = Directory.GetCurrentDirectory();

        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 60000);
            listener.Start();
            Thread thComm = new Thread(Listen);
            thComm.IsBackground = true;
            thComm.Start();
        }
        // 开始监听
        private void Listen()
        {
            while (true)
            {
                try
                {
                    server = listener.AcceptTcpClient();
                    ShowMSG("接收到 " + "客户端连接上了");

                    Thread thTalk = new Thread(Talk);
                    thTalk.IsBackground = true;
                    thTalk.Start();
                }
                catch { }
            }
        }
        // 接收并回复客户端
        private void Talk()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[128];
                    NetworkStream stream = server.GetStream();
                    stream.Read(data, 0, data.Length);
                    string msg = Encoding.UTF8.GetString(data).Trim('\0');
                    ShowMSG("接收到 " + msg);

                    string reply = msg + ",1";
                    byte[] replyByte = Encoding.UTF8.GetBytes(reply);
                    stream.Write(replyByte, 0, replyByte.Length);
                    ShowMSG("回复客户端 " + reply);
                }
                catch { }
            }
        }
        // 显示并保存Log
        public void ShowMSG(string str)
        {
            string info = string.Format("{0}    {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), str);
            richTextBox.AppendText(info + Environment.NewLine);
            string currentPath = Directory.GetCurrentDirectory();
            string txtPath = currentPath.Replace(@"Weekly_Check_2\bin\Debug", "CommunicationLog.txt");
            //StreamWriter sw = new StreamWriter(txtPath, true);
            //sw.WriteLine(info);
            //sw.Close();
            File.AppendAllText(txtPath, info + "\r\n");
        }

        // 读文本
        private void btRead_Click(object sender, EventArgs e)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string txtPath = currentPath.Replace(@"Weekly_Check_2\bin\Debug", "1.txt");
            //StreamReader sr = new StreamReader(txtPath, Encoding.UTF8);
            string[] all = File.ReadAllLines(txtPath);
            for (int i = 0; i < all.Length; i++)
            {
                string[] item = all[i].Split(',');
                if (i == 0)
                {
                    for (int j = 0; j < item.Length; j++)
                        dataGradView.Columns.Add(item[j], item[j]);
                }
                else
                {
                    dataGradView.Rows.Add(item);
                }
            }
        }

        // 读取图片
        private void btPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "图片文件|*.jpg; *.png";
            string picFile = Directory.GetCurrentDirectory().Replace(@"Weekly_Check_2\bin\Debug", "Picture");
            open.InitialDirectory = picFile;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(open.FileName);
            }
        }

        // 存图片
        private void btSave_Click(object sender, EventArgs e)
        {
            string savePath = Directory.GetCurrentDirectory().Replace(@"Weekly_Check_2\bin\Debug", "Save");
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Save(String.Format("{0}\\{1}.png", savePath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));
            }
        }

        // 打开扫码窗口
        private void btOpenScan_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Thread count = new Thread(Count);
            count.IsBackground = true;
            count.Start();
        }

        private void Count()
        {
            int n = 1;
            while (true)
            {
                Thread.Sleep(1000);
                textBox1.AppendText(n++.ToString() + "\r\n");                
            }
        }
    }
}
