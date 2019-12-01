using BusStation.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public Bus Bus { get; set; }
        private List<Station> stations = new List<Station>(); 
        public DateTime DateArrival { get; set; }
        public Trip(int id, int id_bus, DateTime datestart)
        {
            this.Id = id;
            this.stations = this.fillStation(this.Id);
            BusAccess db = new BusAccess();
            this.Bus = db.GetOne(id_bus);

            this.DateArrival = datestart;
        }
        public List<Station> getStation() {
            return this.stations;
        }
        private List<Station> fillStation(long id)
        {
            TripAccess db = new TripAccess();
            var stations = db.GetTripStations(id);
            return stations;
        }
    }
}