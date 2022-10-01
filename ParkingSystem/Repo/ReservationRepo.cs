using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.Extensions.Configuration;
using ParkingSystem.Data;
using ParkingSystem.Model;

namespace ParkingSystem.Repo
{
    public class ReservationRepo
    {
        private readonly string connectionString;

        private DataAcces db;

        public ReservationRepo()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"D:\MyCode\C#\UIdesign\Dinamic\ParkingSystem\ParkingSystem")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Reservation> getAll()
        {
            string sql = "select * from reservation";

            return db.LoadData<Reservation, dynamic>(sql, new { }, connectionString);
        }

        public void create(Reservation reservation)
        {
            string sql =
                "insert into reservation(parkingSpotId, driverId, vehicleId, reservedOn, reservedUntil) values (@parkingSpotId, @driverId, @vehicleId, @reservedOn, @reservedUntil)";
            db.SaveData(sql,
                new
                {
                    reservation.ParkingSpotId, reservation.DriverId, reservation.VehicleId, reservation.ReservedOn,
                    reservation.ReservedUntil
                }, connectionString);
        }

        public Reservation getById(int id)
        {
            string sql = "select * from reservation where id = @id";
            if (db.LoadData<Reservation, dynamic>(sql, new {id}, connectionString).Count == 0)
                return null;
            return db.LoadData<Reservation, dynamic>(sql, new {id}, connectionString)[0];
        }

        public List<Reservation> getByParkingId(int parkingId)
        {
            string sql = "select * from reservation where parkingId = @parkingId";

            return db.LoadData<Reservation, dynamic>(sql, new {parkingId}, connectionString);
        }

        public List<Reservation> getByDriverId(int driverId)
        {
            string sql = "select * from reservation where driverId = @driverId";

            return db.LoadData<Reservation, dynamic>(sql, new {driverId}, connectionString);
        }

        public List<Reservation> getByVehicleId(String vehicleId)
        {
            string sql = "select * from reservation where vehicleId = @vehicleId";

            return db.LoadData<Reservation, dynamic>(sql, new {vehicleId}, connectionString);
        }

        public void deleteById(int id)
        {
            string sql = "delete from reservation where id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void updateParkingSpotById(int id, int parkingSpotId)
        {
            string sql = "update reservation set parkingSpotId = @parkingSpotId where id = @id";

            db.SaveData(sql, new {parkingSpotId, id}, connectionString);
        }

        public void updateReservedOnById(int id, DateTime reservedOn)
        {
            string sql = "update reservation set reservedOn = @reservedOn where id = @id";

            db.SaveData(sql, new {reservedOn, id}, connectionString);
        }

        public void updateReservedUntilById(int id, DateTime reservedUntil)
        {
            string sql = "update reservation set reservedUntil = @reservedUntil where id = @id";

            db.SaveData(sql, new {reservedUntil, id}, connectionString);
        }

    }
}
