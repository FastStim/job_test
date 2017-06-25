using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace job_test
{
    public partial class main : Form
    {
        private sql sql = new sql();
        public main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<person> person = sql.selectPerson();
            gridView(person);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<person> person = sql.selectPerson();
            gridView(person);
        }

        private void button_Click(object sender, EventArgs e)
        {
            string status = text.Text;

            List<person> person = sql.selectStatus(status);
            gridView(person);
        }

        private void gridView(List<person> person)
        {
            table_person.Rows.Clear();
            foreach (person item in person)
            {
                table_person.Rows.Add(item.fio, item.status, item.dep, item.post, item.date_employ, item.date_unemploy);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string last_name = textBox3.Text;

            List<person> person = sql.selectLastName(last_name);
            gridView(person);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dep = textBox1.Text;

            List<person> person = sql.selectDeps(dep);
            gridView(person);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string post = textBox2.Text;

            List<person> person = sql.selectPosts(post);
            gridView(person);

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statistic stat = new statistic();
            stat.Show();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config conf = new config();
            conf.Show();
        }
    }
}
