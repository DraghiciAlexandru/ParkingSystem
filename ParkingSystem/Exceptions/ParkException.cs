using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Exceptions
{
    public class ParkException:Exception
    {
        public ParkException(string? message) : base(message)
        {

        }
    }
}
