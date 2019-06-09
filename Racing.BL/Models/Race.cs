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

        public Race(List<Driver> inputListOfParticipants, RaceTrack raceTrack)
        {
            raceId = Guid.NewGuid();
            listOfParticipants = inputListOfParticipants;
            raceTrackId = raceTrack.RaceTrackId;
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
        #endregion
    }
}
