using BusStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.DAO
{
    public interface DAODocument
    {
        Document GetOne(int id);
        void Add(Document document);
        void Update(Document document);
    }
}
