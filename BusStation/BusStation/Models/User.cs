using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Models
{
    class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Profile profile { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
