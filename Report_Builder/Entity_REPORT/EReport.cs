using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_REPORT
{
    public class EReport
    {
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public string ReportDesc { get; set; }
        public int CreatedBy { get; set; }
        public string DomainName { get; set; }
        public string key { get; set; }
        public string Query { get; set; }


        public int empCode { get; set; }
        public int shareID { get; set; }

    }
}
