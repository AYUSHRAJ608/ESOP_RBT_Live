using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{
    public partial class Admin_Exercise_Cancel : System.Web.UI.Page
    {
        Exercise_CancelBAL objBal = new Exercise_CancelBAL();
        Exercise_CancelBO objBO = new Exercise_CancelBO();
        Exercise_BtnRevertBO obj1BO = new Exercise_BtnRevertBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GrvApprovedBind();
            }
            BindMainGrid();
        }

        protected void GrvApprovedBind()
        {
            DataSet de = new DataSet();
            DataSet ds = objBal.GET_Employee_Exercise_Reverted();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrvApproved.DataSource = ds.Tables[0];
                GrvApproved.DataBind();
            }
            else
            {
                GrvApproved.DataSource = ds.Tables[0];
                GrvApproved.DataBind();

            }
        }
        protected void BindMainGrid()
        {
            try
            {
                DataSet de = new DataSet();
                DataSet ds = objBal.GET_Employee_Exercise_Cancel();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();

                }
                else
                {
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

       

        protected void btnRevert_Click(object sender, EventArgs e)
        {
            bool value = false;
            try
            {
                foreach (GridViewRow gvRow in GrvPendingforApproval.Rows)
                {
                    var checkbox = gvRow.FindControl("chk") as CheckBox;

                    if (checkbox.Checked)
                    {
                        obj1BO.ECODE = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[0]);
                        obj1BO.ENAME = Convert.ToString(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[1]);
                        obj1BO.Grant_Name = Convert.ToString(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[2]);
                        obj1BO.Vesting_Detail_Code = Convert.ToString(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[3]);
                        obj1BO.Exercise_Tran_Id = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[4]);
                        obj1BO.Total_Vesting = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[5]);
                        obj1BO.EXERCISE_PENDING = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[6]);
                        obj1BO.Total_Exercise_Approved = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvRow.RowIndex].Values[7]);
                       
                        TextBox txt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvRow.RowIndex)].Cells[8].FindControl("txt_remark");
                        obj1BO.Remark = txt.Text.Replace(",", "");
                        obj1BO.Status = "Reverted";
                        DateTime now = DateTime.Now;
                        obj1BO.Reverted_Date = now;

                        value = objBal.Update_Revert(obj1BO);
                    }
                    if (value == true)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Execrcise Reverted Succesfully";

                    }
                }
                     
                BindMainGrid();
                GrvApprovedBind();

            }
            catch (Exception ex)
            {

                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Error : Please contact your system Administrator";
            }
           
        }

       
    }
}