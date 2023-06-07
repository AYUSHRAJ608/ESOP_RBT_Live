using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class FMVCreationBO
    {
        public int FMV_CREATION_ID { get; set; }

        public DateTime VALUATION_DATE { get; set; }
        public DateTime VALID_UPTO_DATE { get; set; }
        public string FMV_PRICE { get; set; }
        public string VALUED_BY { get; set; }

        public int AGENCY_ID { get; set; }
        public string UPLOAD_FILE { get; set; }
        //public DateTime CREATION_DATE { get; set; }
        //public DateTime UPDATATION_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public string UPDATED_BY { get; set; }
        //public string ISVISIBLE { get; set; }
        //public string REMARK1 { get; set; }
        //public string REMARK2 { get; set; }
        public string msg { get; set; }

        public string btntext { get; set; }
    }
}
