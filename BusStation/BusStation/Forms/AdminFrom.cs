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
            List<Trip> trips = new List<Trip>();
            List<Station> stations = new List<Station>();
            stations.Add(new Station { id = 1, name = "Ternopil" });
            stations.Add(new Station { id = 2, name = "Lviv" });
            trips.Add(
                new Trip
                {
                    Id = 1,
                    Bus = new Bus { Id = 1, Seats = 11 },
                    DateArrival = DateTime.Now,
                    DateDeparture = DateTime.Now,
                    Stations = stations
                });
            stations = new List<Station>();
            stations.Add(new Station { id = 1, name = "Ternopil" });
            stations.Add(new Station { id = 2, name = "Lviv" }); stations.Add(new Station { id = 2, name = "Krakov" });
            trips.Add(
                new Trip
                {
                    Id = 2,
                    Bus = new Bus { Id = 2, Seats = 22 },
                    DateArrival = DateTime.Now,
                    DateDeparture = DateTime.Now,
                    Stations = stations
                });

            const int h = 100;
            const int widthSecondColumn = 160;
            const int widthIntervalSecondColumn = 140;
            TripSearchPanel.Controls.Clear();
            
            for (int i = 0; i < trips.Count; ++i)
            {
                Panel TripPanel = this.InitTicketPanel();
                TripPanel.Location = new Point(5, i == 0 ? 5 : h * i + 5 * (i + 1));

                Label idl = new Label();
                idl.Text = "Id";
                idl.AutoSize = true;
                idl.BackColor = Color.Red;
                idl.Size = new Size(50, 25);
                idl.Location = new Point(5, 5);

                Label id = new Label();
                id.Text = Convert.ToString(trips[i].Id);
                id.AutoSize = true;
                id.BackColor = Color.Red;
                id.Size = new Size(100, 25);
                id.Location = new Point(60, 5);

                Label labelF = new Label();
                labelF.Text = "From";
                labelF.AutoSize = true;
                labelF.BackColor = Color.Red;
                labelF.Size = new Size(50, 25);
                labelF.Location = new Point(5, 37);

                Label stationF = new Label();
                stationF.Text = trips[i].Stations[0].name;
                stationF.AutoSize = true;
                stationF.BackColor = Color.Red;
                stationF.Size = new Size(100, 25);
                stationF.Location = new Point(60, 37);

                Label labelT = new Label();
                labelT.Text = "To";
                labelT.AutoSize = true;
                labelT.BackColor = Color.Red;
                labelT.Size = new Size(50, 25);
                labelT.Location = new Point(5, TripPanel.Height - 30);

                Label stationT = new Label();
                stationT.Text = trips[i].Stations[trips[i].Stations.Count-1].name;
                stationT.AutoSize = true;
                stationT.BackColor = Color.Red;
                stationT.Size = new Size(100, 25);
                stationT.Location = new Point(60, TripPanel.Height - 30);

                Label dateDeparture = new Label();
                dateDeparture.Text = "Date departure";
                dateDeparture.AutoSize = true;
                dateDeparture.BackColor = Color.Red;
                dateDeparture.Size = new Size(50, 25);
                dateDeparture.Location = new Point(widthSecondColumn, 5);

                Label date = new Label();
                date.Text = trips[i].DateDeparture.ToString();
                date.AutoSize = true;
                date.BackColor = Color.Red;
                date.Size = new Size(100, 25);
                date.Location = new Point(widthSecondColumn + widthIntervalSecondColumn, 5);

                Label seatLabel = new Label();
                seatLabel.Text = "Seats";
                seatLabel.AutoSize = true;
                seatLabel.BackColor = Color.Red;
                seatLabel.Size = new Size(50, 25);
                seatLabel.Location = new Point(widthSecondColumn, TripPanel.Height - 30);

                Label seat = new Label();
                seat.Text = Convert.ToString(trips[i].Bus.Seats);
                seat.AutoSize = true;
                seat.BackColor = Color.Red;
                seat.Size = new Size(100, 25);
                seat.Location = new Point(widthSecondColumn + widthIntervalSecondColumn, TripPanel.Height - 30);

                TripPanel.Controls.Add(idl);
                TripPanel.Controls.Add(id);
                TripPanel.Controls.Add(labelF);
                TripPanel.Controls.Add(stationF);
                TripPanel.Controls.Add(labelT);
                TripPanel.Controls.Add(stationT);
                TripPanel.Controls.Add(dateDeparture);
                TripPanel.Controls.Add(date);
                TripPanel.Controls.Add(seatLabel);
                TripPanel.Controls.Add(seat);

                TripPanel.MouseClick += new MouseEventHandler(this.Trip_Click);

                TripSearchPanel.Controls.Add(TripPanel);
            }
        }
        private Panel InitTicketPanel()
        {
            Panel panel = new Panel();
            panel.BackColor = Color.Blue;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Width = 600;
            panel.Height = 100;
            panel.BorderStyle = BorderStyle.FixedSingle;
            return panel;
        }
        private void Document_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox doc = (ComboBox)selectTicket.Controls[4];
            if(doc.Text == "Student"){
                TextBox t = (TextBox)selectTicket.Controls[6];
                t.Enabled = true;
            }
            else if (doc.Text == "Invalid")
            {
                ComboBox c = (ComboBox)selectTicket.Controls[8];
                c.Enabled = true;
                TextBox t = (TextBox)selectTicket.Controls[6];
                t.Enabled = true;
            }
            else
            {
                ComboBox c = (ComboBox)selectTicket.Controls[8];
                c.Enabled = false;
                TextBox t = (TextBox)selectTicket.Controls[6];
                t.Enabled = false;
            }
            return;
        }
        private void Trip_Click(object sender, EventArgs e)
        {

            selectTicket.Dock = DockStyle.Fill;
            selectTicket.BackColor = Color.Blue;

            Label titleLabel = new Label();
            titleLabel.Text = "title";
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Red;
            titleLabel.Height = 25;
            titleLabel.Location = new Point(5, 5);

            Label seatLabel = new Label();
            seatLabel.Text = "Seat";
            seatLabel.AutoSize = true;
            seatLabel.BackColor = Color.Red;
            seatLabel.Size = new Size(50, 25);
            seatLabel.Location = new Point(5, 35);

            ComboBox seats = new ComboBox();
            seats.DropDownStyle = ComboBoxStyle.DropDownList;
            seats.Size = new Size(150, 25);
            seats.Location = new Point(5, 65);

            Label documentLabel = new Label();
            documentLabel.Text = "Document";
            documentLabel.AutoSize = true;
            documentLabel.BackColor = Color.Red;
            documentLabel.Size = new Size(50, 25);
            documentLabel.Location = new Point(5, 100);

            ComboBox document = new ComboBox();
            document.DropDownStyle = ComboBoxStyle.DropDownList;
            document.Items.Add("None");
            document.Items.Add("Student");
            document.Items.Add("Invalid");
            document.Size = new Size(150, 25);
            document.Location = new Point(5, 130);
            document.SelectedValueChanged += new EventHandler(this.Document_SelectedValueChanged);

            Label documentSeriesLabel = new Label();
            documentSeriesLabel.Text = "Series";
            documentSeriesLabel.AutoSize = true;
            documentSeriesLabel.BackColor = Color.Red;
            documentSeriesLabel.Size = new Size(50, 25);
            documentSeriesLabel.Location = new Point(5, 165);

            TextBox series = new TextBox();
            series.AutoSize = true;
            series.BackColor = Color.Red;
            series.Size = new Size(130, 25);
            series.Location = new Point(5, 195);
            series.Enabled = false;

            Label documentInvalidLabel = new Label();
            documentInvalidLabel.Text = "Invalid";
            documentInvalidLabel.AutoSize = true;
            documentInvalidLabel.BackColor = Color.Red;
            documentInvalidLabel.Size = new Size(50, 25);
            documentInvalidLabel.Location = new Point(140, 165);

            ComboBox invalid = new ComboBox();
            invalid.DropDownStyle = ComboBoxStyle.DropDownList;
            invalid.Items.Add("Invalid1");
            invalid.Items.Add("Invalid2");
            invalid.Items.Add("Invalid3");
            invalid.Items.Add("Invalid4");
            invalid.BackColor = Color.Red;
            invalid.Size = new Size(140, 25);
            invalid.Location = new Point(140, 195);
            invalid.Enabled = false;

            Label firstNameLabel = new Label();
            firstNameLabel.Text = "FirstName";
            firstNameLabel.AutoSize = true;
            firstNameLabel.BackColor = Color.Red;
            firstNameLabel.Size = new Size(50, 25);
            firstNameLabel.Location = new Point(5, 230);

            TextBox firstName = new TextBox();
            firstName.AutoSize = true;
            firstName.BackColor = Color.Red;
            firstName.Size = new Size(130, 25);
            firstName.Location = new Point(110, 230);
            firstName.Enabled = false;

            Label lastNameLabel = new Label();
            lastNameLabel.Text = "LastName";
            lastNameLabel.AutoSize = true;
            lastNameLabel.BackColor = Color.Red;
            lastNameLabel.Size = new Size(50, 25);
            lastNameLabel.Location = new Point(5, 265);

            TextBox lastName = new TextBox();
            lastName.AutoSize = true;
            lastName.BackColor = Color.Red;
            lastName.Size = new Size(130, 25);
            lastName.Location = new Point(110, 265);
            lastName.Enabled = false;

            Label costLabel = new Label();
            costLabel.Text = "Cost";
            costLabel.AutoSize = true;
            costLabel.BackColor = Color.Red;
            costLabel.Size = new Size(50, 25);
            costLabel.Location = new Point(5, 295);

            Label cost = new Label();
            cost.Text = "65";
            cost.AutoSize = true;
            cost.BackColor = Color.Red;
            cost.Size = new Size(50, 25);
            cost.Location = new Point(65, 295);

            Button buy = new Button();
            buy.Text = "Buy";
            buy.AutoSize = true;
            buy.BackColor = Color.Red;
            buy.Size = new Size(150, 50);
            buy.Location = new Point(5, 325);
            buy.MouseClick += new MouseEventHandler(this.Buy_MouseClick);

            selectTicket.Controls.Clear();
            selectTicket.Controls.Add(titleLabel);
            selectTicket.Controls.Add(seatLabel);
            selectTicket.Controls.Add(seats);
            selectTicket.Controls.Add(documentLabel);
            selectTicket.Controls.Add(document);
            selectTicket.Controls.Add(documentSeriesLabel);
            selectTicket.Controls.Add(series);
            selectTicket.Controls.Add(documentInvalidLabel);
            selectTicket.Controls.Add(invalid);
            selectTicket.Controls.Add(firstNameLabel);
            selectTicket.Controls.Add(firstName);
            selectTicket.Controls.Add(lastNameLabel);
            selectTicket.Controls.Add(lastName);
            selectTicket.Controls.Add(costLabel);
            selectTicket.Controls.Add(cost);
            selectTicket.Controls.Add(buy);

            tableLayoutPanel42.Visible = false;
            TicketSelecttableLayoutPanel46.Dock = DockStyle.Fill;
            TicketSelecttableLayoutPanel46.Visible = true;
            Ticketpanel.Controls.Add(TicketSelecttableLayoutPanel46);
        }


        private void Buy_MouseClick(object sender, EventArgs e)
        {
            TicketSelecttableLayoutPanel46.Visible = false;
            tableLayoutPanel42.Visible = true;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditTabControl.Dock = DockStyle.Fill;
            EditTabControl.Visible = true;
            Ticketpanel.Visible = false;
            ProfileAdminTabControl.Visible = false;
        }

        private void TicketButton_Click(object sender, EventArgs e)
        {
            Ticketpanel.Dock = DockStyle.Fill;
            Ticketpanel.Visible = true;
            EditTabControl.Visible = false;
            ProfileAdminTabControl.Visible = false;
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            ProfileAdminTabControl.Dock = DockStyle.Fill;
            ProfileAdminTabControl.Visible = true;
            EditTabControl.Visible = false;
            Ticketpanel.Visible = false;
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {

        }
    }
}
