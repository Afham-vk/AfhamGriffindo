using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GriffindoToysSystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnemployee_Click(object sender, EventArgs e)
        {
            Form3 emp = new Form3();
            this.Hide();
            emp.Show();
        }

        private void btnsalary_Click(object sender, EventArgs e)
        {
            Form4 sal = new Form4();
            this.Hide();
            sal.Show();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Form5 set = new Form5();
            this.Hide();
            set.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 lg = new Form1();
            this.Hide();
            lg.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
