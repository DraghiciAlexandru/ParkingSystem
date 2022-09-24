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
                "insert into vehicle(numberPlate, brand, model, color) values (@numberPlate, @brand, @model, @color";
            db.SaveData(sql, new {vehicle.NumberPlate, vehicle.Brand, vehicle.Model, vehicle.Color}, connectionString);
        }

        public Vehicle getByPlate(String numberPlate)
        {
            string sql = "select * from vehicle where numberPlate = @numberPlate";
            if (db.LoadData<Vehicle, dynamic>(sql, new {numberPlate}, connectionString).Count == 0)
                return null;
            return db.LoadData<Vehicle, dynamic>(sql, new {numberPlate}, connectionString)[0];
        }
    }
}
