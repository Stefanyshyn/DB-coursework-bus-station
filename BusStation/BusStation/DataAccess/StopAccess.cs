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
                    $"(id_trip, id_station,timestart,distance) " +
                    $"values " +
                    $"({stop.trip.Id}, " +
                    $"{stop.station.id}, " +
                    $"CONVERT(time, '{stop.timestop}',120), " +
                    $"{stop.distance})";
                connection.Execute(query);
            }
        }

        public KeyValuePair<string, string> checkAddTime(TimeSpan time)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {

                string query = $"select " +
                $"date_min.m, date_max.m " +
                  $"from Stop, " +
                    $"(select " +
                      $"  max(timestart) m " +
                        $"from Stop " +
                        $"where timestart <= CONVERT(time, '{time.ToString()}', 120) ) date_max, " +
                   $" (select " +
                        $"min(timestart) m " +
                        $"from Stop " +
                        $"where timestart >= CONVERT(time, '{time.ToString()}', 120)) date_min " +
                        $"where id_trip = 1002; ";
                var date = connection.Query<KeyValuePair<string, string>>(query).ToList();
                return date[0];
            }
        }

        public void Delete(long id_trip, long id_station)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"delete from Stop where id_trip = {id_trip} AND id_station = {id_station}";
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
