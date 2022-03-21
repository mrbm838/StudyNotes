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
using ClientProject;

namespace _20220319
{
    public partial class Server : Form
    {
        Socket listen;
        //Socket server;
        int numOfClient = 0;
        Dictionary<Socket, int> dic = new Dictionary<Socket, int>();
        Dictionary<Socket, System.Timers.Timer> dicTimers = new Dictionary<Socket, System.Timers.Timer>();
        List<string> judge = new List<string>();

        EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.ManualReset);

        public Server()
        {
            InitializeComponent();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            listView.View = View.List;
            //string str = "sdfaswerqdlfk";
            //string str1 = "sdfaswerqasdfdlfdsfk";
            //listView.Items.Add(str);
            //listView.Items[0].ForeColor = Color.Green;
            //listView.Items.Add(str1);
            //List<string> s = new List<string>();
        }

        private void btBuild_Click(object sender, EventArgs e)
        {
            listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint port = new IPEndPoint(IPAddress.Parse(tBIP.Text), Int32.Parse(tBPort.Text));
            listen.Bind(port);
            listen.Listen(0);
            btBuild.Enabled = false;
            //richTextBox.AppendText("服务器创建成功");
            richTextBox.Text = "服务器创建成功\r\n";
            richTextBox.SelectionLength = richTextBox.Text.Length;
            richTextBox.SelectionBackColor = Color.Yellow;
            Thread thListen = new Thread(Listen);
            thListen.IsBackground = true;
            thListen.Start(listen);
        }

        void Listen(object o)
        {
            Socket listen = (Socket)o;
            while (true)
            {
                Thread.Sleep(1);
                try
                {
                    Socket server = listen.Accept();
                    waitHandle.WaitOne();
                    //if (checkBox1.Checked)
                    //{
                    //    listen.Close();
                    //}

                    System.Timers.Timer timer = new System.Timers.Timer();
                    dicTimers.Add(server, timer);
                    dic.Add(server, numOfClient);
                    judge.Add("");
                    Invoke((EventHandler)delegate
                    {
                        listView.Items.Add(server.RemoteEndPoint.ToString());
                        listView.Items[numOfClient++].ForeColor = Color.Green;
                    });
                    ShowInRTB(server.RemoteEndPoint, "客户端连接上了");
                    Thread thRec = new Thread(ReceiveMSG);
                    thRec.IsBackground = true;
                    thRec.Start(server);
                }
                catch
                {
                }
            }
        }
        void ReceiveMSG(object o)
        {
            Socket server = (Socket)o;
            while (true)
            {
                Thread.Sleep(1);
                try
                {
                    byte[] bufferRec = new byte[1024];
                    if (server.Poll(5000, SelectMode.SelectRead))
                    {
                        OutOfConnect(server);
                        break;
                    }
                    int n = server.Receive(bufferRec);
                    if (n == 0)
                    {
                        OutOfConnect(server);
                        continue;
                    }
                    string msgRec = Encoding.Default.GetString(bufferRec, 0, n);
                    int value = 0;
                    dic.TryGetValue(server, out value);
                    if (checkBox1.Checked)
                    {
                        judge[value] += msgRec;
                    }
                    if (msgRec != "SYN_ACK")
                    {
                        ShowInRTB(server.RemoteEndPoint, msgRec);
                    }
                }
                catch
                {
                    //OutOfConnect(server);
                }
            }
        }
        void OutOfConnect(Socket server)
        {
            int value = 0;
            dic.TryGetValue(server, out value);
            listView.Invoke((EventHandler)delegate
            {
                listView.Items[value].ForeColor = Color.Red;

            });
        }
        void ShowInRTB(EndPoint point, string str)
        {
            Invoke((EventHandler)delegate
            {
                richTextBox.AppendText(point.ToString() + ": " + str + "\r\n");
            });
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }
            string select = listView.SelectedItems[0].Text;
            //IPAddress ipAddress = IPAddress.Parse(select.Substring(0, select.IndexOf(':')));
            //int port = int.Parse(select.Substring(select.IndexOf(':') + 1));
            //IPEndPoint point = new IPEndPoint(ipAddress, port);
            byte[] bufferSend = Encoding.Default.GetBytes(tBMSG.Text);
            foreach (Socket item in dic.Keys)
            {
                if (item.RemoteEndPoint.ToString().Equals(select))// == select)
                {

                    item.Send(bufferSend);
                    break;
                }
            }
            tBMSG.Text = "";
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            listView.FocusedItem.BackColor = Color.GreenYellow;
            //listView.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (System.Timers.Timer item in dicTimers.Values)
            {
                if (!checkBox1.Checked)
                {
                    waitHandle.Set();
                    item.Enabled = false;
                    item.Stop();
                    item.Close();
                    //item.Dispose();
                }
                else
                {
                    waitHandle.Reset();
                    item.Interval = 5000;
                    item.Elapsed += new System.Timers.ElapsedEventHandler(TimeOut);
                    //item.Elapsed += Item_Elapsed;
                    item.Enabled = true;
                    item.Start();
                    JudgeSend();
                }
            }
            //timerJudge.Enabled = true            
            //timerJudge.Enabled = true;
            //timerJudge.Start();
        }
        void TimeOut(object source, System.Timers.ElapsedEventArgs e)
        {
            //if (!checkBox1.Checked)
            //{
            //    return;
            //}

            System.Timers.Timer timer = source as System.Timers.Timer;
            foreach (KeyValuePair<Socket, System.Timers.Timer> item in dicTimers)
            {
                if (item.Value.Equals(timer))
                {
                    foreach (KeyValuePair<Socket, int> temp in dic)
                    {
                        if (temp.Key.Equals(item.Key))
                        {
                            int value = 0;
                            dic.TryGetValue(temp.Key, out value);
                            if (judge[value].Contains("SYN_ACK"))
                            {
                                judge[value] = "";
                            }
                            else
                            {
                                OutOfConnect(item.Key);
                            }
                            JudgeSend();
                            return;
                        }
                    }                    
                }
            }
            
        }

        private void Item_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            JudgeSend();
        }
        void JudgeSend()
        {
            foreach (Socket item in dic.Keys)
            {
                try
                {
                    item.Send(Encoding.Default.GetBytes("SYN"));
                    Thread.Sleep(10);
                }
                catch
                {

                }
            }
        }

        private void timerJudge_Tick(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                return;
            }
            foreach (KeyValuePair<Socket, System.Timers.Timer> item in dicTimers)
            {
                if (item.Value.Enabled == false)
                {
                    //OutOfConnect(item.Key);
                    //item.Value.Enabled = true;
                    //item.Value.Start();
                }
                //else
                //{
                //    foreach (Socket socket in dic.Keys)
                //    {
                //        if (socket.RemoteEndPoint.ToString().Equals(item.Key.RemoteEndPoint.ToString()))
                //        {
                //            int value = 0;
                //            dic.TryGetValue(socket, out value);
                //            try
                //            {
                //                //if (judge[value] != "")
                //                //{
                //                //    item.Value.Stop();
                //                //    item.Value.Start();
                //                //    judge[value] = "";
                //                //}
                //                if (judge[value] == "SYN_ACK" || judge[value] != "")
                //                {
                //                    item.Value.Stop();
                //                    item.Value.Start();
                //                    break;
                //                }
                //            }
                //            catch
                //            {
                //            }
                //        }
                //    }
                //}
            }
        }
    }
}
