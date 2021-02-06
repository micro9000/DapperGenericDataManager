using System;
using System.Collections.Generic;
using System.Text;

namespace DapperGenericDataManager
{
    public class DataManagerCRUDEnums
    {
        public enum DatabaseAdapter
        {
            sqlconnection,
            sqlceconnection,
            npgsqlconnection,
            sqliteconnection,
            mysqlconnection,
            fbconnection
        }
    }
}
