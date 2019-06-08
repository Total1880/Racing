using Racing.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Racing.Dapper;
using Dapper;

namespace Racing.Dapper.Repositories
{
    public class DriverRepository
    {
        public IEnumerable<Driver> GetAllDrivers()
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                return connection.Query<Driver>
                (
                    @"SELECT DriverId, FirstName, LastName, Speed
                    FROM Driver"
                );
            }
        }
    }
}
