using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class Race
    {
        private readonly Guid raceId;
        private readonly List<Driver> listOfParticipants;
        private readonly Guid raceTrackId;
        private readonly int raceLength;

        public Race(List<Driver> inputListOfParticipants, RaceTrack raceTrack)
        {
            raceId = Guid.NewGuid();
            listOfParticipants = inputListOfParticipants;
            raceTrackId = raceTrack.RaceTrackId;
            raceLength = raceTrack.Length;
        }

        #region Accessors
        public Guid RaceId
        {
            get { return raceId; }
        }

        public List<Driver> ListOfParticipants
        {
            get { return listOfParticipants; }
        }

        public Guid RaceTrackId
        {
            get { return raceTrackId; }
        }

        public int RaceLength
        {
            get { return raceLength; }
        }
        #endregion
    }
}
