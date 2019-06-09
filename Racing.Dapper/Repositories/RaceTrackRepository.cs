using Dapper;
using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Racing.Dapper.Repositories
{
    public class RaceTrackRepository
    {
        public IEnumerable<RaceTrack> GetAllRaceTracks()
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                return connection.Query<RaceTrack>(@"
                    SELECT RaceTrackId, Name, Length
                    FROM RaceTrack"
                );
            }
        }

        public void AddRaceTrack(RaceTrack raceTrack)
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                connection.Execute(@"
                    INSERT INTO RaceTrack (RaceTrackId, Name, Length)
                    VALUES (@RaceTrackId, @Name, @Length)
                ", new
                {
                    RaceTrackId = raceTrack.RaceTrackId,
                    Name = raceTrack.Name,
                    Length = raceTrack.Length
                });
            }
        }

        public void DeleteRaceTrack(RaceTrack raceTrack)
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                connection.Execute(@"
                    DELETE FROM RaceTrack
                    WHERE RaceTrackId = @RaceTrackId
                ", new
                {
                    RaceTrackId = raceTrack.RaceTrackId
                }
                );
            }
            
        }
    }
}
