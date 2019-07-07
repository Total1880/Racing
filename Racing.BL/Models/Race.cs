using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class Race
    {
        private readonly Guid raceId;
        private readonly List<RaceParticipant> listOfParticipants;
        private readonly Guid raceTrackId;
        private readonly int raceLength;

        #region Constructors
        public Race(List<RaceParticipant> inputListOfParticipants, RaceTrack raceTrack)
        {
            raceId = Guid.NewGuid();
            listOfParticipants = inputListOfParticipants;
            raceTrackId = raceTrack.RaceTrackId;
            raceLength = raceTrack.Length;
        }

        public Race(Guid raceId, List<RaceParticipant> inputListOfParticipants)
        {
            this.raceId = raceId;
            listOfParticipants = inputListOfParticipants;
        }
        #endregion

        #region Accessors
        public Guid RaceId
        {
            get { return raceId; }
        }

        public List<RaceParticipant> ListOfParticipants
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

        #region Functions

        public void SetParticipantsFinalPosition(List<RaceParticipant> finalListOfParticipants)
        {
            foreach (var finalParticipant in finalListOfParticipants)
            {
                foreach (var participant in listOfParticipants)
                {
                    if (participant.DriverId == finalParticipant.DriverId)
                    {
                        participant.Position = finalParticipant.Position;
                    }
                }
            }
        }

        #endregion
    }
}
