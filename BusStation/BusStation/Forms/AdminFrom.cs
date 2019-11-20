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
    public partial class AdminFrom : Form
    {
        public AdminFrom()
        {
            InitializeComponent();
        }
        private const int ADD_STATION_HEIGHT = 54;
        private const int ADD_BUS_HEIGHT = 54;
        private const int ADD_USER_HEIGHT = 89;
        private void StationAddSwitcher_Click(object sender, EventArgs e)
        {
            var a = tableLayoutPanel11.RowStyles;
            if (a[1].Height == 0)
                a[1].Height = ADD_STATION_HEIGHT;
            else
                a[1].Height = 0;
        }

        private void UserSwitcherButton_Click(object sender, EventArgs e)
        {
            var a = tableLayoutPanel10.RowStyles;
            if (a[1].Height == 0)
                a[1].Height = ADD_USER_HEIGHT;
            else
                a[1].Height = 0;
        }

        private void BusSwitcherButton_Click(object sender, EventArgs e)
        {
            var a = tableLayoutPanel23.RowStyles;
            if (a[1].Height == 0)
                a[1].Height = ADD_USER_HEIGHT;
            else
                a[1].Height = 0;
        }

    }
}
