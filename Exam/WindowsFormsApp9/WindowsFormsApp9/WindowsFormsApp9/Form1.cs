using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        //public static string[] A = { "我", "是", "科", "瑞", "恩", "软", "件", "部", "的", "一", "员", "，", "进", "步", "最", "快", "的", "那", "位", ".", ".", "." };
        string A = "我是科瑞恩软件部";// 的一员，进步最快的那位...";
        public int count = 0;
        string str;
        object obj = new object();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = A;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(input);
            threadInput.IsBackground = true;
            threadInput.Start();

            Thread threadbuffer = new Thread(buffer);
            threadbuffer.IsBackground = true;
            threadbuffer.Start();

            Thread threadoutput = new Thread(output);
            threadoutput.IsBackground = true;
            threadoutput.Start();
        }

        public void input()
        {
            while (A.Length > 0)
            {
                if (textBox1.InvokeRequired)
                {
                    Action<string> actionDelegate3 = delegate (string s) { textBox1.Text = A.Remove(0, 1); };
                    this.textBox1.Invoke(actionDelegate3, str);
                    if (count == A.Length - 1)
                    {
                        Action<string> actionDelegate4 = delegate (string s) { textBox1.Text = "over"; };
                        this.textBox1.Invoke(actionDelegate4, str);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public void buffer()
        {
            //if (count < A.Length - 1)
            //{
            while (A.Length > 0)
            {
                lock (obj)
                {
                    if (textBox2.InvokeRequired)
                    {
                        Action<string> actionDelegate1 = delegate (string s) { this.textBox2.Text = A[count].ToString(); };
                        this.textBox2.Invoke(actionDelegate1, str);
                        count++;
                    }
                    Thread.Sleep(1000);
                }
            }
            //}
        }

        public void output()
        {
            while (A.Length > 0)
            {
                if (textBox3.InvokeRequired)
                {
                    Action<string> actionDelegate = delegate (string s) { this.textBox3.Text += A[count]; };
                    this.textBox3.Invoke(actionDelegate, str);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
