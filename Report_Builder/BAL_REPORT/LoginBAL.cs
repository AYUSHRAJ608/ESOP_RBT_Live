using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_REPORT;
using DAL_REPORT;
using System.Data;

namespace BAL_REPORT
{
    public class LoginBAL
    {
     
        LoginDAL objdal = new LoginDAL();
        public DataSet Validuser(LoginBO objbo)
        {
            return objdal.Validuser(objbo);
        }
    }
}
