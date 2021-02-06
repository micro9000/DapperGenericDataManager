using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DapperGenericDataManager;

namespace MVCDotNetFrameworkSample.Models
{
    public class ApplicationDBConnectionSettings
    {
        public IDbConnectionFactory ConnectionString { get; set; }

        public DataManagerCRUDEnums.DatabaseAdapter Adapter { get; set; }
    }
}