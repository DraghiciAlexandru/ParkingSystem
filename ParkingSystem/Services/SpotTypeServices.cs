using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ParkingSystem.Exceptions;
using ParkingSystem.Model;
using ParkingSystem.Repo;

namespace ParkingSystem.Services
{
    public class SpotTypeServices
    {
        private SpotTypeRepo spotTypeRepo;
        private List<SpotType> spotTypes;

        public SpotTypeServices()
        {
            spotTypeRepo = new SpotTypeRepo();
            spotTypes = spotTypeRepo.getAll();
        }

        public void create(SpotType spotType)
        {
            if (!spotTypes.Contains(spotType))
            {
                spotTypeRepo.create(spotType);
            }
            else
            {
                throw new ParkException("SpotType already exists");
            }
        }

        public List<SpotType> getAll()
        {
            if (spotTypes.Count == 0)
                return null;
            return spotTypes;
        }

        public SpotType getById(int id)
        {
            if (id >= 1)
            {
                return spotTypeRepo.getById(id);
            }
            else
            {
                throw new ParkException("Invalid spotType id");
            }
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                spotTypeRepo.deleteById(id);
            }
            else
            {
                throw new ParkException("Invalid spotType id");
            }
        }

        public void updateTypeById(int id, String type)
        {
            if (id > 0 && type.Trim(' ').Length > 0) 
            {
                spotTypeRepo.updateTypeById(id, type);
            }
            else
            {
                throw new ParkException("Invalid type");
            }
        }

        public void updatePriceById(int id, int price)
        {
            if (id > 0 && price >= 0)
            {
                spotTypeRepo.updatePriceById(id, price);
            }
            else
            {
                throw new ParkException("Invalid price");
            }
        }
    }
}
