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
    public class EMailBAL
    {
        public string SendHtmlFormattedEmail(EMailBO objEntity)
        {
            EMailDAL objDal = new EMailDAL();
            try
            {
                return objDal.SendHtmlFormattedEmail(objEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDal = null;
            }
        }

        public bool InsertEmailDetails(EMailBO objEntity)
        {
            try
            {
                EMailDAL objDAL = new EMailDAL();
                return (objDAL.InsertEmailDetails(objEntity));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetEMPDetails(EMailBO objEntity)
        {
            try
            {
                EMailDAL objDAL = new EMailDAL();
                return (objDAL.GetEMPDetails(objEntity));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetEMPDetailsPresident(EMailBO objEntity)
        {
            try
            {
                EMailDAL objDAL = new EMailDAL();
                return (objDAL.GetEMPDetailsPresident(objEntity));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetEMPDetailsPresident1(EMailBO objEntity)
        {
            try
            {
                EMailDAL objDAL = new EMailDAL();
                return (objDAL.GetEMPDetailsPresident1(objEntity));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //------------------------------------------------
        EMailBO objEmail = new EMailBO();
        EMailDAL objEmailDal = new EMailDAL();
        public DataSet insertEmail(cEmailEntityRequest req)
        {
            return objEmailDal.insertEmail(req);
        }
        public DataSet getDropDown()
        {
            return objEmailDal.getDropdown();
        }
        public DataSet GetEmailID()
        {
            return objEmailDal.GetEmailID();
        }
        public DataSet GetAddCC()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("Text");
            table1.Columns.Add("Value");
            table1.Rows.Add("Admin", 1);
            table1.Rows.Add("HR Head", 2);
            table1.Rows.Add("President", 3);
            table1.Rows.Add("Checker", 6);

            DataSet ds = new DataSet();
            ds.Tables.Add(table1);

            return ds;
        }
    }
}
