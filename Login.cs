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
using BankPractice_v1_.Model;

namespace BankPractice_v1_
{
    public partial class Login : Form
    {
        private SqlConnection conn = null;
        private string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\joshu\source\repos\BankPractice(v1)\Database1.mdf;Integrated Security = True";
        private User user2 = new User();
        private bool success = false;

        public Login()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            user2.username = usernameTextBox.Text;
            user2.password = passwordTextBox.Text;

            CheckUser();
        }

        private void CheckUser()
        {
            string sqlqueryName = "select * from Users where Username=@username";

            try
            {
                using (conn = new SqlConnection(ConnectionString))
                using (SqlCommand comm = new SqlCommand(sqlqueryName, conn))
                {
                    ConnOpen();
                    comm.Parameters.AddWithValue("@username", usernameTextBox.Text);
                    //int ok = comm.ExecuteNonQuery();
                    
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                success = false;
                ShowSuccess();
            }

        }

        private void ShowSuccess()
        {
            if (success == true)
            {
                MessageBox.Show("Login success!");
                this.Close();
            }
            else if (success == false)
            {
                MessageBox.Show("Login failure. Please try again.");
                ClearBoxes();
            }
        }

        private void ConnOpen() {
            conn.Open();
        }

        private void ConnClose() {
            conn.Close();
        }

        private void ClearBoxes()
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            usernameTextBox.Focus();
        }
    }
}
