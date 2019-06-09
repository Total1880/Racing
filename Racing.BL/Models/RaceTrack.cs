using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class RaceTrack
    {
        private readonly Guid raceTrackId;
        private readonly string name;
        private readonly int length;

        #region Constructors
        public RaceTrack()
        {
            name = "No RaceTrack name";
            length = -1;
        }

        public RaceTrack(string inputName, int inputLength)
        {
            name = inputName;
            length = inputLength;
            raceTrackId = Guid.NewGuid();
        }
        #endregion

        #region Accessors
        public Guid RaceTrackId
        {
            get { return raceTrackId; }
        }

        public string Name
        {
            get { return name; }
        }

        public int Length
        {
            get { return length; }
        }
        #endregion
    }
}
