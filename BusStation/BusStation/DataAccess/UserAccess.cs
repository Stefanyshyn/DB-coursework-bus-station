using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusStation.DAO;
using BusStation.Models;
using Dapper;

namespace BusStation.DataAccess
{
    public class UserAccess : DAOUser
    {
        public List<User> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "select * from [User]";
                return connection.Query<User>(query).ToList();
            }
        }
        public List<User> GetManyBySelector(Predicate<User> match)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "select * from [User]";
                var users = connection.Query<User>(query).ToList();
                return users.FindAll(match);
            }
        }
        public void Add(User user)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"insert into [User] " +
                    $"(username, password, createAt) " +
                    $"values ('{user.Username}', '{user.Password}', GETDATE())";
                connection.Execute(query);
            }
        }
        public User GetOne(long id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "select * from [User] where Id = " + id;
                var users = connection.Query<User>(query).ToList();
                return users[0];
            }
        }
    }
}
