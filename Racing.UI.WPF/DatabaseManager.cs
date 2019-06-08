using Racing.Dapper;
using Racing.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.UI.WPF
{
    class DatabaseManager
    {
        private static readonly DatabaseManager _manager = new DatabaseManager();

        public static DatabaseManager Instance => _manager;

        public DriverRepository DriverRepository => new DriverRepository();

        private DatabaseManager()
        {
            Connection.Instance.SetConnection(@"Server=localhost\SQLExpress;Initial Catalog=Racing;Integrated Security=True");
        }
    }
}
