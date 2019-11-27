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
        public List<User> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "select * from [User]";
                return connection.Query<User>(query).ToList();
            }
        }
        public List<User> GetAll(Predicate<User> match)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "select * from [User]";
                var users = connection.Query<User>(query).ToList();
                return users.FindAll(match);
            }
        }
        public bool Insert(string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "insert into [User] (username, password) values ('" + username + "', '" + password + "')";
                try
                {
                    connection.Execute(query);
                } catch (Exception ex) {
                    return false;
                } 
                return true;
            }
        }
    }
}
