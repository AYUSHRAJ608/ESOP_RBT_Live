using ESOP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP_BAL
{
   public class LetterList_BAL
    {
        LetterList_DAL LetterDALobj = new LetterList_DAL();

        //Added by Rahul_Natu on 20-10-2021
        public DataSet UpdateTimestamp(string ID, string key, string EmpID)
        {
            return LetterDALobj.UpdateTimestamp(ID, key, EmpID);
        }
        //End

        public DataSet GetLetter_List(string EmpID)
        {
            return LetterDALobj.GetLetter_List(EmpID);
        }

        public DataSet GetLetter_ListForALL()
        {
            return LetterDALobj.GetLetter_ListForALL();
        }
        public DataSet GetGrant_Letter_List(string EmpID)
        {
            return LetterDALobj.GetGrant_Letter_List(EmpID);
        }

        public DataSet GetGrant_Letter_ListForALL()
        {
            return LetterDALobj.GetGrant_Letter_ListForALL();
        }
        public DataSet Getsales_Letter_List(string EmpID)
        {
            return LetterDALobj.Getsales_Letter_List(EmpID);
        }

        public DataSet Getsales_Letter_ListForALL()
        {
            return LetterDALobj.Getsales_Letter_ListForALL();
        }
        public DataSet GET_Letter_List_Type_DownloadLink(int id)
        {
            return LetterDALobj.GET_Letter_List_Type_DownloadLink(id);
        }

        public bool UpdateTimestamp(string iD, string key, string v, object sTATUS)
        {
            throw new NotImplementedException();
        }

        //public bool UpdateTimestamp(string iD, string key, string v, object status)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
