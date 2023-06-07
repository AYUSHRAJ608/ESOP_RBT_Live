using ESOP_BO;
using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
    public class EmailLinkApp_RejectBAL
    {
    
        EmailLinkApp_RejectDAL EmailLinkApp_RejectDAL = new EmailLinkApp_RejectDAL();
      
        public bool Update_Status(int GrantID, string Status, string GrantName)
        {
           return EmailLinkApp_RejectDAL.UpdateStatus(GrantID,Status, GrantName);
        }
        
    }
}
