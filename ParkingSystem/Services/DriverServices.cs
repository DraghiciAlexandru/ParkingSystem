using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ParkingSystem.Exceptions;
using ParkingSystem.Model;
using ParkingSystem.Repo;

namespace ParkingSystem.Services
{
    public class DriverServices
    {
        private DriverRepo driverRepo;

        private List<Driver> drivers;

        public DriverServices()
        {
            driverRepo = new DriverRepo();
            drivers = driverRepo.getAll();
        }

        public void create(Driver driver)
        {
            if (!drivers.Contains(driver))
            {
                driverRepo.create(driver);
            }
            else
            {
                throw new ParkException("Driver already exists");
            }
        }

        public List<Driver> getAll()
        {
            if (drivers.Count == 0)
                return null;
            return drivers;
        }

        public Driver getById(int id)
        {
            if (id >= 1)
            {
                return driverRepo.getById(id);
            }
            else
            {
                throw new ParkException("Invalid driver id");
            }
        }

        public Driver getByName(String firstName, String lastName)
        {
            if (drivers.Contains(new Driver(firstName, lastName, "phone", "pass")))
            {
                return driverRepo.getByName(firstName, lastName);
            }
            else
            {
                throw new ParkException("Driver does not exist");
            }
        }

        public Driver getByNumber(String telephone)
        {
            Regex regex =
                new Regex(
                    @"/\d?(\s?|-?|\+?|\.?)((\(\d{1,4}\))|(\d{1,3})|\s?)(\s?|-?|\.?)((\(\d{1,3}\))|(\d{1,3})|\s?)(\s?|-?|\.?)((\(\d{1,3}\))|(\d{1,3})|\s?)(\s?|-?|\.?)\d{3}(-|\.|\s)\d{4}/");
            if (regex.IsMatch(telephone))
            {
                return driverRepo.getByTelephone(telephone);
            }
            else
            {
                throw new ParkException("Invalid phone number");
            }
        }

        public void deleteById(int id)
        {
            if (id >= 1)
            {
                 driverRepo.deleteById(id);
            }
            else
            {
                throw new ParkException("Invalid driver id");
            }
        }

        public void updateFirstNameById(int id, string firstName)
        {
            if (id > 0 && firstName.Trim(' ').Length > 0) 
            {
                driverRepo.updateFirstNameById(id, firstName);
            }
            else
            {
                throw new ParkException("Invalid name");
            }
        }

        public void updateLastNameById(int id, string lastName)
        {
            if (id > 0 && lastName.Trim(' ').Length > 0)
            {
                driverRepo.updateLastNameById(id, lastName);
            }
            else
            {
                throw new ParkException("Invalid name");
            }
        }

        public void upgradeTelephoneById(int id, string telephone)
        {
            Regex regex =
                new Regex(
                    @"/\d?(\s?|-?|\+?|\.?)((\(\d{1,4}\))|(\d{1,3})|\s?)(\s?|-?|\.?)((\(\d{1,3}\))|(\d{1,3})|\s?)(\s?|-?|\.?)((\(\d{1,3}\))|(\d{1,3})|\s?)(\s?|-?|\.?)\d{3}(-|\.|\s)\d{4}/");
            if (regex.IsMatch(telephone))
            {
                driverRepo.updateTelephoneNameById(id, telephone);
            }
            else
            {
                throw new ParkException("Invalid number");
            }
        }
    }
}
