using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ParkingSystem.Exceptions;
using ParkingSystem.Model;
using ParkingSystem.Repo;

namespace ParkingSystem.Services
{
    public class ParkingSpotServices
    {
        private ParkingSpotRepo parkingSpotRepo;
        private List<ParkingSpot> parkingSpots;

        public ParkingSpotServices()
        {
            parkingSpotRepo = new ParkingSpotRepo();
            parkingSpots = parkingSpotRepo.getAll();
        }

        public void create(ParkingSpot parking)
        {
            if (!parkingSpots.Contains(parking))
            {
                parkingSpotRepo.create(parking);
            }
            else
            {
                throw new ParkException("Park already exists");
            }
        }

        public List<ParkingSpot> getAll()
        {
            if (parkingSpots.Count == 0)
                return null;
            return parkingSpots;
        }

        public ParkingSpot getById(int id)
        {
            if (id >= 1)
            {
                return parkingSpotRepo.getById(id);
            }
            else
            {
                throw new ParkException("Invalid park id");
            }
        }

        public List<ParkingSpot> getByLevelId(int levelId)
        {
            if (levelId >= 1)
            {
                return parkingSpotRepo.getByLevelId(levelId);
            }
            else
            {
                throw new ParkException("Invalid level id");
            }
        }

        public List<ParkingSpot> getByTypeId(int typeId)
        {
            if (typeId >= 1)
            {
                return parkingSpotRepo.getByTypeId(typeId);
            }
            else
            {
                throw new ParkException("Invalid type id");
            }
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                parkingSpotRepo.deleteById(id);
            }
            else
            {
                throw new ParkException("Invalid park id");
            }
        }

        public void upgradeTypeById(int id, int typeId)
        {
            if (parkingSpots.Contains(new ParkingSpot(id, 0, 0)) && typeId > 0) 
            {
                parkingSpotRepo.updateTypeIdById(id, typeId);
            }
            else
            {
                throw new ParkException("Parking spot or type invalid");
            }
        }
    }
}
