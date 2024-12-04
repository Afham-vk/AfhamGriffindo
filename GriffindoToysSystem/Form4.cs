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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MJLF0AD\\SQLEXPRESS;Initial Catalog=Grifindo_Toys;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            fillCombo();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void fillCombo()
        {
            string sqlcombo;
            sqlcombo = "select emp_id from employee";
            SqlDataAdapter da = new SqlDataAdapter(sqlcombo, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "emp_id";
            comboBox1.DisplayMember = "emp_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 mm = new Form2();
            this.Hide();
            mm.Show();
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
                textBox12.Text = dr["monthly_salary"].ToString();
                textBox13.Text = dr["overtime_rate"].ToString();
                textBox14.Text = dr["allowences"].ToString();
            }
            else
            {
                MessageBox.Show("Employee not found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void btnvalidatodates_Click(object sender, EventArgs e)
        {
            string validate;
            validate = "select * from settings where salary_cycle_startDate ='" + dateTimePicker1.Value + "'";
            SqlCommand cmd = new SqlCommand(validate, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dateTimePicker2.Value = Convert.ToDateTime(dr["Salary_Cycle_EndDate"]);
                textBox10.Text = dr["salary_cycle_days"].ToString();
                textBox11.Text = dr["permonth_leaves"].ToString();
                textBox22.Text = dr["taxrate"].ToString();
            }
            else
            {
                MessageBox.Show("Incorrect validate details", "");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox18.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            comboBox1.Focus();
        }

        private void btnculculateoverallattendance_Click(object sender, EventArgs e)
        {
            float NoPayValue;
            float BasePayValue;
            float total;

            NoPayValue = float.Parse(textBox20.Text);
            BasePayValue = float.Parse(textBox18.Text);
            total = BasePayValue - NoPayValue;
            textBox4.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 rdlc = new Form6();
            this.Hide();
            rdlc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float monthly_salary, NoPayValue;
            int noAbsentDays, Salary_Cycle_Days;

            monthly_salary = float.Parse(textBox12.Text); //caluculate monthly_salary
            Salary_Cycle_Days = int.Parse(textBox10.Text); //caculate Salary_Cycle_Days
            noAbsentDays = int.Parse(textBox6.Text);     //caculate noAbsentDays 
            NoPayValue = (monthly_salary / Salary_Cycle_Days) * noAbsentDays; //caculate noAbsentDays NoPayValue
            textBox20.Text = NoPayValue.ToString();  //WHERE GOING TO DISPLAY OUTPUT
        }

        private void button6_Click(object sender, EventArgs e)
        {
            float monthly_salary, overtime_rate, allowences, BasePayValue;
            int OvertimeHours;

            monthly_salary = float.Parse(textBox12.Text);
            overtime_rate = float.Parse(textBox13.Text);
            OvertimeHours = int.Parse(textBox8.Text);
            allowences = float.Parse(textBox14.Text);
            BasePayValue = monthly_salary + allowences + (overtime_rate * OvertimeHours);
            textBox18.Text = BasePayValue.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float GrossPayValue, NoPayValue, BaseValue, taxrate;

            NoPayValue = float.Parse(textBox20.Text);
            BaseValue = float.Parse(textBox18.Text);
            taxrate = float.Parse(textBox22.Text);
            GrossPayValue = BaseValue - (NoPayValue + BaseValue * taxrate / 100);
            textBox21.Text = GrossPayValue.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlinsert;
                sqlinsert = "insert into payroll_report(emp_id,frist_name,last_name,monthly_salary,no_pay,base_pay,gross_pay,tot_cal_value) values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox12.Text + "','" + textBox20.Text + "','" + textBox18.Text + "','" + textBox21.Text + "','" + textBox4.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlinsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Sucsessully!!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }
    }
}
