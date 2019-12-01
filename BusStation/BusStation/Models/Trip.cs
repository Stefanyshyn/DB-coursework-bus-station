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
        public DateTime DateArrival { get; set; }
        public Trip(int id, int id_bus, DateTime date_arrival)
        {
            this.Id = id;
            
            BusAccess db = new BusAccess();
            this.Bus = db.GetOne(id_bus);

            this.DateArrival = date_arrival;
        }
    }
}