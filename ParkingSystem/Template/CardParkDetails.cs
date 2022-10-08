using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParkingSystem.Model;
using ParkingSystem.Services;

namespace ParkingSystem.Template
{
    class CardParkDetails : Panel
    {
        //1670, Height=920

        private ParkingSpotServices parkingSpotServices;
        private ReservationServices reservationServices;
        private DriverServices driverServices;
        private ParkingSpot parkingSpot;
        private Reservation reservation;
        private Driver driver;

        private Label lblNumber;
        private Panel pnlDriverData;
        private Panel pnlParkData;
        private Panel pnlReservationData;

        public CardParkDetails(int parkingSpot, int reservation)
        {
            parkingSpotServices = new ParkingSpotServices();
            reservationServices = new ReservationServices();
            driverServices = new DriverServices();

            this.parkingSpot = parkingSpotServices.getById(parkingSpot);
            if (reservation != 0)
            {
                this.reservation = reservationServices.getById(reservation);
                this.driver = driverServices.getById(this.reservation.DriverId);
            }
            else
            {
                this.reservation = null;
                this.driver = null;
            }



            layout();
        }

        private void layout()
        {
            this.Size = new Size(1670, 920);
            this.BackColor = Color.FromArgb(200, 175, 250);
            this.BorderStyle = BorderStyle.None;
            this.Font = new Font("Microsoft Sans Serif", 26, FontStyle.Regular);
            this.Name = "cardParkDetails";

            setLblNumber();
        }

        public void setLblNumber()
        {
            lblNumber = new Label();
            lblNumber.Name = "lblNume";
            lblNumber.Text = (char)((int)'A' + parkingSpot.LevelId - 1) + parkingSpot.Id.ToString();
            lblNumber.Location = new Point(735, 30);
            lblNumber.AutoSize = false;
            lblNumber.Size = new Size(200, 100);
            lblNumber.TextAlign = ContentAlignment.MiddleCenter;

            lblNumber.Font = new Font("Microsoft Sans Serif", 35, FontStyle.Regular);

            this.Controls.Add(lblNumber);
        }

        public void setDriverData()
        {
            pnlDriverData = new Panel();
            pnlDriverData.Size = new Size(450, 150);
            pnlDriverData.BackColor = Color.White;
            pnlDriverData.BorderStyle = BorderStyle.FixedSingle;



        }

    }
}
