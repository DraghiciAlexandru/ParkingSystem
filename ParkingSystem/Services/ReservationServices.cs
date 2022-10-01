using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ParkingSystem.Exceptions;
using ParkingSystem.Model;
using ParkingSystem.Repo;

namespace ParkingSystem.Services
{
    public class ReservationServices
    {
        private ReservationRepo reservationRepo;
        private List<Reservation> reservations;

        public ReservationServices()
        {
            reservationRepo = new ReservationRepo();
            reservations = reservationRepo.getAll();
        }

        public void create(Reservation reservation)
        {
            if (!reservations.Contains(reservation))
            {
                reservationRepo.create(reservation);
            }
            else
            {
                throw new ParkException("Reservation already exists");
            }
        }

        public List<Reservation> getAll()
        {
            if (reservations.Count == 0)
                return null;
            return reservations;
        }

        public Reservation getById(int id)
        {
            if (id >= 1)
            {
                return reservationRepo.getById(id);
            }
            else
            {
                throw new ParkException("Invalid reservation id");
            }
        }

        public List<Reservation> getByParkId(int parkingId)
        {
            if (parkingId >= 1)
            {
                return reservationRepo.getByParkingId(parkingId);
            }
            else
            {
                throw new ParkException("Invalid park id");
            }
        }

        public List<Reservation> getByDriverId(int driverId)
        {
            if (driverId >= 1)
            {
                return reservationRepo.getByDriverId(driverId);
            }
            else
            {
                throw new ParkException("Invalid driver id");
            }
        }

        public List<Reservation> getByVehicleId(string vehicleId)
        {
            Regex regex = new Regex(@"/\b[(A-H|J-N|P|R-Z|0-9)]{17}\b/");

            if (regex.IsMatch(vehicleId))
            {
                return reservationRepo.getByVehicleId(vehicleId);
            }
            else
            {
                throw new ParkException("Invalid driver id");
            }
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                reservationRepo.deleteById(id);
            }
            else
            {
                throw new ParkException("Invalid reservation id");
            }
        }

        public void upgradeParkingSpotById(int id, int parkingSpotId)
        {
            if (reservations.Contains(new Reservation(id, 0, 0, "id", DateTime.Now, DateTime.Now)) &&
                parkingSpotId > 0)
            {
                reservationRepo.updateParkingSpotById(id, parkingSpotId);
            }
            else
            {
                throw new ParkException("Parking spot or reservation invalid");
            }
        }

        public void upgradeReservedOnById(int id, DateTime reservedOn)
        {
            if (reservations.Contains(new Reservation(id, 0, 0, "id", DateTime.Now, DateTime.Now)))
            {
                reservationRepo.updateReservedOnById(id, reservedOn);
            }
            else
            {
                throw new ParkException("Reserved on invalid");
            }
        }

        public void upgradeReservedUntilById(int id, DateTime reservedOn)
        {
            if (reservations.Contains(new Reservation(id, 0, 0, "id", DateTime.Now, DateTime.Now)))
            {
                reservationRepo.updateReservedUntilById(id, reservedOn);
            }
            else
            {
                throw new ParkException("Reserved on invalid");
            }
        }
    }
}
