using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class HrapprovalBO
    {
        public int grantid { get; set; }
        public string ecode { get; set; }
        public string emp_name { get; set; }
        public string appraiser_name { get; set; }
        public string date_of_grant { get; set; }
        public string no_of_options { get; set; }
        public string fmv_price { get; set; }
        public string remark { get; set; }
        public string status { get; set; }
        public string UPDETED_BY { get; set; }

        public string proxy { get; set; }

        public int LetterId { get; set; }
    }
}
