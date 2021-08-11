using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankPractice_v1_;

namespace BankPractice_v1_
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();

            CheckIfLogged();
        }

        private void CheckIfLogged() {
            if (loginBtn.Enabled == false)
            {
                infoBtn.Enabled = false;
                depositBtn.Enabled = false;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();

            if (loginBtn.Enabled)
            {
                loginBtn.Enabled = false;

            }
            else {
                loginBtn.Enabled = true;
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.Show();

            if (registerBtn.Enabled)
            {
                registerBtn.Enabled = false;
            }
            else {
                registerBtn.Enabled = true;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountInformation info = new AccountInformation();
            info.Show();
        }

        private void depositBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deposit deposit = new Deposit();
            deposit.Show();
        }
    }
}
