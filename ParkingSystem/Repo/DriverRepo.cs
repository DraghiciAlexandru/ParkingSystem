using ParkingSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using ParkingSystem.Model;

namespace ParkingSystem.Repo
{
    public class DriverRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public DriverRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\ParkingSystem\ParkingSystem")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Driver> getAll()
        {
            string sql = "select * from driver";

            return db.LoadData<Driver, dynamic>(sql, new { }, connectionString);
        }

        public void create(Driver driver)
        {
            string sql =
                "insert into driver(firstName, lastName, telephone, password) values (@firstName, @lastName, @telephone, @password)";
            db.SaveData(sql,
                new {driver.FirstName, driver.LastName, driver.Telephone, driver.Password},
                connectionString);
        }

        public Driver getById(int id)
        {
            string sql = "select * from driver where id = @id";
            if (db.LoadData<Driver, dynamic>(sql, new {id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Driver, dynamic>(sql, new {id}, connectionString)[0];
        }

        public Driver getByName(string firstName, string lastName)
        {
            string sql = "select * from driver where firstName like '*@firstName*' and lastName like '*@lastName*'";

            if (db.LoadData<Driver, dynamic>(sql, new { firstName = firstName, lastName = firstName},
                connectionString).Count == 0)
                return null;
            return db.LoadData<Driver, dynamic>(sql, new {firstName = firstName, lastName = lastName},
                connectionString)[0];
        }

        public Driver getByTelephone(string telephone)
        {
            string sql = "select * from driver where telephone = @telephone";
            if (db.LoadData<Driver, dynamic>(sql, new { telephone }, connectionString).Count == 0)
                return null;
            return db.LoadData<Driver, dynamic>(sql, new { telephone }, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from driver where id = @id;";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void updateFirstNameById(int id, String firstName)
        {
            string sql = "update driver set firstName = @firstName where id = @id;";

            db.SaveData(sql, new { id, firstName }, connectionString);
        }

        public void updateLastNameById(int id, String lastName)
        {
            string sql = "update driver set lastName = @lastName where id = @id";

            db.SaveData(sql, new {id, lastName}, connectionString);
        }

        public void updateTelephoneNameById(int id, String telephone)
        {
            string sql = "update driver set telephone = @telephone where id = @id";

            db.SaveData(sql, new {id, telephone}, connectionString);
        }
    }
}
