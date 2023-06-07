using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class PresidentBO
    {
        public int EmpID { get; set; }
        public string UserID { get; set; }
        public int RoleID { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? LastLogoutTime { get; set; }
        public string IsActive { get; set; }
        public string Emp_Name { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public int IsLoggedIn { get; set; }
        public string RoleName { get; set; }
        public string Action { get; set; }
        public string ECode { get; set; }

        public string GRANT_NAME { get; set; }

        public int LAPS { get; set; }
        public string V_ID { get; set; }

        public int LBV { get; set; }

        public int LAV { get; set; }
        public string Remark { get; set; }
        public DateTime? LapseDate { get; set; }
        public string GRANT_ID { get; set; }
        public string VestingD_ID { get; set; }
    }  
}
