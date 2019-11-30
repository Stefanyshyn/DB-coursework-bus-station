using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Models
{
    public class Stop
    {
        public Bus bus { get; set; }
        public Station station { get; set; }
        public TimeSpan timestop { get; set; }
        public double distance { get; set; }
        public Stop(int id_bus, int seats, int id_station, string name_station, TimeSpan timestop, double distance)
        {
            this.bus = new Bus { Id = id_bus, Seats = seats };
            this.station = new Station { id = id_station, name = name_station.Trim() };
            this.timestop = timestop;
            this.distance = distance;
        }
    }
}