using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ESOP_BO
{
    public class LetterEditBO
    {
        public string ImgPath { get; set; }

        public string UPLOADType { get; set; }

        public string ImageType { get; set; }

        public string CreatedBy { get; set; }
        public int LetterID { get; set; }

        public string LetterName { get; set; }
        public string Status { get; set; }

        public string EMPCODE { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }
        public string Content { get; set; }
        public string Signature { get; set; }
        public string Designation { get; set; }

    }
}

