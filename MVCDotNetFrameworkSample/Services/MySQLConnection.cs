using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using DapperGenericDataManager;
using MySql.Data.MySqlClient;

namespace MVCDotNetFrameworkSample.Services
{
    public class MySQLConnection : IDbConnectionFactory
    {
        public DbConnection CreateConnection()
        {
            var connection = new MySqlConnection("Server=127.0.0.1; Port=3306;Database=elearning_db;Uid=root;password=;Persist Security Info=True;Allow Zero Datetime=True;CharSet=utf8;");
            connection.Open();
            return connection;
        }
    }
}