using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Racing.BL.RaceEngine
{

    public class RaceLogic
    {
        int raceLength;

        public RaceLogic(int raceLength)
        {
            this.raceLength = raceLength;
        }
        public IEnumerable<RaceParticipant> Turn(List<RaceParticipant> raceParticipants)
        {
            Random random = new Random();
            foreach (var participant in raceParticipants)
            {
                participant.Distance += random.Next(0, participant.Speed);
            }

            raceParticipants = raceParticipants.OrderByDescending(x => x.Distance).ToList();

            return PelotonCheck(raceParticipants);
        }

        private IEnumerable<RaceParticipant> PelotonCheck(List<RaceParticipant> raceParticipants)
        {
            return raceParticipants;
        }

        public bool IsRaceFinished(List<RaceParticipant> raceParticipants)
        {
            if (raceParticipants[0].Distance >= raceLength)
            {
                return false;
            }
            return true;
        }
    }
}
