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

namespace _20220109
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btScan_Click(object sender, EventArgs e)
        {
            SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            try
            {
                serialPort.Open();

                byte[] order = new byte[] { 0x0A };
                serialPort.Write(order, 0, order.Length);

                // 需要在1秒内扫上码
                System.Threading.Thread.Sleep(1000);
                int length = serialPort.BytesToRead;
                byte[] data = new byte[length];
                serialPort.Read(data, 0, length);
                string barcode = Encoding.UTF8.GetString(data);
                textBox.Text = barcode;

                serialPort.Close();

                string logFile = Directory.GetCurrentDirectory().Replace(@"20220109\bin\Debug", "BarcodeLog.txt");
                File.AppendAllText(logFile, barcode + "\r\n");
            }
            catch { }
            
        }
    }
}
