using BusStation.DAO;
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
    public class StopAccess : DAOStop
    {
        public void Add(Stop stop)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"insert into Stop " +
                    $"(id_trip, id_station,timestop,distance) " +
                    $"values " +
                    $"({stop.trip.Id}, " +
                    $"{stop.station.id}, " +
                    $"CONVERT(time, '{stop.timestop}',120), " +
                    $"12.1)";
                connection.Execute(query);
            }
        }

        public void Delete(long id_trip, long id_station)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"delete from Fullstop where id_trip = {id_trip} AND id_station = {id_station}";
                connection.Execute(query);
            }
        }

        public List<Stop> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select * from Fullstop";
                var stops = connection.Query<Stop>(query).ToList();
                return stops;
            }
        }

        public List<Stop> GetManyBySelector(Predicate<Stop> match)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select * from Fullstop order by timestop";
                var stops = connection.Query<Stop>(query).ToList();
                return stops.FindAll(match);
            }
        }

        public Stop GetOne(long id_trip, long id_station)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select * from Fullstop where id_trip = {id_trip} AND id_station = {id_station}";
                var stops = connection.Query<Stop>(query).ToList();
                return stops[0];
            }
        }
    }
}
