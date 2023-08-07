using MS.JWT.Demo.Entities;
using MS.JWT.Demo.Interfaces;
using MS.JWT.Demo.Model;

namespace MS.JWT.Demo.Service
{
    public class UserService : IUserService
    {
        // Dữ liệu demo với thông tin username và password:
        private static List<User> _users = new List<User>()
        {
            new User()
            {
                UserName="nvmanh",
                Email="manhnv229@gmail.com",
                Password="12345678",
                RoleName="admin"
            },
             new User()
            {
                UserName="test",
                Email="example@gmail.com",
                Password="12345678",
                RoleName="user"
            }
        };

        public bool Authenticate(string username, string password)
        {
            var user = _users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
