using System;
using System.Collections.Generic;
using System.Text;
using Ubiety.Dns.Core;

namespace ParkingSystem.Model
{
    public class Driver
    {
        private int id;
        private String firstName;
        private String lastName;
        private String telephone;
        private String vehicleId;
        private String password;

        public int Id
        {
            get { return id; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public String Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public String VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public Driver(int id, String firstName, String lastName, String telephone, String vehicleId, String password)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephone = telephone;
            this.vehicleId = vehicleId;
            this.password = password;
        }

        public Driver(String firstName, String lastName, String telephone, String vehicleId, String password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephone = telephone;
            this.vehicleId = vehicleId;
            this.password = password;
        }

        public override bool Equals(object obj)
        {
            Driver driver=obj as Driver;
            if (this.id == driver.id || (this.firstName == driver.firstName && this.lastName == driver.lastName &&
                                         this.password == driver.password)) 
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + firstName + "," + lastName + "," + telephone + "," + vehicleId + "," + password;
        }
    }
}
