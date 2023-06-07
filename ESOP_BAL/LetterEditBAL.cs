using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESOP_BO;
using System.Data;

namespace ESOP_BAL
{
    public class LetterEditBAL
    {
    

        public bool InsertLetterDetails(LetterEditBO objEntity)
        {
            try
            {
                LetterEditDAL objDAL = new LetterEditDAL();
                return (objDAL.InsertLetterDetails(objEntity));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int InsertLetterConfig(LetterEditBO objEntity)
        {
            try
            {
                LetterEditDAL objDAL = new LetterEditDAL();
                return (objDAL.InsertLetterConfig(objEntity));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool DeleteLetterDetails(LetterEditBO objEntity)
        {
            try
            {
                LetterEditDAL objDAL = new LetterEditDAL();
                return (objDAL.DeleteLetterDetails(objEntity));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetLetterEditDetails(LetterEditBO objEntity)
        {
            try
            {
                LetterEditDAL objDAL = new LetterEditDAL();
                return (objDAL.GetLetterEditDetails(objEntity));
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet report(LetterEditBO objbo)
        {
            try
            {
                LetterEditDAL objDAL = new LetterEditDAL();
                return (objDAL.report(objbo));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetReportDesign(LetterEditBO objbo)
        {
            try
            {
                LetterEditDAL objDAL = new LetterEditDAL();
                return (objDAL.GetReportDesign(objbo));              
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

    }
}
