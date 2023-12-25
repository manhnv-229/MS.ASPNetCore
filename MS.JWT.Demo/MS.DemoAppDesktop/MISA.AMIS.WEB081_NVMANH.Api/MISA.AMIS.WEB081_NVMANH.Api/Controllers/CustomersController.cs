using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using MISA.DatabaseLayer;
using MISA.BL.Service;
using MISA.Library.Entities;
using MISA.DatabaseLayer.Interfaces;
using MISA.BL.Interfaces;

namespace MISA.AMIS.WEB081_NVMANH.Api.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        IMISADatabaseContext<Customer> _databaseContext;
        ICustomerService _customerService;
        public CustomersController(IMISADatabaseContext<Customer> databaseContext, ICustomerService customerService)
        {
            _databaseContext = databaseContext;
            _customerService = customerService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            // Gọi lấy dữ liệu:
            // var data =  /....
            var name = GetName("abc");
            var customers = _databaseContext.GetAll();
            return Ok(customers);   
        }
       
        private string GetName(string name)
        {
            return name;
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            // xử lý nghiệp vụ và nhận kết quả:
            CustomerService customerSErvice = new CustomerService();
            var serviceResult = _customerService.InsertService(customer);

            // Nếu ok thì thêm mới vào database:
            if (serviceResult == true)
            {
                MISADatabaseContext<Customer> context = new MISADatabaseContext<Customer>();
                var res = context.Insert(customer);
                return StatusCode(201, res);
            }
            else
            {
                var res = new
                {
                    DevMsg = "Không hợp lệ",
                    UserMsg = "Dữ liệu không hợp lệ"
                };
                return StatusCode(400, res);
            }
        }
    }
}
