using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
    public class CommonBAL
    {
        public bool LogExceptionDB(string PageName, string MethodName, string exMsg, string exstack)
        {
            bool OutputStr;
            CommonDAL objMasterDAL = new CommonDAL();
            OutputStr = objMasterDAL.LogExceptionDB(PageName, MethodName, exMsg, exstack);
            return OutputStr;
        }

        public DataSet Execute_Query(string Query)
        {
            CommonDAL objMasterDAL = new CommonDAL();
            return objMasterDAL.Execute_Query(Query);
        }
    }
}
