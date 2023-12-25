using MISA.BL.Interfaces;
using MISA.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Service
{
    public class CustomerService : ICustomerService
    {
        public int ImportService(IFormFile file)
        {
           

            throw new NotImplementedException();
        }

        public bool InsertService(Customer customer)
        {
            // Validate dữ liệu:

            // Nếu dữ liệu hợp lệ thì trả về true:
            if (!String.IsNullOrEmpty(customer.FullName))
            {
                
                return true;
            }
            else
            {
                // Nếu dữ liệu không hợp lệ thì trả về false
                return false;
            }
            
        }
    }
}
