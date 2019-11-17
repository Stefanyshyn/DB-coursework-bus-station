using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.Models;
using Dapper;

namespace BusStation.DataAccess
{
    public class UserAccess
    {
        public List<User> getUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "select * from [Fulluser]";
                return connection.Query<User>(query).ToList();
            }
                return null;
        }
    }
}
