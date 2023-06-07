using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class PresedentApprovalBO
    {
        public int AGENCY_ID { get; set; }
        public string AGENCY_NAME { get; set; }
        public string AGENCY_ADDRESS { get; set; }
        public string CREATION_DATE { get; set; }
        public string UPDATION_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        public string ISVISIBLE { get; set; }
        public string REMARK1 { get; set; }
        public string REMARK2 { get; set; }
        public int GrantID { get; set; }
        public string Status { get; set; }

        public string EMPCODE { get; set; }

        public string LETTERNAME { get; set; }

        public int LETTERID { get; set; }

        public string proxy { get; set; }

        public string FILEPATH
        {
            get; set;
        }

        public string Update_Type { get; set; }
        public string ECODE { get; set; }

        public string START_DATE { get; set; }
        public string END_DATE { get; set; }
    }
} 
