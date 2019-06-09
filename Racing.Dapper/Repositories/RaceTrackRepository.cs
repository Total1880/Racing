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
    }
}
