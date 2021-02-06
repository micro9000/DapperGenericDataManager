using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DapperGenericDataManager;
using Dapper;
using MVCDotNetFrameworkSample.Models;
using Unity;

namespace MVCDotNetFrameworkSample.Services
{
    public class StudentsData : DataManagerCRUD<Student>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public StudentsData([Dependency("Main")] IDbConnectionFactory dbConnectionFactory) 
            : base (DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public Student GetByStdNum(string stdNum)
        {
            string query = "SELECT * FROM Students WHERE stdNum=@StdNum";
            return this.GetFirstOrDefault(query, new
            {
                StdNum = stdNum
            });
        }
    }
}