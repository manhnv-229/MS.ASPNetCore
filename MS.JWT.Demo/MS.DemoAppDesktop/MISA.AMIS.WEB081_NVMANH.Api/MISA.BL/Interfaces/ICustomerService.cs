using MISA.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Interfaces
{
    public interface ICustomerService
    {
        bool InsertService(Customer customer);
        int ImportService(IFormFile file);
    }
}
