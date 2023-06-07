using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BO
{
    public class Exercise_CancelBO
    {
        public int ECODE { get; set; }
        public string ENAME { get; set; }
        public string Grant_Name { get; set; }
        public string Vesting_Detail_Code { get; set; }
        public int Exercise_Tran_Id { get; set; }
        public int Total_Vesting { get; set; }
        public int EXERCISE_PENDING { get; set; }
        public int Total_Exercise_Approved { get; set; }
        public int Remaining_Vesting { get; set; }


    }

    public class Exercise_BtnRevertBO
    {
        public int ECODE { get; set; }
        public string ENAME { get; set; }
        public string Grant_Name { get; set; }
        public string Vesting_Detail_Code { get; set; }
        public int Exercise_Tran_Id { get; set; }
        public int Total_Vesting { get; set; }
        public int EXERCISE_PENDING { get; set; }
        public int Total_Exercise_Approved { get; set; }
        

        public string Remark { get; set; }
        public string Status { get; set; }
        public DateTime Reverted_Date { get; set; }
    }
}
