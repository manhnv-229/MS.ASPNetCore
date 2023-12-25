using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MISA.AMIS.WEB081_NVMANH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManhController<T> : ControllerBase
    {
       

        public ManhController()
        {
          
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            // Trả về dữ liệu cho client:
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
           
            return StatusCode(201, 1);
            //=> Build chuỗi thực thi thêm mới:

            // Thực hiện thêm mới:

            // Trả về dữ liệu:
        }
    }
}
