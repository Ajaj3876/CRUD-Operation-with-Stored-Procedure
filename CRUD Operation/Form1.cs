using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2DJ9G4B\\SQLEXPRESS02;Initial Catalog=TestSP_DB;Integrated Security=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(txtEmpID.Text);
            string empname = txtEmpName.Text, city = cmbEmpCity.Text, contact = txtContact.Text, gender = "";
            double age = double.Parse(txtEmpAge.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            if (rdoBtnMale.Checked = true) { gender = "Male"; } else { gender = "Female"; }
            con.Open();
            SqlCommand cmd = new SqlCommand("exec InsertEmp_SP '"+ empid +"', '"+ empname +"', '"+ city +"', '"+ age +"', '"+ gender +"', '"+ joindate +"', '"+ contact +"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Submited.....");
            GetEmpList();
            con.Close();
        }

        void GetEmpList()
        {
            SqlCommand cmd = new SqlCommand("exec ListEmp_SP", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(txtEmpID.Text);
            string empname = txtEmpName.Text, city = cmbEmpCity.Text, contact = txtContact.Text, gender = "";
            double age = double.Parse(txtEmpAge.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            if (rdoBtnMale.Checked = true) { gender = "Male"; } else { gender = "Female"; }
            con.Open();
            SqlCommand cmd = new SqlCommand("exec UppdateEmp_SP '" + empid + "', '" + empname + "', '" + city + "', '" + age + "', '" + gender + "', '" + joindate + "', '" + contact + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated.....");
            GetEmpList();
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete?", "Deleted Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int empid = int.Parse(txtEmpID.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("exec DeleteEmp_SP '" + empid + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted.....");
                GetEmpList();
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(txtEmpID.Text);
            SqlCommand cmd = new SqlCommand("exec LoadEmp_SP '" + empid + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
