using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class RaceParticipant : Driver
    {
        private int distance;
        private int position = 0;

        public RaceParticipant(Driver driver) : base (driver.FirstName,driver.LastName,driver.Speed, driver.DriverId)
        {
            distance = 0;
        }

        public RaceParticipant(string FirstName, string LastName, Guid DriverId, int Position) : base(FirstName,LastName,DriverId)
        {
            position = Position;
        }

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
