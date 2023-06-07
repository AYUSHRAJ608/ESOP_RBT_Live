using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL_REPORT
{
   public  class ConnectionStringDAL
    {
      
        public static string Getconnectionstring(string keyname)
        {
            string connection = string.Empty;
            switch (keyname)
            {
                case "PMS":
                    connection = ConfigurationManager.ConnectionStrings["SQLConStringPMS"].ConnectionString;
                    break;
                case "ESOP":
                    connection = ConfigurationManager.ConnectionStrings["SQLConStringESOP"].ConnectionString;
                    break;
                default:
                    break;
            }
            return connection;
        }
    }
}
