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

namespace BankPractice_v1_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            User user1 = new User();
            user1.username = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.Contains()) { }
        }
    }
}
