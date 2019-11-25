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
        public List<Station> Stations { get; set; }
        public Bus Bus { get; set; }
        public DateTime DateArrival { get; set; }
        public DateTime DateDeparture { get; set; }
    }
}
