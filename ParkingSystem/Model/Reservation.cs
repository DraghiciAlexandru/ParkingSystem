using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Asn1.Misc;

namespace ParkingSystem.Model
{
    public class Reservation
    {
        private int id;
        private int parkingSpotId;
        private int driverId;
        private String vehicleId;
        private DateTime reservedOn;
        private DateTime reservedUntil;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int ParkingSpotId
        {
            get { return parkingSpotId; }
            set { parkingSpotId = value; }
        }

        public int DriverId
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

        public Reservation(int id, int parkingSpotId, int driverId, String vehicleId, DateTime reservedOn,
            DateTime reservedUntil)
        {
            this.id = id;
            this.parkingSpotId = parkingSpotId;
            this.driverId = driverId;
            this.vehicleId = vehicleId;
            this.reservedOn = reservedOn.Date;
            this.reservedUntil = reservedUntil.Date;
        }

        public Reservation(int parkingSpotId, int driverId, String vehicleId, DateTime reservedOn,
            DateTime reservedUntil)
        {
            this.parkingSpotId = parkingSpotId;
            this.driverId = driverId;
            this.vehicleId = vehicleId;
            this.reservedOn = reservedOn.Date;
            this.reservedUntil = reservedUntil.Date;
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
            return id + "," + parkingSpotId + "," + driverId + "," + vehicleId + "," + reservedOn.ToShortDateString() +
                   "," + reservedUntil.ToShortDateString();
        }
    }
}
