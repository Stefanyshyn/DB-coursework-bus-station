using BusStation.DataAccess;
using BusStation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusStation.Forms
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            string _username = username.Text;
            string _password = password.Text;
            if (username.Text.Trim() != "" && password.Text.Trim() != "")
            {

                UserAccess db = new UserAccess();
                List<User> users = db.GetAll(user => user.Username == _username && user.Password == _password);
                if (users.Count != 0)
                {
                    MessageBox.Show("Success");
                }
                else
                    MessageBox.Show("Fail");
            }else
                MessageBox.Show("Fail");
        }
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string _username = username.Text.Trim();
            string _password = password.Text.Trim();
            if (_username != "" && _password != "")
            {

                UserAccess db = new UserAccess();
                List<User> users = db.GetAll(user => user.Username.Trim() == _username && user.Password.Trim() == _password);
                if (users.Count == 0)
                {
                    try
                    {
                        db.Insert(_username, _password);
                        MessageLabel.Text = "Successfull sign up";
                    }
                    catch (Exception ex)
                    {
                        MessageLabel.Text = ex.Message;
                    }
                }
                else
                    MessageLabel.Text = "This username exists. Enter a different username or use the username to sign in.";
            }
            else
                MessageLabel.Text = "Please enter username and password";
        }

        private void PasswordButton_MouseDown(object sender, MouseEventArgs e)
        {
            password.PasswordChar = '\0';
        }

        private void PasswordButton_MouseUp(object sender, MouseEventArgs e)
        {
            password.PasswordChar = '*';
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }
    }
}
