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
                string query = $"insert into Trip " +
                    $"(id, id_bus, datestart) " +
                    $"values " +
                    $"({trip.Id}, " +
                    $"{trip.Bus.Id}, " +
                    $"CONVERT(datetime, '{trip.DateArrival}',120) )";
                connection.Execute(query);
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
