using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Asn1.Misc;

namespace ParkingSystem.Model
{
    public class Reservation
    {
        private int id;
        private int parkingSpot;
        private int driverId;
        private String vehicleId;
        private DateTime reservedOn;
        private DateTime reservedUntil;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int ParkingSpot
        {
            get { return parkingSpot; }
            set { parkingSpot = value; }
        }

        public int DriverID
        {
            get { return driverId; }
            set { driverId = value; }
        }

        public String VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public DateTime ReservedOn
        {
            get { return reservedOn; }
            set { reservedOn = value; }
        }
        public DateTime ReservedUntil
        {
            get { return reservedUntil; }
            set { reservedUntil = value; }
        }

        public Reservation(int id, int parkingSpot, int driverId, String vehicleId, DateTime reservedOn,
            DateTime reservedUntil)
        {
            this.id = id;
            this.parkingSpot = parkingSpot;
            this.driverId = driverId;
            this.vehicleId = vehicleId;
            this.reservedOn = reservedOn;
            this.reservedUntil = reservedUntil;
        }

        public Reservation(int parkingSpot, int driverId, String vehicleId, DateTime reservedOn,
            DateTime reservedUntil)
        {
            this.parkingSpot = parkingSpot;
            this.driverId = driverId;
            this.vehicleId = vehicleId;
            this.reservedOn = reservedOn;
            this.reservedUntil = reservedUntil;
        }

        public override bool Equals(object obj)
        {
            Reservation reservation = obj as Reservation;
            if (this.id == reservation.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + parkingSpot + "," + driverId + "," + vehicleId + "," + reservedOn.ToShortDateString() +
                   "," + reservedUntil.ToShortDateString();
        }
    }
}
