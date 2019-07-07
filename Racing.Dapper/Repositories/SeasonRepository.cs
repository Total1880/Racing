using Dapper;
using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Racing.Dapper.Repositories
{
    public class SeasonRepository
    {
        public int GetSeasonNumber()
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                return connection.ExecuteScalar<int>
                    (
                        @"SELECT MAX(SeasonId)
                        FROM Season"
                    );
            }
        }

        public void CreateNewSeason(int seasonId)
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                connection.Execute
                    (
                        "IF NOT EXISTS (SELECT * FROM Season WHERE SeasonId = @SeasonId)" +
                        "BEGIN" +
                        "   INSERT INTO Season (SeasonId)" +
                        "   VALUES (@SeasonId)" +
                        "END",
                        new
                        {
                            SeasonId = seasonId
                        }
                    );
            }
        }
        public List<Race> GetRacesFromSeason(int seasonId)
        {
            List<Guid> RaceListId = new List<Guid>();
            List<Race> RaceList = new List<Race>();
            RaceRepository raceRepository = new RaceRepository();

            RaceListId = GetRacesIdFromSeason(seasonId).ToList();

            foreach (Guid raceId in RaceListId)
            {
                Race race = new Race(raceId, raceRepository.GetRaceParticipantsOfRace(raceId).ToList());
            }

            return RaceList;
        }

        private IEnumerable<Guid> GetRacesIdFromSeason(int SeasonId)
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                return connection.Query<Guid>
                    (
                        "SELECT RaceId" +
                        "FROM Race" +
                        "WHERE SeasonId = @SeasonId"
                    );
            }
        }
    }
}
