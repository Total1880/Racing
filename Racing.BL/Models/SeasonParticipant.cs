using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class SeasonParticipant : Driver
    {
        private int points = 0;

        public SeasonParticipant(Driver driver) : base(driver.FirstName, driver.LastName, driver.Speed, driver.DriverId)
        {
            points = 0;
        }
        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }
    }
}
