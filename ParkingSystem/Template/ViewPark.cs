using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParkingSystem.Model;
using ParkingSystem.Services;

namespace ParkingSystem.Template
{
    class ViewPark : FlowLayoutPanel
    {
        private ParkingSpotServices parkingSpotServices;
        private ReservationServices reservationServices;

        public ViewPark()
        {
            parkingSpotServices = new ParkingSpotServices();
            reservationServices = new ReservationServices();

            layout();
        }

        private void layout()
        {
            this.Controls.Clear();
            this.Size = new Size(1670, 920);
            this.BackColor = Color.White;
            this.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            this.AutoScroll = true;

            setParkingSpots();
        }

        public void setParkingSpots()
        {
            List<ParkingSpot> parkingSpots = parkingSpotServices.getAll();

            foreach (ParkingSpot park in parkingSpots)
            {
                List<Reservation> reservations = reservationServices.getByParkId(park.Id);

                Reservation now = null;

                if (reservations != null)
                {
                    foreach (Reservation res in reservations)
                    {
                        if (res.ReservedOn.CompareTo(DateTime.Now) < 1 && res.ReservedUntil.CompareTo(DateTime.Now) > -1)
                        {
                            now = res;
                        }
                    }
                }

                CardParkingSpot card;

                if (now != null)
                {
                    card = new CardParkingSpot(park, now);
                }
                else
                {
                    card = new CardParkingSpot(park, null);
                }

                card.Padding = new Padding(20);

                card.btnDetails.Click += BtnDetails_Click;

                this.Controls.Add(card);
            }
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            Button btnDetails= sender as Button;

            CardParkDetails cardParkDetails = new CardParkDetails(int.Parse(btnDetails.Name.Split('/')[0]),
                int.Parse(btnDetails.Name.Split('/')[1]));

            this.Parent.Controls.Add(cardParkDetails);
            this.Parent.Controls.Remove(this);
        }
    }
}
