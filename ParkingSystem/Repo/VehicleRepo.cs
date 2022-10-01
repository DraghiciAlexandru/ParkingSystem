using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using ParkingSystem.Data;
using ParkingSystem.Model;

namespace ParkingSystem.Repo
{
    public class VehicleRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public VehicleRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\ParkingSystem\ParkingSystem")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Vehicle> getAll()
        {
            string sql = "SELECT * FROM vehicle";

            return db.LoadData<Vehicle, dynamic>(sql, new { }, connectionString);
        }

        public void create(Vehicle vehicle)
        {
            string sql =
                "insert into vehicle(numberPlate, brand, model, color) values (@numberPlate, @brand, @model, @color);";
            db.SaveData(sql, new {vehicle.NumberPlate, vehicle.Brand, vehicle.Model, vehicle.Color}, connectionString);
        }

        public Vehicle getByPlate(String numberPlate)
        {
            string sql = "select * from vehicle where numberPlate = @numberPlate;";
            if (db.LoadData<Vehicle, dynamic>(sql, new {numberPlate}, connectionString).Count == 0)
                return null;
            return db.LoadData<Vehicle, dynamic>(sql, new {numberPlate}, connectionString)[0];
        }

        public List<Vehicle> getByDriverId(int driverId)
        {
            string sql = "select * from vehicle where driverId = @driverId;";
            if (db.LoadData<Vehicle, dynamic>(sql, new { driverId }, connectionString).Count == 0)
                return null;
            return db.LoadData<Vehicle, dynamic>(sql, new {driverId}, connectionString);
        }

        public List<Vehicle> getByBrand(String brand)
        {
            string sql = "select * from vehicle where brand = @brand;";
            if (db.LoadData<Vehicle, dynamic>(sql, new {brand}, connectionString).Count == 0)
                return null;
            return db.LoadData<Vehicle, dynamic>(sql, new {brand}, connectionString);
        }

        public void deleteByPlate(String numberPlate)
        {
            string sql = "delete from vehicle where numberPlate = @numberPlate;";

            db.SaveData(sql, new {numberPlate}, connectionString);
        }

        public void deleteByBrand(String brand)
        {
            string sql = "delete from vehicle where brand = @brand;";

            db.SaveData(sql, new {brand}, connectionString);
        }

        public void updateDriverIdById(String numberPlate, int driverId)
        {
            string sql = "update vehicle set driverId = @driverId where numberPlate = @numberPlate;";

            db.SaveData(sql, new { driverId, numberPlate }, connectionString);
        }

        public void updateBrandById(String numberPlate, String brand)
        {
            string sql = "update vehicle set brand = @brand where numberPlate = @numberPlate;";

            db.SaveData(sql, new {brand, numberPlate}, connectionString);
        }

        public void updateModelById(String numberPlate, String model)
        {
            string sql = "update vehicle set model = @model where numberPlate = @numberPlate;";

            db.SaveData(sql, new {model, numberPlate}, connectionString);
        }

        public void updateColorById(String numberPlate, String color)
        {
            string sql = "update vehicle set color = @color where numberPlate = @numberPlate;";

            db.SaveData(sql, new {color, numberPlate}, connectionString);
        }

    }
}
