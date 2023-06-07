using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BO;
using ESOP_BAL;

namespace ESOP
{
    public partial class Admin_Exercise_Window : System.Web.UI.Page
    {
        GrandCreationBAL objbal = new GrandCreationBAL();
        employee_exerciseBAL objBAL = new employee_exerciseBAL();
        Exercise_CancelBAL objBal = new Exercise_CancelBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataSet ds = objbal.ESOP_GET_EXCISE_sell_GRIDDATA();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ExerciseWindowcount.InnerText = Convert.ToString(ds.Tables[0].Rows.Count);
                    }
                    else
                    {
                        ExerciseWindowcount.InnerText = "0";
                    }

                    DataSet ds1 = objBAL.GET_Employee_Admin_Main_Grid_1();

                    if(ds1.Tables[1].Rows.Count > 0)
                    {
                        DetailsApprovecount.InnerText = Convert.ToString(ds1.Tables[1].Rows.Count);
                    }
                    else
                    {
                        DetailsApprovecount.InnerText = "0";
                    }

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ExerciseApprovecount.InnerText = Convert.ToString(ds1.Tables[0].Rows.Count);
                    }
                    else
                    {
                        ExerciseApprovecount.InnerText = "0";
                    }

                    DataSet ds3 = objBal.GET_Employee_Exercise_Cancel();
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        RevertCount.InnerText = Convert.ToString(ds3.Tables[0].Rows.Count);
                    }
                    else
                    {
                        RevertCount.InnerText = "0";
                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                }
            }
        }
    }
}