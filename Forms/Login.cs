using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eish
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private int loginAttempts = 3;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = edtUser.Text;
            string pass = edtPass.Text;

            if (user != "User" || pass != "Password" )
            {
                loginAttempts--;
                if (loginAttempts > 0)
                {
                     MessageBox.Show($"Password is incorrect please try agagin. Login attempts left {loginAttempts}");
                }
                else
                {
                    MessageBox.Show("Login attempts is klaar");
                    btnLogin.Enabled = false;
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Password is correct");
                  
            }
        }
    }
}
