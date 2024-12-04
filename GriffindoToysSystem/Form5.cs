using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GriffindoToysSystem
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MJLF0AD\\SQLEXPRESS;Initial Catalog=Grifindo_Toys;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            fillCombo();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fillCombo()
        {
            string sqlcombo;
            sqlcombo = "select set_id from settings";
            SqlDataAdapter da = new SqlDataAdapter(sqlcombo, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "set_id";
            comboBox1.DisplayMember = "set_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 mm = new Form2();
            this.Hide();
            mm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from settings where set_id ='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["salary_cycle_days"].ToString();
                textBox4.Text = dr["permonth_leaves"].ToString();
                textBox1.Text = dr["taxrate"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["salary_cycle_startDate"]);
                dateTimePicker2.Value = Convert.ToDateTime(dr["salary_cycle_EndDate"]);
            }
            else
            {
                MessageBox.Show("Employee not found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void btnsaveupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlupdate;
                sqlupdate = " update settings set [salary_cycle_days]='" + textBox3.Text + "',permonth_leaves='" + textBox4.Text + "',taxrate='" + textBox1.Text + "',salary_cycle_StartDate='" + dateTimePicker1.Value + "',salary_cycle_endDate='" + dateTimePicker2.Value + "'where set_id='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated sucsessfully!!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }
    }
}
