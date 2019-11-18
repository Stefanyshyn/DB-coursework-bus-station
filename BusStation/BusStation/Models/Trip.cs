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
        public Station[] stations { get; set; }
        public Bus bus { get; set; }
        
    }
}
