using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using MISA.Library.Entities;

namespace MISA.AMIS.WEB081_NVMANH.Api.Controllers
{
    [Route("api/v1/CustomerGroups")]
    [ApiController]
    public class CustomerGroupsController : ManhController<CustomerGroup>
    {
    }
}
