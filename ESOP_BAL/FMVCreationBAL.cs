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
    public class FMVCreationBAL
    {

        FMVCreationBO objfmvbo = new FMVCreationBO();
        FMVCreationDAL FMVDAL = new FMVCreationDAL();
        public DataSet getfmv(FMVCreationBO objfmvbo)
        {
            return FMVDAL.getFmv(objfmvbo);
        }
        public DataTable getvaluedbyddl(FMVCreationBO objfmvbo)
        {
            return FMVDAL.getvaluedbyddl(objfmvbo);
        }

        //public DataTable getvaluedbyddl2()
        //{
        //    return FMVDAL.getvaluedbyddl2();
        //}
        public string Insert_Fmv(FMVCreationBO objfmvbo)
        {
            return FMVDAL.Insert_Fmv(objfmvbo);
        }


        public string FmvDelete(FMVCreationBO objfmvbo)
        {
           return FMVDAL.FmvDelete(objfmvbo);
        }

        public DataSet ESOP_FMV_CREATION_ALL_COUNT()
        {
            return FMVDAL.ESOP_FMV_CREATION_ALL_COUNT();
        }
        public DataSet GET_FMV_AUDIT(FMVCreationBO objfmvbo)
        {
            return FMVDAL.GET_FMV_AUDIT(objfmvbo);
        }
        public DataSet Insert_Emp_Password(FMVCreationBO objfmvbo)
        {
            return FMVDAL.Insert_Emp_Password(objfmvbo);
        }
    }
}
