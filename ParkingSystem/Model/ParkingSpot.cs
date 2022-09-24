using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Model
{
    public class ParkingSpot
    {
        private int id;
        private int levelId;
        private SpotType typeId;

        public int Id
        {
            get { return id; }
        }

        public int LevelId
        {
            get { return levelId; }
            set { levelId = value; }
        }

        public SpotType TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        public ParkingSpot(int id, int levelId, SpotType typeId)
        {
            this.id = id;
            this.levelId = levelId;
            this.typeId = typeId;
        }

        public ParkingSpot(int levelId, SpotType typeId)
        {
            this.levelId = levelId;
            this.typeId = typeId;
        }

        public override bool Equals(object obj)
        {
            ParkingSpot parkingSpot = obj as ParkingSpot;
            if (this.id == parkingSpot.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + levelId + "," + typeId.Id;
        }
    }
}
