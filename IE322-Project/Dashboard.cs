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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
namespace IE322_Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            labelIndecator1.ForeColor = System.Drawing.Color.Green;
            labelIndecator2.ForeColor = System.Drawing.Color.Black;
            labelIndecator3.ForeColor = System.Drawing.Color.Black;
            labelIndecator4.ForeColor = System.Drawing.Color.Black;

            panel2.Visible = true;
            panel1.Visible = false;
            panel4.Visible = false;
        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            labelIndecator2.ForeColor = System.Drawing.Color.Green;
            labelIndecator1.ForeColor = System.Drawing.Color.Black;
            labelIndecator3.ForeColor = System.Drawing.Color.Black;
            labelIndecator4.ForeColor = System.Drawing.Color.Black;

            panel1.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;


        }

        private void btnFullHistory_Click(object sender, EventArgs e)
        {
            labelIndecator3.ForeColor = System.Drawing.Color.Green;
            labelIndecator2.ForeColor = System.Drawing.Color.Black;
            labelIndecator1.ForeColor = System.Drawing.Color.Black;
            labelIndecator4.ForeColor = System.Drawing.Color.Black;

            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=SIR\\SQLEXPRESS; database=Hospital; integrated security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT AddPatient.pid, Name, Full_Address, Contact, Age, Gender, Blood_Group, Major_Disease, Symptoms, Diagnosis, Medicines, Ward, Ward_Type FROM AddPatient INNER JOIN PatientMore ON AddPatient.pid = PatientMore.pid";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView3.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient history: " + ex.Message);
            }
        }


        

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            panel4.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string address = txtAddress.Text;
                Int64 contact = Convert.ToInt64(txtCN.Text);
                int age = Convert.ToInt32(txtAge.Text);
                string gender = comboGender.Text;
                string blood = comboBlood.Text;
                string any = txtAny.Text;
                int pid = Convert.ToInt32(txtPid.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SIR\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;";

                string query = "INSERT INTO AddPatient (Name, Full_Address, Contact, Age, Gender, Blood_Group, Major_Disease, pid) " +
                               "VALUES (@Name, @Address, @Contact, @Age, @Gender, @Blood, @Disease, @Pid)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Blood", blood);
                cmd.Parameters.AddWithValue("@Disease", any);
                cmd.Parameters.AddWithValue("@Pid", pid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved Successfully");

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Data format or Invalid ID");
            }




        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                try
                {
                    int pid = Convert.ToInt32(textBox1.Text);

                    using (SqlConnection con = new SqlConnection("Data Source=SIR\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;"))
                    {
                        string query = "SELECT * FROM AddPatient WHERE pid = @Pid";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Pid", pid);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Patient ID. Please enter a valid number.");
                }
                catch (Exception)
                {
                    MessageBox.Show($"An error occurred: ");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBox1.Text);
                string sympt = txtBXSym.Text;
                string diag = txtDia.Text;
                string med = txtMed.Text;
                string ward = comboWa.Text;
                string wardtype = comboWTy.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=SIR\\SQLEXPRESS; database=hospital; integrated security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO PatientMore VALUES (@pid, @symptoms, @diagnosis, @medicines, @ward, @wardtype)";

                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@symptoms", sympt);
                cmd.Parameters.AddWithValue("@diagnosis", diag);
                cmd.Parameters.AddWithValue("@medicines", med);
                cmd.Parameters.AddWithValue("@ward", ward);
                cmd.Parameters.AddWithValue("@wardtype", wardtype);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
            textBox1.Clear();
            txtBXSym.Clear();
            txtDia.Clear();
            txtMed.Clear();
            comboWa.ResetText();
            comboWTy.ResetText();



        } 

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
    }

