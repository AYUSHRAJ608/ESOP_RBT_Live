using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESOP
{
    public class Grant_CorrectionBO
    {

        public int GRANT_ID { get; set; }
        public string Emp_code { get; set; }
        public string Emp_name { get; set; }
        public string Appraiser_name { get; set; }
        public DateTime DATE_OF_GRANT { get; set; }
        public int FMV_PRICE { get; set; }
        public int NO_OF_OPTION { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_DATE { get; set; }
        public string IS_VISIBLE { get; set; }
        public string REMARK1 { get; set; }
        public int VID { get; set; }

        public string admin_remark { get; set; }

        public string Grant_Name { get; set; }
        public string Key { get; set; }
    }
}