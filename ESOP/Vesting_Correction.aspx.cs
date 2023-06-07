using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESOP
{

    public partial class Vesting_Correction : System.Web.UI.Page
    {
        Vesting_CorrectionBO objBO = new Vesting_CorrectionBO();
        Vesting_CorrectionBAL objBAL = new Vesting_CorrectionBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();

        GrandCreationBO objbo1 = new GrandCreationBO();
        GrandCreationBAL objbal1 = new GrandCreationBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get_vesting_correction_records();
            }
        }

        private void Get_vesting_correction_records()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objBAL.Get_vesting_correction_records();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdvestingcorrection.DataSource = ds.Tables[0];
                    grdvestingcorrection.DataBind();

                    //   Session["Getgrantcorrection"] = ds.Tables[0];

                    grdvestingcorrection.UseAccessibleHeader = true;
                    grdvestingcorrection.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    grdvestingcorrection.DataSource = ds.Tables[0];
                    grdvestingcorrection.DataBind();
                    //  Session["Getgrantcorrection"] = null;

                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvestingcorrection_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.Get_vesting_correction_records();
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdvestingcorrection.UseAccessibleHeader = true;
                grdvestingcorrection.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdvestingcorrection_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdvestingcorrection.EditIndex = e.NewEditIndex;
                Get_vesting_correction_records();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvestingcorrection_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string status1 = "";
                // DataTable ds1 = (DataTable)Session["Getgrantcorrection"];
                DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                GridViewRow row = grdvestingcorrection.Rows[e.RowIndex];
                objBO.GRANT_ID = Convert.ToInt32(grdvestingcorrection.DataKeys[e.RowIndex].Values[0]);
                objBO.NO_OF_OPTION = Convert.ToInt32((row.FindControl("txtoption") as TextBox).Text);
                ///objBO.Emp_code = Convert.ToString(grdgrntcorrection.DataKeys[e.RowIndex].Values[1]);
                //objBO.Emp_name = ((row.FindControl("txtename") as TextBox).Text);
               // objBO.VID = Convert.ToInt32((row.FindControl("ddlVesting") as DropDownList).SelectedValue);

                //objBO.FMV_PRICE = Convert.ToInt32((row.FindControl("txtprice") as TextBox).Text);
                objBO.UPDATED_BY = Convert.ToString(Session["ECode"]);
                status1 = "Updated";
                bool val = objBAL.UpdateVestingcorrection(objBO);

                if (val == true)
                {

                    OEMailBO.userName = grdvestingcorrection.DataKeys[row.RowIndex].Values[1].ToString();
                    //Mail Functionaity--------------------------------------
                    DataSet ds1 = OEMailBAL.GetEMPDetails(OEMailBO);
                    string userName = Convert.ToString(ds1.Tables[0].Rows[0]["USERNAME"]);
                    string emailid = Convert.ToString(ds1.Tables[0].Rows[0]["EMAILID"]);
                    string Attachment = Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                    // 
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        // SendMail(status1, userName, emailid, Attachment);
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record updated successfully and send to admin');", true);




                }
                grdvestingcorrection.EditIndex = -1;
                this.Get_vesting_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }

        }


        public void SendMail(string status, string Hrname, string ToEmailID, string Attachment)
        {
            try
            {

                EMailBO eMailBO = new EMailBO();
                EMailBAL eMailBAL = new EMailBAL();
                eMailBO.userName = Hrname;
                eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantUpdation.html");
                eMailBO.EmailID = ToEmailID;//multple mail id
                eMailBO.subject = "ESOP-Vesting Updated status by admin.";
                eMailBO.Status1 = status;

                eMailBO.Attachment = Attachment;
                if (ConfigurationManager.AppSettings["SendMail"].ToUpper() == "YES")
                {
                    string Data = eMailBAL.SendHtmlFormattedEmail(eMailBO);//SUB                               
                    if (!string.IsNullOrEmpty(Data))
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Sucess";
                        eMailBO.CreatedBy = Convert.ToString(Session["ECode"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                    else
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Failed";
                        eMailBO.CreatedBy = Convert.ToString(Session["ECode"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
        }

        protected void grdvestingcorrection_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdvestingcorrection.EditIndex = -1;
                Get_vesting_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvestingcorrection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objBO.GRANT_ID = Convert.ToInt32(grdvestingcorrection.DataKeys[e.RowIndex].Values[0]);
                objBAL.DeleteVestingcorrection(objBO);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record deleted successfully.');", true);

                Get_vesting_correction_records();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdvestingcorrection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grdvestingcorrection.EditIndex == e.Row.RowIndex)
            {
                DataSet ds = objbal1.GetDropDown();
                DropDownList ddlVesting = (e.Row.FindControl("ddlVesting") as DropDownList);
                if (ds.Tables.Count > 0)
                {

                    ddlVesting.Items.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ListItem item = new ListItem();
                        item.Text = row["VNAME"].ToString();
                        item.Value = row["VID"].ToString();
                        if (row["ACTION"].ToString() == "BASE")
                        {
                            item.Attributes.Add("class", "optiongroup1");
                        }
                        else
                        {
                            item.Attributes.Add("class", "optionchild1");
                            item.Attributes.Add("disabled", "disabled");
                        }


                        ddlVesting.Items.Add(item);
                    }
                    //ddlVesting.Items.Insert(0, new ListItem("Select Vesting", "0"));

                }
                string VNAME = DataBinder.Eval(e.Row.DataItem, "VNAME").ToString();
                ddlVesting.Items.FindByText(VNAME).Selected = true;
                //else
                //{

                //}
                //----------------------------------------------------------
                //DropDownList ddlVesting = (e.Row.FindControl("ddlVesting") as DropDownList);
                //DataTable dt = objbal.getvaluedbyddl(objbo);

                //DropDownList1.DataSource = dt;

                //DropDownList1.DataTextField = "Valued_By";
                //DropDownList1.DataValueField = "AGENCY_ID";
                //DropDownList1.DataBind();

                //string Valued_By = DataBinder.Eval(e.Row.DataItem, "Valued_By").ToString();
                //DropDownList1.Items.FindByText(Valued_By).Selected = true;

            }

        }
    }
}