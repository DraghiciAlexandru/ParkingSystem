using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Model
{
    public class Vehicle
    {
        private String numberPlate;
        private int driverId;
        private String brand;
        private String model;
        private String color;

        public String NumberPlate
        {
            get { return numberPlate; }
            set { numberPlate = value; }
        }

        public int DriverId
        {
            get { return driverId; }
            set { driverId = value; }
        }
        public String Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public String Model
        {
            get { return model; }
            set { model = value; }
        }
        public String Color
        {
            get { return color; }
            set { color = value; }
        }

        public Vehicle(String numberPlate, int driverId, String brand, String model, String color)
        {
            this.numberPlate = numberPlate;
            this.driverId = driverId;
            this.brand = brand;
            this.model = model;
            this.color = color;
        }

        public Vehicle(int driverId, String brand, String model, String color)
        {
            this.driverId = driverId;
            this.brand = brand;
            this.model = model;
            this.color = color;
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicle=obj as Vehicle;
            if (this.numberPlate == vehicle.numberPlate)
                return true;
            return false;
        }

        public override string ToString()
        {
            return numberPlate + "," + driverId + "," + brand + "," + model + "," + color;
        }
    }
}
