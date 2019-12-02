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
    public class TripAccess : DAOTrip
    {
        public void Add(Trip trip)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                if (this.checkAddTrip(trip)){
                    string query = $"insert into Trip " +
                       $"(id_bus, datestart, dateend) " +
                       $"values " +
                       $"({trip.Bus.Id}, " +
                       $"CONVERT(datetime, '{trip.DateArrival.ToString("yyyy - MM - dd HH: mm")}',120), " +
                       $"CONVERT(datetime, '{trip.DateDeparture.ToString("yyyy - MM - dd HH: mm")}',120) )";
                    connection.Execute(query);
                }
            }
        }
        private bool checkAddTrip(Trip trip)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select * from  Trip t where id_bus = 1 " +
                    $"and( " +
                        $"(convert(datetime,'{trip.DateArrival.ToString("yyyy-MM-dd HH:mm")}',120) < t.datestart and convert(datetime,'{trip.DateArrival.ToString("yyyy-MM-dd HH:mm")}',120) < t.datestart) " +
                        $"or " +
                        $"(convert(datetime,'{trip.DateDeparture.ToString("yyyy-MM-dd HH:mm")}',120) > t.dateend and convert(datetime,'{trip.DateDeparture.ToString("yyyy-MM-dd HH:mm")}',120) > t.dateend) " +
                    $") ";
                
                int all = this.GetAll().Count;
                int selectDate = connection.Query<int>(query).ToList().Count;
                
                if (all == selectDate) return true;
                return false;
            }
        }
        public void Delete(long id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"delete from Trip where id = {id}";
                connection.Execute(query);
            }
        }

        public List<Trip> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select * from Trip";
                List<Trip> trips = connection.Query<Trip>(query).ToList();
                return trips;
            }
        }

        public List<Trip> GetManyBySelector(Predicate<Trip> match)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select * from Trip";
                List<Trip> trips = connection.Query<Trip>(query).ToList();
                return trips.FindAll(match);
            }
        }

        public Trip GetOne(long id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select * from Trip where id = {id}";
                List<Trip> trips = connection.Query<Trip>(query).ToList();
                return trips[0];
            }
        }

        public List<Station> GetTripStations(long id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = $"select id_station, name from GetStations where id_trip = {id}";
                List<Station> stations = connection.Query<Station>(query).ToList();
                return stations;
            }
        }
    }
}
