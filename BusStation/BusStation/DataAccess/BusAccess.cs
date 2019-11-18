using BusStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BusStation.DataAccess
{
    public class BusAccess
    {
        public string Insert(Bus bus)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "insert into Bus (seats) values ('" + bus.seats + "')";
                try
                {
                    var a = connection.Query<string>(query);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "Success";
            }
        }
    }
}