using MISA.DatabaseLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DatabaseLayer
{
    public class ProDatabaseContext<T> : IMISADatabaseContext<T>
    {
        public int Delete(T item)
        {
            throw new NotImplementedException();
        }

        public List<T>? GetAll()
        {
            // Lấy dữ liệu từ mongoDb:
            //......
            return null;
        }

        public int Insert(T item)
        {
            throw new NotImplementedException();
        }

        public int Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
