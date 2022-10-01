using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ParkingSystem.Data;
using ParkingSystem.Model;

namespace ParkingSystem.Repo
{
    public class SpotTypeRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public SpotTypeRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\ParkingSystem\ParkingSystem")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<SpotType> getAll()
        {
            string sql = "select * from spottype";

            return db.LoadData<SpotType, dynamic>(sql, new { }, connectionString);
        }

        public void create(SpotType spotType)
        {
            string sql = "insert into spottype(type, price) values (@type, @price)";

            db.SaveData(sql, new {spotType.Type, spotType.Price}, connectionString);
        }

        public SpotType getById(int id)
        {
            string sql = "select * from spottype where id = @id";

            if (db.LoadData<SpotType, dynamic>(sql, new {id}, connectionString).Count == 0)
                return null;
            return db.LoadData<SpotType, dynamic>(sql, new {id}, connectionString)[0];
        }

        public void deleteById(int id)
        {
            string sql = "delete from spottype where id = @id;";

            db.SaveData(sql, new {id}, connectionString);
        }

        public void updateTypeById(int id, String type)
        {
            string sql = "update spottype set type = @type where id = @id";

            db.SaveData(sql, new {id, type}, connectionString);
        }

        public void updatePriceById(int id, int price)
        {
            string sql = "update spottype set price = @price where id = @id";

            db.SaveData(sql, new {id, price}, connectionString);
        }

    }
}
