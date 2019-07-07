using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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
    }
}
