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

        public void AddDriver(Driver driver)
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                connection.Execute(@"
                    INSERT INTO Driver (DriverId, FirstName, LastName, Speed)
                    VALUES (@DriverId, @FirstName, @LastName, @Speed)
                ", new
                {
                    DriverId = driver.DriverId,
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    Speed = driver.Speed
                });
            }
        }
    }
}
