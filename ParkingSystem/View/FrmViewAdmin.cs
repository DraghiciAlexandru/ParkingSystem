using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParkingSystem.Template;

namespace ParkingSystem.View
{
    public partial class FrmViewAdmin : Form
    {
        private Panel Header;
        private Panel Aside;
        private Panel Main;

        public FrmViewAdmin()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();

            layout();
        }

        public void layout()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.Size = Screen.FromHandle(this.Handle).WorkingArea.Size;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            setAside(Aside);
            setHeader(Header);
            setMain(Main);
        }

        public void setAside(Panel aside)
        {
            aside.Controls.Clear();
            aside.Size = new Size(250, this.Size.Height);
            aside.Location = new Point(0, 0);
            aside.BackColor = Color.White;
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            aside.BorderStyle = BorderStyle.FixedSingle;

            setBtnSettings(aside);
            setBtnStatistics(aside);
            setBtnFacilities(aside);
            setBtnDrivers(aside);
            setBtnGarage(aside);
            setBtnHome(aside);

            this.Controls.Add(aside);
        }

        public void setBtnHome(Panel aside)
        {
            Button btnHome = new Button();
            btnHome.Name = "btnHome";
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.Location = new Point(0, 0);
            btnHome.Size = new Size(250, 100);

            btnHome.Dock = DockStyle.Top;

            btnHome.Text = "Home";
            btnHome.ForeColor = Color.FromArgb(140, 100, 250);


            aside.Controls.Add(btnHome);
        }

        public void setBtnGarage(Panel aside)
        {
            Button btnGarage = new Button();
            btnGarage.Name = "btnGarage";
            btnGarage.FlatStyle = FlatStyle.Flat;
            btnGarage.FlatAppearance.BorderSize = 1;
            btnGarage.Location = new Point(0, 0);
            btnGarage.Size = new Size(250, 50);

            btnGarage.Dock = DockStyle.Top;

            btnGarage.Text = "Garage";
            btnGarage.ForeColor = Color.FromArgb(140, 100, 250);
            btnGarage.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            btnGarage.Click += BtnGarage_Click;

            aside.Controls.Add(btnGarage);
        }

        private void BtnGarage_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            ViewPark viewPark = new ViewPark();
            viewPark.Location = new Point(0, 0);

            Main.Controls.Add(viewPark);
        }

        public void setBtnDrivers(Panel aside)
        {
            Button btnDrivers = new Button();
            btnDrivers.Name = "btnDrivers";
            btnDrivers.FlatStyle = FlatStyle.Flat;
            btnDrivers.FlatAppearance.BorderSize = 1;
            btnDrivers.Location = new Point(0, 0);
            btnDrivers.Size = new Size(250, 50);

            btnDrivers.Dock = DockStyle.Top;

            btnDrivers.Text = "Drivers";
            btnDrivers.ForeColor = Color.FromArgb(140, 100, 250);
            btnDrivers.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            aside.Controls.Add(btnDrivers);
        }

        public void setBtnFacilities(Panel aside)
        {
            Button btnFacilities = new Button();
            btnFacilities.Name = "btnFacilities";
            btnFacilities.FlatStyle = FlatStyle.Flat;
            btnFacilities.FlatAppearance.BorderSize = 1;
            btnFacilities.Location = new Point(0, 0);
            btnFacilities.Size = new Size(250, 50);

            btnFacilities.Dock = DockStyle.Top;

            btnFacilities.Text = "Parking Facilities";
            btnFacilities.ForeColor = Color.FromArgb(140, 100, 250);
            btnFacilities.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            aside.Controls.Add(btnFacilities);
        }

        public void setBtnStatistics(Panel aside)
        {
            Button btnStatistics = new Button();
            btnStatistics.Name = "btnStatistics";
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.FlatAppearance.BorderSize = 1;
            btnStatistics.Location = new Point(0, 0);
            btnStatistics.Size = new Size(250, 50);

            btnStatistics.Dock = DockStyle.Top;

            btnStatistics.Text = "Statistics";
            btnStatistics.ForeColor = Color.FromArgb(140, 100, 250);
            btnStatistics.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            aside.Controls.Add(btnStatistics);
        }

        public void setBtnSettings(Panel aside)
        {
            Button btnSettings = new Button();
            btnSettings.Name = "btnSettings";
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.FlatAppearance.BorderSize = 1;
            btnSettings.Location = new Point(0, 0);
            btnSettings.Size = new Size(250, 50);

            btnSettings.Dock = DockStyle.Top;

            btnSettings.Text = "Settings";
            btnSettings.ForeColor = Color.FromArgb(140, 100, 250);
            btnSettings.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            aside.Controls.Add(btnSettings);
        }

        public void setHeader(Panel header)
        {
            header.Controls.Clear();
            header.Size = new Size(this.Width - 250, 100);
            header.Location = new Point(250, 0);
            header.BackColor = Color.FromArgb(140, 100, 250);
            header.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);

            setClose(header);

            this.Controls.Add(header);
        }

        public void setClose(Panel header)
        {
            Button btnClose = new Button();
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.Location = new Point(header.Width - 60, 5);
            btnClose.BackColor = Color.Red;

            btnClose.Click += BtnClose_Click;

            header.Controls.Add(btnClose);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setMain(Panel main)
        {
            main.Controls.Clear();
            main.Size = new Size(this.Width - 250, this.Height - 100);
            main.Location = new Point(250, 100);
            main.BackColor = Color.White;
            main.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);


            this.Controls.Add(main);
        }

    }
}
