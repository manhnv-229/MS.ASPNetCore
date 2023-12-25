using MySqlConnector;

namespace MISA.AMIS.WEB081_NVMANH.Api
{
    public class DatabaseContext
    {
        readonly string _connectionString = "Host=34.80.212.49;Port=3306; " +
              "Database=MS.NVMANH;" +
              "User Id=nvmanh;" +
              "Password=M@nhH@o89";
        MySqlConnection _connection;

        public DatabaseContext(MySqlConnection connection)
        {
            _connection = connection;
        }
    }
}
