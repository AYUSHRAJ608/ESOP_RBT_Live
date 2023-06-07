using ESOP_BO;
using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
    public class HRMS_BAL
    {
        HRMS_DAL objHRMS_DAL = new HRMS_DAL();
        private object objEmpDAL;

        public DataSet GETMERGEEMPCHECK()
        {
            return objHRMS_DAL.GETMERGEEMPCHECK();
        }
        public int UPDATEMERGEEMPCHECK(string flag, string modifiedby)
        {
            return objHRMS_DAL.UPDATEMERGEEMPCHECK(flag, modifiedby);
        }
        public DataSet UserFilter(HRMSIntegrationBO emp)
        {
            return objHRMS_DAL.UserFilter(emp);
        }

        public DataSet GETMERGEEMPDATA()
        {
            return objHRMS_DAL.GETMERGEEMPDATA();
        }

        public int INSERTMERGEEMPDATA(string emplist, string modifiedby)
        {
            return objHRMS_DAL.INSERTMERGEEMPDATA(emplist, modifiedby);
        }

        public int UPDATEMERGEEMPDATA(string emplist, string empDeletelist, string modifiedby)
        {
            return objHRMS_DAL.UPDATEMERGEEMPDATA(emplist,empDeletelist, modifiedby);
        }

        public DataSet FetchEmployeeData(cEmployeeEntityRequest _objGoals)
        {
            return objHRMS_DAL.FetchEmployeeData();
        }
        public DataSet getEmpIDName(string search)
        {
            return objHRMS_DAL.getEmpIDName(search);
        }
        public DataSet GetAdminGoalsFilter()
        {
            return objHRMS_DAL.GetAdminGoalsFilter();
        }
        public DataSet GetEmpNameList()
        {
            return objHRMS_DAL.GetEmpNames();
        }
        public int updateEmpDetails(HRMSIntegrationBO objEmployee)
        {
            return objHRMS_DAL.updateEmpDetails(objEmployee);
        }

    }
}
