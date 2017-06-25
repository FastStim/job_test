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
    public partial class config : Form
    {
        public config()
        {
            InitializeComponent();
        }

        private void config_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.server;
            textBox2.Text = Properties.Settings.Default.login;
            textBox3.Text = Properties.Settings.Default.password;
            textBox4.Text = Properties.Settings.Default.database;
            textBox5.Text = Properties.Settings.Default.charset;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server = textBox1.Text;
            Properties.Settings.Default.login = textBox2.Text;
            Properties.Settings.Default.password = textBox3.Text;
            Properties.Settings.Default.database = textBox4.Text;
            Properties.Settings.Default.charset = textBox5.Text;

            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
