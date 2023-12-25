using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DatabaseLayer.Interfaces
{
    public interface IMISADatabaseContext<T>
    {
        List<T>? GetAll();
        int Insert(T item);
        int Update(T item);
        int Delete(T item);
    }
}
