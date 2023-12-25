using MISA.DatabaseLayer.Interfaces;
using MySqlConnector;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using MISA.Library.Entities;

namespace MISA.DatabaseLayer
{
    public class MISADatabaseContext<MISAEntity> : IMISADatabaseContext<MISAEntity>
    {
        protected readonly string _connectionString = "" +
           "Host=8.222.228.150;" +
           "Port=3306; " +
            "Database=MS.NVMANH;" +
            "User Id=nvmanh;" +
            "Password=12345678";
        protected MySqlConnection _connection;

        protected string _tableName;
        public MISADatabaseContext()
        {
            _tableName = typeof(MISAEntity).Name;
            _connection = new MySqlConnection(_connectionString);
        }

        public int Delete(MISAEntity item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetCustomersAbc()
        {
            // Khai báo câu truy vấn lấy dữ liệu:
            var sql = $"SELECT * FROM {_tableName}";

            // Thực hiện lấy dữ liệu:
            var data = _connection.Query<Employee>(sql);

            // Trả về dữ liệu cho client:
            return data;
        }
        public List<MISAEntity> GetAll()
        {
            // Khai báo câu truy vấn lấy dữ liệu:
            var sql = $"SELECT * FROM {_tableName}";

            // Thực hiện lấy dữ liệu:
            var customers = _connection.Query<MISAEntity>(sql);

            // Trả về dữ liệu cho client:
            return customers.ToList();
        }

        public int Insert(MISAEntity entity)
        {
            // Câu lệnh thêm mới:
            var colNameList = ""; // CustomerId,CustomerCode,....
            var colParamList = "";// @CustomerId,@CustomerCode...


            // Lấy ra các properties của đối tượng:
            var props = typeof(MISAEntity).GetProperties();
            // Khai bảo param:
            var parameters = new DynamicParameters();

            // Duyệt từng prop:
            foreach (var prop in props)
            {
                //-> Lấy tên của prop
                var propName = prop.Name;
                var value = prop.GetValue(entity);

                // -> Lấy value của prop:
                colNameList = colNameList + $"{propName},";
                colParamList = colParamList + $"@{propName},";
                parameters.Add($"@{propName}", value);
            }

            // Bỏ dấu, sau cùng:
            colNameList = colNameList.Substring(0, colNameList.Length - 1);
            colParamList = colParamList.Substring(0, colParamList.Length - 1);
            var sql = $"INSERT INTO {_tableName}({colNameList})VALUES({colParamList})";
            var res = _connection.Execute(sql, parameters);
            return res;
            //=> Build chuỗi thực thi thêm mới:

            // Thực hiện thêm mới:

            // Trả về dữ liệu:
        }

        public int Update(MISAEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
