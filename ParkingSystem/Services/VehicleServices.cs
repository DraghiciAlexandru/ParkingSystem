using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ParkingSystem.Exceptions;
using ParkingSystem.Model;
using ParkingSystem.Repo;

namespace ParkingSystem.Services
{
    public class VehicleServices
    {
        private VehicleRepo vehicleRepo;
        private List<Vehicle> vehicles;

        private Regex regex = new Regex(@"/\b[(A-H|J-N|P|R-Z|0-9)]{17}\b/");

        public VehicleServices()
        {
            vehicleRepo = new VehicleRepo();
            vehicles = vehicleRepo.getAll();
        }

        public void create(Vehicle vehicle)
        {
            if (!vehicles.Contains(vehicle))
            {
                vehicleRepo.create(vehicle);
            }
            else
            {
                throw new ParkException("Vehicle already exists");
            }
        }

        public List<Vehicle> getAll()
        {
            if (vehicles.Count == 0)
                return null;
            return vehicles;
        }

        public Vehicle getByPlate(String numberPlate)
        {
            if (regex.IsMatch(numberPlate))
            {
                return vehicleRepo.getByPlate(numberPlate);
            }
            else
            {
                throw new ParkException("Invalid number plate");
            }
        }


        public List<Vehicle> getByDriverId(int driverId)
        {
            if (driverId >= 1)
            {
                return vehicleRepo.getByDriverId(driverId);
            }
            else
            {
                throw new ParkException("Invalid driver id");
            }
        }

        public List<Vehicle> getByBrand(String brand)
        {
            if (brand.Trim(' ').Length > 0)
            {
                return vehicleRepo.getByBrand(brand);
            }
            else
            {
                throw new ParkException("invalid brand");
            }
        }

        public void deleteByPlate(String numberPlate)
        {
            if (regex.IsMatch(numberPlate))
            {
                vehicleRepo.deleteByPlate(numberPlate);
            }
            else
            {
                throw new ParkException("Invalid number plate");
            }
        }

        public void deleteByBrand(String brand)
        {
            if (brand.Trim(' ').Length > 0)
            {
                vehicleRepo.deleteByBrand(brand);
            }
            else
            {
                throw new ParkException("Invalid brand");
            }
        }

        public void upgradeDriverById(String numberPlate, int driverId)
        {
            if (vehicles.Contains(new Vehicle(numberPlate, 0, "brand", "model", "color")) && driverId >= 0) 
            {
                vehicleRepo.updateDriverIdById(numberPlate, driverId);
            }
            else
            {
                throw new ParkException("invalid plate");
            }
        }

        public void upgradeBrandById(String numberPlate, string brand)
        {
            if (vehicles.Contains(new Vehicle(numberPlate, 0, "brand", "model", "color")) &&
                brand.Trim(' ').Length >= 0)
            {
                vehicleRepo.updateBrandById(numberPlate, brand);
            }
            else
            {
                throw new ParkException("invalid plate");
            }
        }

        public void upgradeModelById(String numberPlate, string model)
        {
            if (vehicles.Contains(new Vehicle(numberPlate, 0, "brand", "model", "color")) &&
                model.Trim(' ').Length >= 0)
            {
                vehicleRepo.updateModelById(numberPlate, model);
            }
            else
            {
                throw new ParkException("invalid plate");
            }
        }

        public void upgradeColorById(String numberPlate, string color)
        {
            if (vehicles.Contains(new Vehicle(numberPlate, 0, "brand", "model", "color")) &&
                color.Trim(' ').Length >= 0)
            {
                vehicleRepo.updateColorById(numberPlate, color);
            }
            else
            {
                throw new ParkException("invalid plate");
            }
        }
    }
}
