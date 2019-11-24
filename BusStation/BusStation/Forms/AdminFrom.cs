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
    public partial class AdminFrom : Form
    {
        public AdminFrom()
        {
            InitializeComponent();
        }
        private const int ADD_STATION_HEIGHT = 54;
        private const int ADD_BUS_HEIGHT = 54;
        private const int ADD_USER_HEIGHT = 89;
        private const int ADD_TRIP_HEIGHT = 118;
        private const int COMBOBOX_DOCUMENT_STUDENT_HEIGHT = 106;



        private TableLayoutPanel currentDisability;
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

        private void TripSwitcherButton_Click(object sender, EventArgs e)
        {
            var a = tableLayoutPanel28.RowStyles;
            if (a[1].Height == 0)
                a[1].Height = ADD_TRIP_HEIGHT;
            else
                a[1].Height = 0;
        }

        private void DocumentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentDisability != null)
                currentDisability.Visible = false;
            string s = ((ComboBox)sender).Text;
            if (s == "Student")
            {
                StudentTableLayoutPanel42.Visible = true;
                StudentTableLayoutPanel42.Height = 0;
                currentDisability = StudentTableLayoutPanel42;
            }
            if (s == "Invalid")
            {
                InvalidTableLayoutPanel43.Visible = true;
                currentDisability = InvalidTableLayoutPanel43;
            }
            tableLayoutPanel41.Refresh();
            tableLayoutPanel39.Refresh();

        }

        private void TripSearchButton_Click(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "ivan", "qwerty", new DateTime().Date));
            
            const int h = 100;
            const int widthSecondColumn = 142;
            const int widthIntervalSecondColumn = 140;
            TripSearchPanel.Controls.Clear();
            
            for (int i = 0; i < Convert.ToInt32(ToTripTextBox.Text)/*users.Count*/; ++i)
            {
                Panel TicketPanel = this.InitTicketPanel();
                TicketPanel.Location = new Point(5, i == 0 ? 5 : h * i + 5 * (i + 1));

                Label labelF = new Label();
                labelF.Text = "From";
                labelF.AutoSize = true;
                labelF.BackColor = Color.Red;
                labelF.Size = new Size(50, 25);
                labelF.Location = new Point(5, 5);

                Label stationF = new Label();
                stationF.Text = "Ternopil";
                stationF.AutoSize = true;
                stationF.BackColor = Color.Red;
                stationF.Size = new Size(100, 25);
                stationF.Location = new Point(60, 5);

                Label labelT = new Label();
                labelT.Text = "To";
                labelT.AutoSize = true;
                labelT.BackColor = Color.Red;
                labelT.Size = new Size(50, 25);
                labelT.Location = new Point(5, TicketPanel.Height - 30);

                Label stationT = new Label();
                stationT.Text = "Lviv";
                stationT.AutoSize = true;
                stationT.BackColor = Color.Red;
                stationT.Size = new Size(100, 25);
                stationT.Location = new Point(60, TicketPanel.Height - 30);

                Label dateDeparture = new Label();
                dateDeparture.Text = "Date departure";
                dateDeparture.AutoSize = true;
                dateDeparture.BackColor = Color.Red;
                dateDeparture.Size = new Size(50, 25);
                dateDeparture.Location = new Point(widthSecondColumn, 5);

                Label date = new Label();
                date.Text = "18.00 21.12.2019";
                date.AutoSize = true;
                date.BackColor = Color.Red;
                date.Size = new Size(100, 25);
                date.Location = new Point(widthSecondColumn + widthIntervalSecondColumn, 5);

                Label seatLabel = new Label();
                seatLabel.Text = "Seat";
                seatLabel.AutoSize = true;
                seatLabel.BackColor = Color.Red;
                seatLabel.Size = new Size(50, 25);
                seatLabel.Location = new Point(widthSecondColumn, 40);

                Label seat = new Label();
                seat.Text = "18";
                seat.AutoSize = true;
                seat.BackColor = Color.Red;
                seat.Size = new Size(50, 25);
                seat.Location = new Point(widthSecondColumn + widthIntervalSecondColumn, 40);

                Label documentLabel = new Label();
                documentLabel.Text = "Document";
                documentLabel.AutoSize = true;
                documentLabel.BackColor = Color.Red;
                documentLabel.Size = new Size(50, 25);
                documentLabel.Location = new Point(widthSecondColumn, TicketPanel.Height - 30);

                Label document = new Label();
                document.Text = "Student/series:TR2312E5321564";
                document.AutoSize = true;
                document.BackColor = Color.Red;
                document.Size = new Size(100, 25);
                document.Location = new Point(widthSecondColumn + widthIntervalSecondColumn, TicketPanel.Height - 30);

                TicketPanel.Controls.Add(labelF);
                TicketPanel.Controls.Add(labelT);
                TicketPanel.Controls.Add(stationF);
                TicketPanel.Controls.Add(stationT);
                TicketPanel.Controls.Add(dateDeparture);
                TicketPanel.Controls.Add(date);
                TicketPanel.Controls.Add(seatLabel);
                TicketPanel.Controls.Add(seat);
                TicketPanel.Controls.Add(documentLabel);
                TicketPanel.Controls.Add(document);

                TripSearchPanel.Controls.Add(TicketPanel);
            }
        }
        private Panel InitTicketPanel()
        {
            Panel panel = new Panel();
            panel.BackColor = Color.Blue;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Width = 600;
            panel.Height = 100;
            return panel;
        }
        private void TButton_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            MessageBox.Show(label.Text);
        }
    }
}
