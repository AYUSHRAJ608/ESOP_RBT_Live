using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class vesting_approvalBO
    {
        public int GRANT_ID { get; set; }
        public int VID { get; set; }
        public int V_DETAIL_ID { get; set; }
        public int NO_OF_VESTING { get; set; }
        public string ADMIN_VESTING_REMARK { get; set; }
        public string PR_VESTING_REMARK { get; set; }
        public string STATUS { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public string PROXY { get; set; }
        public string pr_vesting_remark { get; set; }
        public string EMPCODE { get; set; }
    }
}
