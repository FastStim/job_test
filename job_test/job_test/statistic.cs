using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace job_test
{
    public partial class statistic : Form
    {
        private sql sql = new sql();

        public statistic()
        {
            InitializeComponent();
        }

        private void statistic_Load(object sender, EventArgs e)
        {
            List<string> status = sql.selectStatusName();
            foreach (string item in status)
            {
                comboBox1.Items.Add(item);
            }

            comboBox1.SelectedItem = status[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool employ = (radioButton1.Checked) ? true : false;
            List<stat> stat = sql.selectStatistic(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), comboBox1.SelectedItem.ToString(), employ);
            table_stat.Rows.Clear();

            foreach (stat item in stat)
            {
                bool test = false;
                if (item.date != null) test = true;
                table_stat.Rows.Add((test)?item.date.Value.ToString("yyyy-MM-dd") :"", item.count);
            }
        }
    }
}
