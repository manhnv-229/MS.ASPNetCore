using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MS.JWT.Demo.Interfaces;
using MS.JWT.Demo.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MS.JWT.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Xác thực người dùng thông qua userName và Password. Đây là ví dụ đơn giản giả lập với dữ liệu giả.
            var isAuthenticated = _userService.Authenticate(model.UserName, model.Password);

            if (isAuthenticated)
            {
                // Tạo claims thông tin người dùng để lưu vào JWT:
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    // Các Claim khác nếu cần (ví dụ như vai trò người dùng)
                };

                // Tạo JWT Token:
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:8080",
                    audience: "web_app",
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: credentials
                    );
                // Chuyển token thành chuỗi và trả về cho người dùng
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { token = jwtToken });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
