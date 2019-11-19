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
            string _username = username.Text;
            string _password = password.Text;
            if (username.Text.Trim() != "" && password.Text.Trim() != "")
            {
                UserAccess db = new UserAccess();
                List<User> users = db.GetAll(user => user.Username == _username && user.Password == _password);
                if (users.Count == 0)
                {
                    db.Insert(_username, _password);
                    MessageBox.Show("Insert");
                }
                else
                    MessageBox.Show("Fail");
            }
            else
                MessageBox.Show("Fail");
        }
    }
}
