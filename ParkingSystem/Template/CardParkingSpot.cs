using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParkingSystem.Model;

namespace ParkingSystem.Template
{
    public class CardParkingSpot : Panel
    {
        private ParkingSpot parkingSpot;
        private Reservation reservation;

        private Label lblNumar;
        private Label lblVin;
        private Label lblDataOn;
        private Label lblDataUntil;
        public Button btnDetails;

        public CardParkingSpot(ParkingSpot parkingSpot, Reservation reservation)
        {
            this.parkingSpot = parkingSpot;
            this.reservation = reservation;

            layout();
        }

        public void layout()
        {
            this.Size = new Size(450, 150);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            if (reservation != null)
            {
                this.ForeColor=Color.Red;
                setLblDataOn();
                setLblDataUntil();
            }
            else
            {
                this.ForeColor = Color.Green;
            }

            setLblNumber();
            setLblVin();
            setBtnDetails();
        }

        public void setLblNumber()
        {
            lblNumar=new Label();
            lblNumar.Name = "lblNume";
            lblNumar.Text = (char) ((int) 'A' + parkingSpot.LevelId - 1) + parkingSpot.Id.ToString();
            lblNumar.Location = new Point(10, 25);
            lblNumar.AutoSize = false;
            lblNumar.Size = new Size(130, 50);
            lblNumar.TextAlign = ContentAlignment.MiddleCenter;

            lblNumar.Font = new Font("Microsoft Sans Serif", 26, FontStyle.Regular);

            this.Controls.Add(lblNumar);
        }

        public void setLblVin()
        {
            lblVin = new Label();
            lblVin.Name = "lblVin";
            if (reservation != null)
            {
                lblVin.Text = reservation.VehicleId;
            }
            else
            {
                lblVin.Text = "Available";
            }
            lblVin.Location = new Point(140, 25);
            lblVin.AutoSize = false;
            lblVin.Size = new Size(310, 35);
            lblVin.TextAlign = ContentAlignment.MiddleLeft;

            lblVin.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            this.Controls.Add(lblVin);
        }

        private void setLblDataOn()
        {
            lblDataOn = new Label();
            lblDataOn.Name = "lblDataOn";
            lblDataOn.Text = reservation.ReservedOn.ToShortDateString();
            lblDataOn.Location = new Point(140, 65);
            lblDataOn.AutoSize = false;
            lblDataOn.Size = new Size(200, 35);
            lblDataOn.TextAlign = ContentAlignment.MiddleLeft;

            lblDataOn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            this.Controls.Add(lblDataOn);
        }

        private void setLblDataUntil()
        {
            lblDataUntil = new Label();
            lblDataUntil.Name = "lblDataUntil";
            lblDataUntil.Text = reservation.ReservedUntil.ToShortDateString();
            lblDataUntil.Location = new Point(140, 100);
            lblDataUntil.AutoSize = false;
            lblDataUntil.Size = new Size(200, 35);
            lblDataUntil.TextAlign = ContentAlignment.MiddleLeft;

            lblDataUntil.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            this.Controls.Add(lblDataUntil);
        }

        public void setBtnDetails()
        {
            btnDetails = new Button();
            if (reservation != null)
                btnDetails.Name = parkingSpot.Id + "/" + reservation.Id;
            else
            {
                btnDetails.Name = parkingSpot.Id + "/0";
            }
            btnDetails.Size = new Size(30, 30);
            btnDetails.Location = new Point(410, 110);
            btnDetails.FlatStyle = FlatStyle.Flat;

            this.Controls.Add(btnDetails);
        }
    }
}
