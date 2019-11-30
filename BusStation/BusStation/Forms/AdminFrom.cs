﻿using BusStation.DataAccess;
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
        public AdminFrom(User user = null)
        {
            currentUser = user;
           if(user == null)
            {
                currentUser = new User(0,"1","1","Ivan", "Stefanyshyn", DateTime.Now);

            }
            InitializeComponent();
            accessUser(currentUser);

            EditTabControl.Visible = true;
            EditTabControl.Dock = DockStyle.Fill;
            Ticketpanel.Visible = false;
            ProfileAdminTabControl.Visible = false;

            StopDateTimePicker.Format = DateTimePickerFormat.Custom;
            StopDateTimePicker.CustomFormat = "HH:mm";
        }

        private const int ADD_STATION_HEIGHT = 54;
        private const int ADD_BUS_HEIGHT = 54;
        private const int ADD_USER_HEIGHT = 89;
        private const int ADD_TRIP_HEIGHT = 118;

        private string userSearchEditString;
        private string stationSearchString;
        private string busSearchString;
        private string tripSearchString;
        private string stopSearchString;
        private User currentUser = null;
        private TableLayoutPanel currentDocument;

        private void accessUser(User user)
        {
            isAuthorUser(user);
            isNotAuthorUser(user);
        }
        private void isAuthorUser(User user)
        {
            if (user != null && user.Id != 0)
                this.EditButton.Visible = false;
        }
        private void isNotAuthorUser(User user)
        {
            if (user == null)
            {
                this.EditButton.Visible = false;
                this.ProfileButton.Visible = false;
                this.LogOutButton.Text = "Sign in";
            }
        }
        private DataGridView EditStyleColumn(DataGridView grid)
        {
            if (grid.Columns.Count > 0 && !(grid.Columns[0] is DataGridViewCheckBoxColumn))
                grid.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            
            grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            grid.Columns[0].HeaderText = "Active to edit";
            grid.Columns[0].Width = 145;

            grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            grid.Columns[1].Width = 50;
            grid.Columns[1].ReadOnly = true;

            for (int i = 1; i < grid.Columns.Count; ++i)
                grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            return grid;
        }

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
            string s = ((ComboBox)sender).Text;
            //is current document
            TableLayoutPanel temp = null;
            //hide prev document
            if (currentDocument != null) currentDocument.Visible = false;

            if (s == "Student")
            {
                StudentTableLayoutPanel42.Visible = true;
                temp = StudentTableLayoutPanel42;
            }
            else if (s == "Invalid")
            {
                InvalidTableLayoutPanel43.Visible = true;
                temp = InvalidTableLayoutPanel43;
            }
            else if (s == "None")
            {
                temp = null;
            }

            if (temp != null && temp != currentDocument)
            {
                currentDocument = temp;
            }
        }

        private void TripSearchButton_Click(object sender, EventArgs e)
        {
            List<Trip> trips = new List<Trip>();
            trips.Add( new Trip{
                    Id = 1,
                    Bus = new Bus { Id = 1},
                    DateArrival = DateTime.Now,
                    DateDeparture = DateTime.Now,
                    StationFrom = "Ternopil ",
                    StationTo = "Lviv",
                    Distance = 30.2f,
                });
            trips.Add(new Trip
            {
                Id = 2,
                Bus = new Bus { Id = 2 },
                DateArrival = DateTime.Now,
                DateDeparture = DateTime.Now,
                StationTo = "Lviv",
                StationFrom = "Ternopil ",
                Distance = 13.2f,
            });

            const int h = 100;
            const int widthSecondColumn = 160;
            const int widthIntervalSecondColumn = 140;
            TripSearchPanel.Controls.Clear();

            for (int i = 0; i < trips.Count; ++i)
            {
                Panel TripPanel = this.InitTicketPanel();
                TripPanel.Location = new Point(5, i ==  0 ? 5 : h * i + 5 * (i + 1));

                Label idl = new Label();
                idl.Text = "Id";
                idl.AutoSize = true;
                idl.Size = new Size(50, 25);
                idl.Location = new Point(5, 5);

                Label id = new Label();
                id.Text = Convert.ToString(trips[i].Id);
                id.AutoSize = true;
                id.Size = new Size(100, 25);
                id.Location = new Point(60, 5);

                Label labelF = new Label();
                labelF.Text = "From";
                labelF.AutoSize = true;
                labelF.Size = new Size(50, 25);
                labelF.Location = new Point(5, 37);

                Label stationF = new Label();
                stationF.Text = trips[i].StationFrom;
                stationF.AutoSize = true;
                stationF.Size = new Size(100, 25);
                stationF.Location = new Point(60, 37);

                Label labelT = new Label();
                labelT.Text = "To";
                labelT.AutoSize = true;
                labelT.Size = new Size(50, 25);
                labelT.Location = new Point(5, TripPanel.Height - 30);

                Label stationT = new Label();
                stationT.Text = trips[i].StationTo;
                stationT.AutoSize = true;
                stationT.Size = new Size(100, 25);
                stationT.Location = new Point(60, TripPanel.Height - 30);

                Label dateDeparture = new Label();
                dateDeparture.Text = "Date departure";
                dateDeparture.AutoSize = true;
                dateDeparture.Size = new Size(50, 25);
                dateDeparture.Location = new Point(widthSecondColumn, 5);

                Label date = new Label();
                date.Text = trips[i].DateDeparture.ToString();
                date.AutoSize = true;
                date.Size = new Size(100, 25);
                date.Location = new Point(widthSecondColumn + widthIntervalSecondColumn, 5);

                Label seatLabel = new Label();
                seatLabel.Text = "Seats";
                seatLabel.AutoSize = true;
                seatLabel.Size = new Size(50, 25);
                seatLabel.Location = new Point(widthSecondColumn, TripPanel.Height - 30);

                Label seat = new Label();
                seat.Text = Convert.ToString(trips[i].Bus.Seats);
                seat.AutoSize = true;
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
            panel.BackColor = Color.LightGray;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Width = 600;
            panel.Height = 100;
            panel.BorderStyle = BorderStyle.FixedSingle;
            return panel;
        }
        private void Document_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox doc = (ComboBox)selectTicket.Controls[4];
            if (doc.Text == "Student")
            {
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
            selectTicket.BackColor = Color.LightGray;

            var data = ((Panel)sender).Controls;
            string id = ((Label)data[1]).Text;
            string stationFrom = ((Label)data[3]).Text;
            string stationTo = ((Label)data[5]).Text;

            Label titleLabel = new Label();
            titleLabel.Text = "#" + id + " -|- " + stationFrom + " <===> " + stationTo + " -|- ";
            titleLabel.AutoSize = true;
            titleLabel.Height = 25;
            titleLabel.Location = new Point(5, 5);

            Label seatLabel = new Label();
            seatLabel.Text = "Seat";
            seatLabel.AutoSize = true;
            seatLabel.Size = new Size(50, 25);
            seatLabel.Location = new Point(5, 35);

            ComboBox seats = new ComboBox();
            seats.DropDownStyle = ComboBoxStyle.DropDownList;
            seats.Size = new Size(150, 25);
            seats.Location = new Point(5, 65);

            Label documentLabel = new Label();
            documentLabel.Text = "Document";
            documentLabel.AutoSize = true;
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
            documentSeriesLabel.Size = new Size(50, 25);
            documentSeriesLabel.Location = new Point(5, 165);

            TextBox series = new TextBox();
            series.AutoSize = true;
            series.Size = new Size(130, 25);
            series.Location = new Point(5, 195);
            series.Enabled = false;

            Label documentInvalidLabel = new Label();
            documentInvalidLabel.Text = "Invalid";
            documentInvalidLabel.AutoSize = true;
            documentInvalidLabel.Size = new Size(50, 25);
            documentInvalidLabel.Location = new Point(140, 165);

            ComboBox invalid = new ComboBox();
            invalid.DropDownStyle = ComboBoxStyle.DropDownList;
            invalid.Items.Add("Invalid1");
            invalid.Items.Add("Invalid2");
            invalid.Items.Add("Invalid3");
            invalid.Items.Add("Invalid4");
            invalid.Size = new Size(140, 25);
            invalid.Location = new Point(140, 195);
            invalid.Enabled = false;

            Label firstNameLabel = new Label();
            firstNameLabel.Text = "FirstName";
            firstNameLabel.AutoSize = true;
            firstNameLabel.Size = new Size(50, 25);
            firstNameLabel.Location = new Point(5, 230);

            TextBox firstName = new TextBox();
            firstName.AutoSize = true;
            firstName.Size = new Size(130, 25);
            firstName.Location = new Point(110, 230);

            Label lastNameLabel = new Label();
            lastNameLabel.Text = "LastName";
            lastNameLabel.AutoSize = true;
            lastNameLabel.Size = new Size(50, 25);
            lastNameLabel.Location = new Point(5, 265);

            TextBox lastName = new TextBox();
            lastName.AutoSize = true;
            lastName.Size = new Size(130, 25);
            lastName.Location = new Point(110, 265);

            Label costLabel = new Label();
            costLabel.Text = "Cost";
            costLabel.AutoSize = true;
            costLabel.Size = new Size(50, 25);
            costLabel.Location = new Point(5, 295);

            Label cost = new Label();
            cost.Text = "65";
            cost.AutoSize = true;
            cost.Size = new Size(50, 25);
            cost.Location = new Point(65, 295);

            Button buy = new Button();
            buy.Text = "Buy";
            buy.AutoSize = true;
            buy.BackColor = Color.LightSkyBlue;
            buy.Size = new Size(150, 50);
            buy.Location = new Point(5, 325);
            buy.MouseClick += new MouseEventHandler(this.Buy_MouseClick);

            selectTicket.AutoSize = true;
            selectTicket.AutoSizeMode = AutoSizeMode.GrowOnly;

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
            
            TicketSelecttableLayoutPanel46.AutoScroll = true;

            tableLayoutPanel42.Visible = false;
            TicketSelecttableLayoutPanel46.Dock = DockStyle.Fill;
            TicketSelecttableLayoutPanel46.Visible = true;
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
            tableLayoutPanel42.Dock = DockStyle.Fill;
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            ProfileAdminTabControl.Dock = DockStyle.Fill;
            ProfileAdminTabControl.Visible = true;
            EditTabControl.Visible = false;
            Ticketpanel.Visible = false;

            fillProfile(currentUser);
        }
        private void fillProfile(User user) 
        {
            if(user != null)
            {
                var profile = user.getProfile();
                if (profile != null)
                {
                    FirstnameTextBox.Text = profile.FirstName;
                    LastnameTextBox.Text = profile.LastName;
                }
                UsernameTextBox.Text = user.Username;
            }
        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization form = new Authorization();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void UserSearchButton_Click(object sender, EventArgs e)
        {
            userSearchEditString = UserSearchTextBox.Text.Trim();
            UserAccess db = new UserAccess();
            var a = "olehhh";
            var b = a.Contains("leh");
            List<User> users = userSearchEditString == "" ?
                db.GetAll() :
                db.GetManyBySelector(user =>
                    user.getProfile().FirstName.Contains(userSearchEditString)
                    || user.getProfile().LastName.Contains(userSearchEditString)
                    || user.Username.Contains(userSearchEditString));

            DataGridView grid = UserDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = users;
            grid.DataSource = bind;

             EditStyleColumn(grid);
        }

        private void StationSearchButton_Click(object sender, EventArgs e)
        {
            stationSearchString = StationSearchTextBox.Text;

            List<Station> stations = new List<Station>();
            StationAccess db = new StationAccess();

            stations = db.GetManyBySelector(station => station.name.Contains(stationSearchString));

            DataGridView grid = StationDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = stations;
            grid.DataSource = bind;

            EditStyleColumn(grid);
        }

        private void BusSearchButton_Click(object sender, EventArgs e)
        {
            busSearchString = BusSearchTextBox.Text.Trim();
            List<Bus> buses = new List<Bus>();
            int seats = -1;
            try
            {
                seats = Convert.ToInt32(busSearchString);
            }
            catch (Exception ex)
            {}
            BusAccess db = new BusAccess();

            if (seats < 0) buses = db.GetAll();
            else buses = db.GetManyBySelector(bus => bus.Seats == seats);

            DataGridView grid = BusDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = buses;
            grid.DataSource = bind;

            EditStyleColumn(grid);
        }

        private void TripSearchEditButton_Click(object sender, EventArgs e)
        {
            List<Trip> trips = new List<Trip>();


            DataGridView grid = StopDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = trips;
            grid.DataSource = bind;

            EditStyleColumn(grid);
        }

        private void UserApplyButton_Click(object sender, EventArgs e)
        {
            var rows = UserDataGridView.Rows;

            foreach(DataGridViewRow row in rows)
            {
                var a = Convert.ToBoolean(((DataGridViewCheckBoxCell)(row.Cells[0])).Value);
                if (a)
                {
                    int id = Convert.ToInt32(((DataGridViewTextBoxCell)(row.Cells[1])).Value);
                    string username = ((DataGridViewTextBoxCell)(row.Cells[2])).Value.ToString();
                    string password = ((DataGridViewTextBoxCell)(row.Cells[3])).Value.ToString();
                    User user = new User(id, username, password, DateTime.Now);
                    UserAccess db = new UserAccess();
                    db.UpdateUser(user);
                }
            }
        }

        private void UserDeleteButton_Click(object sender, EventArgs e)
        {
            var rows = UserDataGridView.Rows;
            List<int> indexs = new List<int>();
            foreach (DataGridViewRow row in rows)
            {
                var a = Convert.ToBoolean(((DataGridViewCheckBoxCell)(row.Cells[0])).Value);
                if (a)
                    indexs.Add(row.Index);
            }
            for (int i = indexs.Count - 1; i >= 0; --i)
            {
                int index = indexs.ElementAt<int>(i);
                long id = Convert.ToInt64(((DataGridViewTextBoxCell)(rows[index].Cells[1])).Value);
                UserAccess db = new UserAccess();
                db.DeleteUser(id);
                rows.RemoveAt(index);
            }
        }

        private void UserRefreshButton_Click(object sender, EventArgs e)
        {
            if (userSearchEditString == null) return;
            UserAccess db = new UserAccess();
            List<User> users = userSearchEditString == "" ?
                db.GetAll() :
                db.GetManyBySelector(user =>
                    user.getProfile().FirstName.Contains(userSearchEditString)
                    || user.getProfile().LastName.Contains(userSearchEditString));

            DataGridView grid = UserDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = users;
            grid.DataSource = bind;

            EditStyleColumn(grid);
        }

        private void UserAddButton_Click(object sender, EventArgs e)
        {
            string username = UserUsernameTextBox.Text.Trim();
            string password = UserPasswordTextBox.Text.Trim();
            if(username != "" && password != "")
            {
                User user = new User(1, username, password, "", "", DateTime.Now);
                UserAccess db = new UserAccess();
                BindingSource source = (BindingSource)UserDataGridView.DataSource;

                if ((source != null && source.List.Count == 0) || source == null)
                {
                    List<User> users = new List<User>();
              
                    db.Add(user);
                    users.Add(user);

                    DataGridView grid = UserDataGridView;
                    grid.Rows.Clear();
                    BindingSource bind = new BindingSource();
                    bind.DataSource = users;
                    grid.DataSource = bind;

                    EditStyleColumn(UserDataGridView);
                    return;
                }

                db.Add(user);
                source.List.Add(user);

                UserDataGridView.DataSource = null;
                UserDataGridView.DataSource = source;

                EditStyleColumn(UserDataGridView);
            }

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            resultResetPassword.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = FirstnameTextBox.Text;
            string lastname = LastnameTextBox.Text;
            firstname = firstname == null ? "" : firstname.Trim();
            lastname = lastname == null ? "" : lastname.Trim();

            Profile profile = new Profile
            {
                Id = currentUser.Id,
                FirstName = firstname,
                LastName = lastname
            };

            currentUser.setProfile(profile);
        }

        private void StationRefreshButton_Click(object sender, EventArgs e)
        {
            if (stationSearchString == null) return;

            List<Station> stations = new List<Station>();
            StationAccess db = new StationAccess();

            stations = db.GetManyBySelector(station => station.name.Contains(stationSearchString));

            DataGridView grid = StationDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = stations;
            grid.DataSource = bind;

            EditStyleColumn(grid);
        }

        private void StationAddButton_Click(object sender, EventArgs e)
        {
            string name = StationNameTextBox.Text.Trim();
            if (name != "")
            {
                Station station = new Station { id = 1, name = name };
                StationAccess db = new StationAccess();
                BindingSource source = (BindingSource)StationDataGridView.DataSource;

                if (db.GetManyBySelector(obj => obj.name.Contains(name)).Count > 0)
                {
                    MessageBox.Show("The station name is exist");
                    return;
                }

                if ((source != null && source.List.Count == 0) || source == null)
                {
                    List<Station> stations = new List<Station>();

                    db.Add(station);
                    stations.Add(station);

                    DataGridView grid = StationDataGridView;
                    grid.Rows.Clear();
                    BindingSource bind = new BindingSource();
                    bind.DataSource = stations;
                    grid.DataSource = bind;

                    EditStyleColumn(StationDataGridView);
                    return;
                }

                db.Add(station);
                source.List.Add(station);

                StationDataGridView.DataSource = null;
                StationDataGridView.DataSource = source;

                EditStyleColumn(StationDataGridView);
            }
        }

        private void StationDeleteButton_Click(object sender, EventArgs e)
        {
            var rows = StationDataGridView.Rows;
            List<int> indexs = new List<int>();
            foreach (DataGridViewRow row in rows)
            {
                var a = Convert.ToBoolean(((DataGridViewCheckBoxCell)(row.Cells[0])).Value);
                if (a)
                    indexs.Add(row.Index);
            }
            for (int i = indexs.Count - 1; i >= 0; --i)
            {
                int index = indexs.ElementAt<int>(i);
                long id = Convert.ToInt64(((DataGridViewTextBoxCell)(rows[index].Cells[1])).Value);
                StationAccess db = new StationAccess();
                db.Delete(id);
                rows.RemoveAt(index);
            }
        }

        private void StationUpdateButton_Click(object sender, EventArgs e)
        {
            var rows = StationDataGridView.Rows;

            foreach (DataGridViewRow row in rows)
            {
                var a = Convert.ToBoolean(((DataGridViewCheckBoxCell)(row.Cells[0])).Value);
                if (a)
                {
                    int id = Convert.ToInt32(((DataGridViewTextBoxCell)(row.Cells[1])).Value);
                    string name = ((DataGridViewTextBoxCell)(row.Cells[2])).Value.ToString();
                    Station station = new Station { id = id, name = name };
                    StationAccess db = new StationAccess();
                    db.Update(station);
                }
            }
        }

        private void BusRefreshButton_Click(object sender, EventArgs e)
        {
            if (busSearchString == null) return;

            List<Bus> buses = new List<Bus>();
            int seats = -1;
            try
            {
                seats = Convert.ToInt32(busSearchString);
            }
            catch (Exception ex)
            { }
            BusAccess db = new BusAccess();

            if (seats < 0) buses = db.GetAll();
            else buses = db.GetManyBySelector(bus => bus.Seats == seats);

            DataGridView grid =BusDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = buses;
            grid.DataSource = bind;

            EditStyleColumn(grid);
        }

        private void BusDeleteButton_Click(object sender, EventArgs e)
        {
            var rows = BusDataGridView.Rows;
            List<int> indexs = new List<int>();
            foreach (DataGridViewRow row in rows)
            {
                var a = Convert.ToBoolean(((DataGridViewCheckBoxCell)(row.Cells[0])).Value);
                if (a)
                    indexs.Add(row.Index);
            }
            for (int i = indexs.Count - 1; i >= 0; --i)
            {
                int index = indexs.ElementAt<int>(i);
                long id = Convert.ToInt64(((DataGridViewTextBoxCell)(rows[index].Cells[1])).Value);
                BusAccess db = new BusAccess();
                db.Delete(id);
                rows.RemoveAt(index);
            }

        }

        private void BusUpdateButton_Click(object sender, EventArgs e)
        {
            var rows = BusDataGridView.Rows;

            foreach (DataGridViewRow row in rows)
            {
                var a = Convert.ToBoolean(((DataGridViewCheckBoxCell)(row.Cells[0])).Value);
                if (a)
                {
                    int id = Convert.ToInt32(((DataGridViewTextBoxCell)(row.Cells[1])).Value);
                    int seats = Convert.ToInt32(((DataGridViewTextBoxCell)(row.Cells[2])).Value);
                    Bus bus = new Bus { Id = id, Seats = seats };
                    BusAccess db = new BusAccess();
                    db.Update(bus);
                }
            }

        }

        private void BusAddButton_Click(object sender, EventArgs e)
        {
            string seatsStr = BusSeatsTextBox.Text.Trim();
            if (seatsStr != "")
            {
                int seats = Convert.ToInt32(seatsStr);
                Bus bus = new Bus { Id = 1, Seats = seats };
                BusAccess db = new BusAccess();
                BindingSource source = (BindingSource)BusDataGridView.DataSource;

                if ((source != null && source.List.Count == 0) || source == null)
                {
                    List<Bus> buses = new List<Bus>();

                    db.Add(bus);
                    buses.Add(bus);

                    DataGridView grid = BusDataGridView;
                    grid.Rows.Clear();
                    BindingSource bind = new BindingSource();
                    bind.DataSource = buses;
                    grid.DataSource = bind;

                    EditStyleColumn(BusDataGridView);
                    return;
                }

                db.Add(bus);
                source.List.Add(bus);

                BusDataGridView.DataSource = null;
                BusDataGridView.DataSource = source;

                EditStyleColumn(BusDataGridView);
            }

        }

        private void StopStationComboBox_Click(object sender, EventArgs e)
        {
            StationAccess db = new StationAccess();
            var stations = db.GetAll();
            this.StopStationComboBox.Items.Clear();
            for (int i = 0; i < stations.Count; ++i)
            {
                this.StopStationComboBox.Items.Add(stations[i].name.ToString());
            }
        }

        private void StopBusComboBox_Click(object sender, EventArgs e)
        {
            BusAccess db = new BusAccess();
            var buses = db.GetAll();
            this.StopBusComboBox.Items.Clear();
            for (int i = 0; i < buses.Count; ++i)
            {
                this.StopBusComboBox.Items.Add(buses[i].Id.ToString());
            }
        }

        private void StopSearchEditButton_Click(object sender, EventArgs e)
        {
            stopSearchString = StopSearchTextBox.Text.Trim();
            List<Stop> stops = new List<Stop>();
            StopAccess db = new StopAccess();

            if (busSearchString == null) stops = db.GetAll();
            else stops = db.GetManyBySelector(
                stop => stop.bus.ToString() == stopSearchString
                || stop.station.name.Contains(stopSearchString)
                || stop.distance.ToString().Contains(stopSearchString)
                );

            DataGridView grid = StopDataGridView;
            grid.Rows.Clear();
            BindingSource bind = new BindingSource();
            bind.DataSource = stops;
            grid.DataSource = bind;

            EditStyleColumn(grid);

        }
    }
}
