using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class UserBO
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
        public string gender { get; set; }
        public string ECode { get; set; }
        public string IPAddress { get; set; }

    }
    public class cUserEntityRequest
    {
        public UserBO UserEntity { get; set; }

    }
    public class cUserEntityResponse
    {
        public UserBO UserEntity { get; set; }
        //public List<cUserEntity> InsertMaster { get; set; }
        public List<UserBO> lstcUserEntity = new List<UserBO>();
    }
}
