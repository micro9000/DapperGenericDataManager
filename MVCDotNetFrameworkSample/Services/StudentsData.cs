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


        // Use dapper only
        public long[] GetAllPLSTIDsByOriginator(string originatorFFId, int[] overAllStatus)
        {
            string query = @"SELECT id FROM ProductLotScraps 
							WHERE originatorFFID=@OriginatorFFId AND overallStatusEnumVal IN @OverallStatus";

            long[] results = { };

            using (var conn = _dbConnectionFactory.CreateConnection())
            {
                results = conn.Query<long>(query, new
                {
                    OriginatorFFId = originatorFFId,
                    OverallStatus = overAllStatus
                }).ToList().ToArray();
                conn.Close();
            }

            return results;
        }
    }
}