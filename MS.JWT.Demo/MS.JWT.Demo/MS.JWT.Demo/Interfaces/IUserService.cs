namespace MS.JWT.Demo.Interfaces
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);
    }
}
