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
using System.Threading;

namespace Weekly_Check_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        private void btStartScan_Click(object sender, EventArgs e)
        {
            port.Open();
            Byte[] send = new byte[] { 0x0A };
            port.Write(send, 0, send.Length);
            Byte[] receive = new byte[256];
            int length = port.ReadByte();
            //int length1 = port.BytesToRead;
            //int length2 = port.ReadChar();

            port.Read(receive, 0, length);

            string strBack = "";
            for (int i = 0; i < length; i++)
            { 
                strBack += Convert.ToChar(receive[i]);
            }
            lbBarcode.Text = strBack;

            port.Close();
        }
    }
}
