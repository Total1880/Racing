﻿using Dapper;
using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        public IEnumerable<RaceParticipant> GetRaceParticipantsOfRace(Guid RaceId)
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                return connection.Query<RaceParticipant>
                    (
                        "SELECT Driver.FirstName AS FirstName, Driver.LastName AS LastName, RaceParticipant.DriverId AS DriverId, RaceParticipant.Position AS Position " +
                        "FROM RaceParticipant " +
                        "INNER JOIN Driver ON RaceParticipant.DriverId = Driver.DriverId " +
                        "WHERE RaceParticipant.RaceId = @RaceId",
                        new
                        {
                            RaceId = RaceId
                        }
                    );
            }
        }
    }
}
