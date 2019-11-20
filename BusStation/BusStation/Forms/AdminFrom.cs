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
        private const int ADD_USER_HEIGHT = 54;
        private void StationAddSwitcher_Click(object sender, EventArgs e)
        {
            var a = tableLayoutPanel11.RowStyles;
            if (a[1].Height == 0)
                a[1].Height = ADD_USER_HEIGHT;
            else
                a[1].Height = 0;
        }
    }
}
