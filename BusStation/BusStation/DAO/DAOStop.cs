using BusStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.DAO
{
    public interface DAOStop
    {
        List<Stop> GetAll();
        List<Stop> GetManyBySelector(Predicate<Stop> match);
        void Add(Stop stop);
        void Delete(long id);
    }
}
