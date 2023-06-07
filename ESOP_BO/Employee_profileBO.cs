using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class Employee_profileBO
    {
        public int ID { get; set; }
        public string ECODE { get; set; }
        public string BANK_NAME { get; set; }
        public string BRANCH_NAME { get; set; }
        public string ACC_NO { get; set; }
        public string IFSC { get; set; }

        public string empstatus { get; set; }

        public string FILE_PATH { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public string ISACTIVE { get; set; }


    
        public string SECURITY_NAME { get; set; }
        public string DPID { get; set; }
        public string CLIENT_ID { get; set; }
        public string MEMBER_TYPE { get; set; }

        public string email_id { get; set; }
         public string profile_img { get; set; }
    }
}
