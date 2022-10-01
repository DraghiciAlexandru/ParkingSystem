using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ParkingSystem.Data;
using ParkingSystem.Model;

namespace ParkingSystem.Repo
{
    public class ParkingSpotRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public ParkingSpotRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\ParkingSystem\ParkingSystem")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<ParkingSpot> getAll()
        {
            string sql = "select * from parkingspot";

            return db.LoadData<ParkingSpot, dynamic>(sql, new { }, connectionString);
        }

        public void create(ParkingSpot parkingSpot)
        {
            string sql = "insert into parkingspot(levelId, price) values (@levelId, @price)";

            db.SaveData(sql, new { parkingSpot.LevelId, parkingSpot.TypeId }, connectionString);
        }

        public ParkingSpot getById(int id)
        {
            string sql = "select * from parkingspot where id = @id";

            if (db.LoadData<ParkingSpot, dynamic>(sql, new { id }, connectionString).Count == 0)
                return null;
            return db.LoadData<ParkingSpot, dynamic>(sql, new { id }, connectionString)[0];
        }

        public List<ParkingSpot> getByLevelId(int levelId)
        {
            string sql = "select * from parkingspot where levelId = @levelId";

            return db.LoadData<ParkingSpot, dynamic>(sql, new { levelId }, connectionString);
        }

        public List<ParkingSpot> getByTypeId(int typeId)
        {
            string sql = "select * from parkingspot where typeId = @typeId";

            return db.LoadData<ParkingSpot, dynamic>(sql, new {typeId}, connectionString);
        }

        public void deleteById(int id)
        {
            string sql = "delete from parkingspot where id = @id";

            db.SaveData(sql, new {id}, connectionString);
        }

        public void updateTypeIdById(int id, int typeId)
        {
            string sql = "update parkingspot set typeId = @typeId where id = @id";

            db.SaveData(sql, new {id, typeId}, connectionString);
        }


    }
}
