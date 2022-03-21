using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {
        string currentPath = Directory.GetCurrentDirectory();
        bool flag = false;
        static string[] staff;
        string[] winners;
        List<int> selected = new List<int>();
        int[] temp;
        int sum;
        Thread thDraw;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            listView.View = View.Details;
            listView.HeaderStyle = ColumnHeaderStyle.None;
            //listView.Columns.Add("StaffName");          // 添加列名 
            //listView.MinimumSize = new Size(10, 20);
            //listView.Scrollable = true;
            ShowAllStaff();

            comboBox.Items.Add("一等奖");
            comboBox.Items.Add("二等奖");
            comboBox.Items.Add("三等奖");
            comboBox.Items.Add("阳光普照");

            dataGridView.AutoResizeColumns();
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;

            dt.Columns.Add("奖项");
            dt.Columns.Add("名单");

        }


        /// <summary>
        /// 在ListView显示所有人员
        /// </summary>
        void ShowAllStaff()
        {
            string targetFile = currentPath.Replace("Draw\\bin\\Debug", "抽奖人员名单.txt");
            StreamReader sr = new StreamReader(targetFile, Encoding.UTF8);

            staff = File.ReadAllLines(targetFile);
            for (int i = 0; i < staff.Length; i++)
            {
                ListViewItem item = new ListViewItem(staff[i]);
                listView.Items.Add(item);
            }
            this.listView.EndUpdate();
        }

        private void btDraw_Click(object sender, EventArgs e)
        {
            flag = !flag;
            Judge();
        }
        void Judge()
        {
            if (flag)
            {
                sum = comboBox.SelectedIndex + 1;
                if (sum == 4) sum = 10;
                thDraw = new Thread(BeginDraw);
                thDraw.IsBackground = true;
                thDraw.Start(sum);
            }
            else
            {
                //thDraw.Abort();
                return;
            }


        }

        void ShowDataGridView()
        {
            dataGridView.Invoke(new Action(() =>
                {
                    for (int i = 0; i < sum; i++)
                    {
                        dt.Rows.Add(comboBox.Text, winners[i]);
                    }
                    dataGridView.DataSource = dt;
                }));


        }

        void BeginDraw(object o)
        {

            int n = (int)o;
            temp = new int[n];
            winners = new string[n];

            Random r = new Random();

            while (true)
            {

                for (int i = 0; i < n; i++)
                {
                    int num = r.Next(0, staff.Length);      // 在所有人员内选取随机数
                    if (!temp.Contains(num) && !selected.Contains(num))// 出现重复随机数或获奖人员序号时重新获取
                    {
                        temp[i] = num;
                    }
                    else
                    {
                        i--;
                    }
                }
                if (!flag)
                {
                    //select = temp;
                    for (int i = 0; i < n; i++)
                    {
                        winners[i] = staff[temp[i]];
                        selected.Add(temp[i]);              // 记录获奖人员序号
                    }
                    ShowDataGridView();
                    break;
                }

                for (int i = 0; i < n; i++)
                {
                    textBox.Invoke(new Action(() =>
                    {
                        textBox.Text += staff[temp[i]] + "\r\n";
                    }));
                }

                Thread.Sleep(100);

                Array.Clear(temp, 0, temp.Length);
                textBox.Invoke(new Action(() =>
                {

                    textBox.Clear();
                }));
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            DataToExcel(dt);
        }
        public void DataToExcel(DataTable dataTable)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string fileName = currentPath.Replace("Draw\\bin\\Debug", "获奖人员名单.csv");
            StreamWriter sw;
            string strLine = "";
            sw = new StreamWriter(fileName, false, Encoding.Unicode);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    strLine += dataTable.Rows[i].ItemArray[j].ToString() + "\t";//Convert.ToChar(9);

                }
                sw.WriteLine(strLine);
                strLine = "";
            }
            //sw.WriteLine(strLine);
            sw.Close();
        }
    }
}
