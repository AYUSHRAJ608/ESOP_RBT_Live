using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class AdminBO
    {

        public int GRANT_ID { get; set; }
        public string GRANT_NAME { get; set; }
        public string DATE_OF_GRANT { get; set; }
        public string EMP_ID { get; set; }
        public int FMV_ID { get; set; }
        public int VESTING_ID { get; set; }
        public int NO_OF_OPTION { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_DATE { get; set; }
        public string IS_VISIBLE { get; set; }
        public string REMARK1 { get; set; }
        public string REMARK2 { get; set; }
        public string GPrice { get; set; }
        public string username { get; set; }
        public int VID { get; set; }

        public string admin_remark { get; set; }
        
    }
}
