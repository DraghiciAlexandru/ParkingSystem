using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Model
{
    public class SpotType
    {
        private int id;
        private String type;
        private int price;

        public int Id
        {
            get { return id; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public SpotType(int id, String type, int price)
        {
            this.id = id;
            this.type = type;
            this.price = price;
        }

        public SpotType(String type, int price)
        {
            this.type = type;
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            SpotType spotType = obj as SpotType;
            if (this.id == spotType.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            return this.id + "," + this.type + "," + this.price;
        }
    }
}
