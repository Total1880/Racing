using Dapper;
using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Racing.Dapper.Repositories
{
    public class RaceRepository
    {
        public void CreateRace(Race newRace, int seasonId)
        {
            CreateRaceParticipants(newRace);

            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                connection.Execute(@"
                    INSERT INTO Race (RaceId, RaceTrackId, SeasonId)
                    VALUES (@RaceId, @RaceTrackId, @SeasonId)
                ", new
                {
                    RaceId = newRace.RaceId,
                    RaceTrackId = newRace.RaceTrackId,
                    SeasonId = seasonId
                });
            }
        }

        private void CreateRaceParticipants(Race race)
        {
            foreach (var driver in race.ListOfParticipants)
            {
                Guid participantId = Guid.NewGuid();
                using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
                {
                    connection.Execute(@"
                        INSERT INTO RaceParticipant (ParticipantId, DriverId, RaceId, Position)
                        VALUES (@ParticipantId, @DriverId, @RaceId, @Position)
                    ", new
                    {
                        ParticipantId = participantId,
                        DriverId = driver.DriverId,
                        RaceId = race.RaceId,
                        Position = driver.Position
                    });
                }
            }
        }
    }
}
