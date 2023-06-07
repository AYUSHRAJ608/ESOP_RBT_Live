using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class LetterConfigBO
    {
        public int LetterConfig_ID { get; set; }
        public string Letter_NAME { get; set; }           
     
        public string Modified_BY { get; set; }
        
        public string ISACTIVE { get; set; }    
      
        public string FilePath { get; set; }

        public string EMPCODE { get; set; }

        public string IsDelete { get; set; }

        public string Mode { get; set; }

        public string UPLOADType { get; set; }

    }
}
