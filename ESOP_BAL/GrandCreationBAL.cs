using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESOP_BO;
using ESOP_DAL;
using System.Data;

namespace ESOP_BAL
{
    public class GrandCreationBAL
    {
        //GrandCreationBO objGCbo = new GrandCreationBO();
        GrandCreationDAL objGCDAL = new GrandCreationDAL();

        public DataSet Insert_GrandCreation(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_GrandCreation(objbo);
        }
        public DataSet GetMaxValue()
        {
            return objGCDAL.GetMaxValue();
        }
        public DataSet GetDropDown()
        {
            return objGCDAL.GetDropDown();
        }
        public DataSet GetUserDropDown(GrandCreationBO objbo)
        {
            return objGCDAL.GetUserDropDown(objbo);
        }
        public DataSet Insert_Copy_EMP(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_Copy_EMP(objbo);
        }
        public DataSet Vesting_Taxable_Income(GrandCreationBO objbo)
        {
            return objGCDAL.Vesting_Taxable_Income(objbo);
        }
        public DataSet Vesting_Taxable_Income_Append_Overwrite(GrandCreationBO objbo)
        {
            return objGCDAL.Vesting_Taxable_Income_Append_Overwrite(objbo);
        }
        public DataSet Insert_sale(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_sale(objbo);
        }
        public DataTable getFailedData()
        {
            //try
            {
                return objGCDAL.getFailedData_Dal();
            }
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    objGCDAL = null;
            //}
        }
        public DataTable getFailedData_Exercise(GrandCreationBO objbo)
        {
            //try
            {
                return objGCDAL.getFailedData_Dal_Exercise(objbo);
            }
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    objGCDAL = null;
            //}
        }
        public DataSet UserFilter(EmployeeBO objbo)
        {
            return objGCDAL.UserFilter(objbo);
        }

        //public DataTable getvaluedbyddl(FMVCreationBO objfmvbo)
        //{
        //    return FMVDAL.getvaluedbyddl(objfmvbo);
        //}
        public DataSet GetExerciseDates()
        {
            return objGCDAL.GetExerciseDates();
        }
        public DataSet GetActiveLetter()
        {
            return objGCDAL.GetActiveLetter();
        }
        public DataSet get_exercise_datewise_fmv(GrandCreationBO objbo)
        {
            return objGCDAL.get_exercise_datewise_fmv(objbo);
        }
        public DataSet get_fmv_ondate_ofgrant(GrandCreationBO objbo)
        {
            return objGCDAL.get_fmv_ondate_ofgrant(objbo);
        }
        public DataSet get_sell_datewise_fmv(GrandCreationBO objbo)
        {
            return objGCDAL.get_sell_datewise_fmv(objbo);
        }
        public DataSet GetSaleDates()
        {
            return objGCDAL.GetSaleDates();
        }
        public DataSet ESOP_GET_EXERCISE_SALE_VALIDATION(GrandCreationBO objbo)
        {
            return objGCDAL.ESOP_GET_EXERCISE_SALE_VALIDATION(objbo);
        }
        public DataSet ESOP_GET_EXCISE_sell_GRIDDATA()
        {
            return objGCDAL.ESOP_GET_EXCISE_sell_GRIDDATA();
        }
        public DataSet GetGrantName(GrandCreationBO objbo)
        {
            return objGCDAL.GetGrantName(objbo);
        }
        public DataSet GetGrantWiseData(GrandCreationBO objbo)
        {
            return objGCDAL.GetGrantWiseData(objbo);
        }
        public DataSet Insert_Copy_EMP_Override(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_Copy_EMP_Override(objbo);
        }
        public DataSet Insert_GrandCreation_Append_overeide(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_GrandCreation_Append_overeide(objbo);
        }
        public DataSet Emptydumptable(GrandCreationBO objbo)
        {
            return objGCDAL.ESOP_EMPTY_DUMP_TABLE(objbo);
        }

        //Added by Krutika on 05-01-23
        public DataSet Truncatedumptable(GrandCreationBO objbo)
        {
            return objGCDAL.ESOP_TRUNCATE_DUMP_TABLE(objbo);
        }
        //End

        //added by Pallavi on 07/03/2022
        public DataSet ESOP_ISSUED_GRANT(GrandCreationBO objBO)
        {
            return objGCDAL.ESOP_ISSUED_GRANT(objBO);
        }
        public bool Update_Excercise_BnkStatmnt(GrandCreationBO objbo)
        {
            return objGCDAL.Update_Excercise_BnkStatmnt(objbo);
        }
        public DataSet GET_FILEPATH(GrandCreationBO objbo)
        {
            return objGCDAL.GET_FILEPATH(objbo);
        }
        public DataSet Delete_GrandCreation(GrandCreationBO objbo)
        {
            return objGCDAL.Delete_GrandCreation(objbo);
        }
        public DataSet SaveGranttoCancelTbl(GrandCreationBO objbo)
        {
            return objGCDAL.SaveGranttoCancelTbl(objbo);
        }
        public DataSet Cancel_GrandCreation(GrandCreationBO objbo)
        {
            return objGCDAL.Cancel_GrandCreation(objbo);
        }
        public DataSet Save_GrandCreation(GrandCreationBO objbo)
        {
            return objGCDAL.Save_GrandCreation(objbo);
        }
        public DataSet Insert_FMV(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_FMV(objbo);
        }
        public DataSet Insert_VALUATION(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_VALUATION(objbo);
        }
        public DataSet Insert_VESTING(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_VESTING(objbo);
        }
        public DataTable getFailedDataTableWise(string Tablewise)
        {
            return objGCDAL.getFailedDataTableWise(Tablewise);
        }
        public DataSet Insert_Copy_EMP_Ex_Data(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_Copy_EMP_Ex_Data(objbo);
        }
        public DataSet Insert_Grant_Vesting(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_Grant_Vesting(objbo);
        }
        public DataSet GET_EMP_ROLL(EmployeeBO objbo)
        {
            return objGCDAL.GET_EMP_ROLL(objbo);
        }
        public DataSet Workflow(GrandCreationBO objbo)
        {
            return objGCDAL.Workflow(objbo);
        }
        public DataSet UserFilter_1(EmployeeBO objbo)
        {
            return objGCDAL.UserFilter_1(objbo);
        }
        public DataSet Admin_Trans_History(GrandCreationBO objbo)
        {
            return objGCDAL.Admin_Trans_History(objbo);
        }
        public DataSet Insert_Yrs_Lapse(GrandCreationBO objbo)
        {
            throw new NotImplementedException();
        }
        public DataSet INSERT_GVD(GrandCreationBO objbo)
        {
            return objGCDAL.INSERT_GVD(objbo);
        }
        public bool Insert_Lapse_Historic(GrandCreationBO objbo)
        {
            return objGCDAL.Insert_Lapse_Historic(objbo);
        }
        public bool Update_GVD_Lapse_Historic(GrandCreationBO objbo)
        {
            return objGCDAL.Update_GVD_Lapse_Historic(objbo); 
        }
    }
}
