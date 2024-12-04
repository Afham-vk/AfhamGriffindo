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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MJLF0AD\\SQLEXPRESS;Initial Catalog=GrifibndoToys;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fillCombo();
        }

        private void fillCombo()
        {
            string sqlcombo;
            sqlcombo = "select emp_id from employee";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcombo, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "emp_id";
            comboBox1.DisplayMember = "emp_id";
            con.Close();
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from employee where emp_id ='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["first_name"].ToString();
                textBox3.Text = dr["last_name"].ToString();
                textBox6.Text = dr["contact"].ToString();
                textBox7.Text = dr["monthly_salary"].ToString();
                textBox8.Text = dr["overtime_rate"].ToString();
                textBox9.Text = dr["allowences"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr["joined_date"]);
                if
                    (dr["gender"].Equals("M"))
                    rbtnmale.Checked = true;
                else
                    rbtnfemale.Checked = true;
            }
            else
            {
                MessageBox.Show("Employee not found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 mm = new Form2();
            this.Hide();
            mm.Show();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string gender;
                if (rbtnmale.Checked == true)
                    gender = "M";
                else
                    gender = "F";

                string sqlinsert;
                sqlinsert = "insert into employee(emp_id,first_name,last_name,gender,contact,monthly_salary,overtime_rate,allowences,joined_date) values " +
                    "('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + gender + "','" + textBox6.Text + "'," +
                    "'" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Value + "')";
                SqlCommand cmd = new SqlCommand(sqlinsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added sucsessfully!!");

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string gender;
                if (rbtnmale.Checked == true)
                    gender = "M";
                else
                    gender = "F";
                string sqlupdate;
                sqlupdate = " update employee set first_name='" + textBox2.Text + "',last_name='" + textBox3.Text + "',gender='" + gender + "'," +
                    "contact='" + textBox6.Text + "',joined_date='" + dateTimePicker1.Value + "',monthly_salary='" + textBox7.Text + "'," +
                    "overtime_rate='" + textBox8.Text + "',allowences='" + textBox9.Text + "'where emp_id='" + comboBox1.Text + "'";
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string gender;

                    if (rbtnmale.Checked == true)
                        gender = "M";
                    else
                        gender = "F";
                    string sqldelete;
                    sqldelete = " delete from employee where emp_id='" + comboBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqldelete, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted sucsessfully!!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.Focus();
            dateTimePicker1.Focus();
            rbtnmale.Focus();
            rbtnfemale.Focus();
        }
    }
}
