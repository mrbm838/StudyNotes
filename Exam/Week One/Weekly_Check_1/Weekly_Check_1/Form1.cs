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
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Weekly_Check_1
{
    public partial class Form1 : Form
    {
        // 用于监听
        TcpListener listener = null;
        // 用于通讯
        TcpClient server = null;
        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            // TCP服务器
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint url = new IPEndPoint(ip, 60000);
            listener = new TcpListener(url);
            listener.Start();

            Thread thListen = new Thread(Listen);
            thListen.IsBackground = true;
            thListen.Start(listener);            
        }
        private void Clock()
        {
            int n = 0;
            while (true)
            {
                textBox1.AppendText(n++.ToString() + "\r\n");
                Thread.Sleep(1000);
            }
        }

        // 连接客户端
        private void Listen(object obj)
        {
            TcpListener ls = obj as TcpListener;
            while (true)
            {
                try
                {
                    server = ls.AcceptTcpClient();
                    ShowMSG("接收到 " + "客户端连上了");
                    Thread thRec = new Thread(ReceiveMsg);
                    thRec.IsBackground = true;
                    thRec.Start(server);
                }
                catch { }
            }
        }
        // 接收客户端信息并回复
        private void ReceiveMsg(object obj)
        {
            TcpClient recClient = obj as TcpClient;
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    NetworkStream stream = recClient.GetStream();
                    int length = stream.Read(buffer, 0, buffer.Length);
                    if (length == 0)
                    {
                        stream.Close();
                        break;
                    }
                    string msg = Encoding.UTF8.GetString(buffer);
                    ShowMSG("接收到 " + msg);

                    string send = msg.Trim('\0') + ",1";
                    byte[] byteSend = new byte[1024];
                    byteSend = Encoding.UTF8.GetBytes(send);
                    stream.Write(byteSend, 0, byteSend.Length);
                    ShowMSG("回复客户端 " + send);
                    //stream.Close();
                }
                catch { }
            }
        }
        // 显示格式并保存
        private void ShowMSG(string str)
        {
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(String.Format("{0}  {1}", DateTime.Now.ToString("yyyy/MM/dd HH/mm/ss"), str));
            richTextBox1.SaveFile(Directory.GetCurrentDirectory().Replace("Weekly_Check_1\\bin\\Debug", "Log.txt"), RichTextBoxStreamType.TextTextOleObjs);
            StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory().Replace("Weekly_Check_1\\bin\\Debug", "Log1.txt"), true, Encoding.UTF8);
            sw.WriteLine(String.Format("{0}  {1}", DateTime.Now.ToString("yyyy/MM/dd HH/mm/ss"), str.Trim('\0')));
            sw.Close();
        }

        //读取文本到DataGridView
        private void btRead_Click(object sender, EventArgs e)
        {
            string txtCurrent = Directory.GetCurrentDirectory();
            string txtPath = txtCurrent.Replace(@"Weekly_Check_1\Weekly_Check_1\bin\Debug", "1.txt");
            StreamReader sr = new StreamReader(txtPath);
            //ArrayList msg2 = new ArrayList();
            int num = 0;
            string temp = null;
            //while ((temp = sr.ReadLine()) != null)
            //{
            //    msg2.Add(temp);
            //}
            string[] msg = new string[10];
            while ((temp = sr.ReadLine()) != null)
            {
                msg[num++] = temp;
            }
            //string[] msg2 = File.ReadAllLines(txtPath);

            sr.Close();


            for (int i = 0; i < num; i++)
            {
                string[] item = msg[i].Split(',');
                for (int j = 0; j < item.Length; j++)
                {
                    if (i == 0)
                    {
                        dataGridView.Columns.Add(item[j], item[j]);
                        //dataGridView.Columns[j].HeaderCell.Value = "1";
                    }
                    else
                    {
                        dataGridView.Rows.Add();
                        dataGridView.Rows[i - 1].Cells[j].Value = item[j];
                    }
                }
            }
        }
        //加载图片
        private void btLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.png; *.jpg";
            ofd.InitialDirectory = @"E:\Cowain\考核\Week One\Picture";
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string picName = ofd.FileName;
                pictureBox.Load(picName);
            }
        }
        //保存图片
        private void btSave_Click(object sender, EventArgs e)
        {
            string targetPath = @"E:\Cowain\Exam\Week One\Save\";
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Save(targetPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg");
            }
        }
        //扫码
        private void btScan_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            // 计数
            Thread clock = new Thread(Clock);
            clock.IsBackground = true;
            clock.Start();
        }
    }
}
