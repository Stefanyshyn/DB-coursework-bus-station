using BusStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using BusStation.DAO;

namespace BusStation.DataAccess
{
    public class BusAccess : DAOBus
    {
        public void Add(Bus bus)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnValue("bus_station")))
            {
                string query = "insert into Bus (seats) values (" + bus.Seats + ")";
                var a = connection.Query<string>(query);
            }
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Bus> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Bus> GetManyBySelector(Predicate<Bus> match)
        {
            throw new NotImplementedException();
        }

        public Bus GetOne(long id)
        {
            throw new NotImplementedException();
        }
        public void Update(Bus bus)
        {
            throw new NotImplementedException();
        }
    }
}