using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _20220226
{
    public partial class Form1 : Form
    {
        // 存储三个文本框的内容
        StringBuilder strInput = new StringBuilder("我是科瑞恩软件工程部的一员，进步最快的那位...");
        StringBuilder strOutput = new StringBuilder();
        StringBuilder buffer = new StringBuilder();

        // lock对象
        static object objBuffer = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 取消跨线程访问控件的检查
            //CheckForIllegalCrossThreadCalls = false;

            // 程序开始时文本框的初始化
            ShowInfo();
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            // 创建访问 buffer 的线程
            Thread thRead = new Thread(ReadBuffer);
            Thread thWrite = new Thread(WriteBuffer);
            thRead.Start();
            thWrite.Start();
        }

        /// <summary>
        /// 刷新文本框
        /// </summary>
        void ShowInfo()
        {
            // 方案一
            if (tBox_Input.InvokeRequired)
            {
                AboutDelegate(strInput.ToString(), tBox_Input);
            }
            else
            {
                tBox_Input.Text = strInput.ToString();
            }
            if (tBox_Buffer.InvokeRequired)
            {
                AboutDelegate(buffer.ToString(), tBox_Buffer);
            }
            if (tBox_Output.InvokeRequired)
            {
                AboutDelegate(strOutput.ToString(), tBox_Output);
            }

            #region 方案二
            //Action act = delegate ()
            //{
            //    tBox_Input.Text = strInput;
            //    tBox_Buffer.Text = buffer;
            //    //if (tBox_Output.InvokeRequired)
            //    tBox_Output.Text = strOutput;
            //};
            //Invoke(act);
            #endregion

            #region 方案三
            //Invoke((EventHandler)delegate
            //{
            //    tBox_Input.Text = strInput;
            //    tBox_Buffer.Text = buffer;
            //    tBox_Output.Text = strOutput;
            //});
            #endregion
        }

        /// <summary>
        /// 方案一的委托
        /// </summary>
        /// <param name="txt">文本框内容</param>
        /// <param name="textBox">文本框控件</param>
        void AboutDelegate(string txt, Control textBox)
        {
            Action<string> actionDelegate = delegate (string str)
            {
                textBox.Text = str;
            };
            textBox.Invoke(actionDelegate, txt);
        }

        /// <summary>
        /// 用于获取 Input 和 buffer
        /// </summary>
        void ReadBuffer()
        {
            while (strInput.Length > 0)
            {
                //OperateBuffer(0);

                lock (objBuffer)
                {
                    // 获取 buffer
                    buffer = new StringBuilder(strInput.ToString().Substring(0, 1));
                    
                    // 获取 Input
                    strInput.Remove(0, 1);
                    Thread.Sleep(200);

                    ShowInfo();
                }
            }
        }

        /// <summary>
        /// 用于获取 Output
        /// </summary>
        void WriteBuffer()
        {
            while (strInput.Length > 0)
            {
                //OperateBuffer(1);

                lock (objBuffer)
                {
                    // 获取 Output
                    strOutput.Append(buffer);
                    // 当前线程阻塞200毫秒
                    Thread.Sleep(200);

                    ShowInfo();
                }
            }
            // 输出完毕后显示 Over
            strInput.Append("Over");
            ShowInfo();
        }

        #region 两个线程调用同一方法使用 buffer
        void OperateBuffer(int number)
        {
            lock (objBuffer)
            {
                if (number == 0)
                {
                    // 获取 buffer
                    // buffer = strInput.Substring(0, 1);
                    buffer = new StringBuilder(strInput.ToString().Substring(0, 1));

                    // 获取 Input
                    strInput = strInput.Remove(0, 1);
                }
                if (number == 1)
                {
                    // 获取 Output
                    // strOutput += buffer;
                    strOutput.Append(buffer);
                }
                // 当前线程阻塞200毫秒
                Thread.Sleep(200);

                ShowInfo();
            }
        }
        #endregion
    }
}