using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankPractice_v1_.Model;
using System.Data.SqlClient;
using System.Configuration;

namespace BankPractice_v1_
{
    public partial class Register : Form
    {
        private SqlConnection conn = null;
        private string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\joshu\source\repos\BankPractice(v1)\Database1.mdf;Integrated Security = True";
        private User user1 = new User();
        private bool success = false;

        public Register()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            user1.username = usernameTb.Text;
            user1.password = passTb.Text;

            SaveUser();
        }

        private void SaveUser() {
            string sqlquery = "insert into Users values(@username, @password)";

            try
            {
                using (conn = new SqlConnection(ConnectionString))
                using (SqlCommand comm = new SqlCommand(sqlquery, conn))
                {
                    ConnOpen();
                    comm.Parameters.AddWithValue("@username", usernameTb.Text);
                    comm.Parameters.AddWithValue("@password", passTb.Text);
                    int ok = comm.ExecuteNonQuery();
                    if (ok > 0)
                    {
                        success = true;
                        ShowSuccess();
                    }
                    else {
                        success = false;
                        ShowSuccess();
                    }
                    ConnClose();
                }

            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                success = false;
                ShowSuccess();
            }

        }

        private void ShowSuccess() {
            if (success == true)
            {
                MessageBox.Show("Registration success!");
                ClearBoxes();
                this.Close();
            }
            else if (success == false) {
                MessageBox.Show("Registration failure.");
                ClearBoxes();
            }
        }

        private void ConnOpen() {
            conn.Open();
        }

        private void ConnClose() {
            conn.Close();
        }

        private void ClearBoxes() {
            usernameTb.Text = "";
            passTb.Text = "";
            usernameTb.Focus();
        }
    }
}
