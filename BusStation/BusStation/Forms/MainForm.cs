﻿using BusStation.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusStation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {
            UserAccess a = new UserAccess();
            var b = a.getUsers();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            StationAccess db = new StationAccess();
            string str = db.Insert(textBox1.Text);
            textBox2.Text = str;
        }

    }
}
