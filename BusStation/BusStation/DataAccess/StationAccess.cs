using BusStation.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.DataAccess
{
    public class StationAccess
    {
        public string Insert(string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "insert into Station (name) values ('" + name + "')";
                try
                {
                    var a = connection.Query<string>(query);
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
                return "Success";
            }
        }
    }
}
