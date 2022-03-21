using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace Weekly_Check_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        // 开始扫码
        private void btScan_Click(object sender, EventArgs e)
        {
            // 按情况修改COM口


            byte[] a = new byte[] { 65, 66, 67 };
            string b = Encoding.ASCII.GetString(a);
            string c = "";
            for (int i = 0; i < a.Length; i++)
            {
                c += Convert.ToChar(a[i]);
            }

            Thread thread = new Thread(GetReturn);
            thread.IsBackground = true;
            thread.Start();
        }
        private void GetReturn()
        {
            byte[] send = new byte[] { 0x0A };
            try
            {
                serialPort.Write(send, 0, send.Length);

                while (true)
                {
                    // 需要在1s内扫上码
                    //System.Threading.Thread.Sleep(1000);
                    int length = serialPort.BytesToRead;
                    if (length != 0)
                    {
                        byte[] data = new byte[length];
                        serialPort.Read(data, 0, length);
                        string barcode = Encoding.ASCII.GetString(data);
                        tBBarcode.Text = barcode;
                        Save(barcode);
                    }
                }
                serialPort.Close();
            }
            catch { }
        }
        // 保存至Log
        public void Save(string str)
        {
            string file = Directory.GetCurrentDirectory().Replace(@"Weekly_Check_2\bin\Debug", "BarcodeLog.txt");
            File.AppendAllText(file, str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                int a = 1;
                //tBBarcode.Text = "1";
            }
        }
    }
}
