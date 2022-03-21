using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220319
{
    public partial class Client : Form
    {
        Socket client;// = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        bool flag = false;
        public Client()
        {
            InitializeComponent();
        }

        private void btConn_Click(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(tBIP.Text), Convert.ToInt32(tBPort.Text));
            Task.Run(() =>
            {
                try
                {

                    client.Connect(point);
                }
                catch
                {
                }
            });
            btConn.Enabled = false;
            Thread thRec = new Thread(ReceiveMSG);
            thRec.IsBackground = true;
            thRec.Start();
        }
        void ReceiveMSG()
        {
            while (true)
            {
                Thread.Sleep(10);
                try
                {
                    if (flag)
                    {
                        break;
                    }
                    byte[] bufferRec = new byte[1024];
                    int n = client.Receive(bufferRec);
                    string msgRec = Encoding.Default.GetString(bufferRec, 0, n);
                    if (msgRec.Contains("SYN"))
                    {
                        client.Send(Encoding.Default.GetBytes("SYN_ACK"));
                        continue;
                    }
                    else
                    {
                        ShowInTB(msgRec);
                    }
                }
                catch
                {
                }
            }
        }
        void ShowInTB(string str)
        {
            Invoke((EventHandler)delegate
            {
                tBContent.Text += tBIP.Text + ":" + tBPort.Text + ": " + str + "\r\n";
            });
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag)
                {
                    return;
                }
                byte[] bufferSend = Encoding.Default.GetBytes(tBMSG.Text);
                client.Send(bufferSend);
                tBMSG.Text = "";
            }
            catch
            {
            }
        }

        private void btDisconn_Click(object sender, EventArgs e)
        {
            flag = !flag;
            try
            {
                //client.Disconnect(true);
                client.Close();
                client.Dispose();
                btConn.Enabled = true;
            }
            catch 
            {

            }

        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            flag = true;
            //client.Disconnect(false);
            try
            {

                client.Close();
                client.Dispose();
            }
            catch 
            {

            }
        }
    }
}
