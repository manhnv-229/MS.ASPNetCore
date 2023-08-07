using System.ComponentModel.DataAnnotations;

namespace MS.JWT.Demo.Model
{
    public class LoginModel
    {
        public LoginModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        [Required(ErrorMessage = "Tài khoản không được phép để trống", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được phép để trống", AllowEmptyStrings = true)]
        public string Password { get; set; }
    }
}
