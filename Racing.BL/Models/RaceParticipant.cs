using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class RaceParticipant : Driver
    {
        private int distance;

        public RaceParticipant()
        {
            distance = 0;
        }

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
    }
}
