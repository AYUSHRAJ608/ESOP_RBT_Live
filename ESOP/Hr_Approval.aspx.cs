
using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using it = iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace ESOP
{
    public partial class Hr_Approval : System.Web.UI.Page
    {
        HrapprovalBO objbo = new HrapprovalBO();
        HrapprovalBAL objbal = new HrapprovalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        Grant_CorrectionBO objBO = new Grant_CorrectionBO();
        Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                bind_approval_data_hr();
                bind_hr_all_count();
                // btn_bulkApprove.Visible = true;
                // btn_bulkReject.Visible = true;

            }

        }

        private void bind_hr_all_count()
        {
            DataSet ds = objbal.get_hr_all_count(objbo);
            if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
            {
                //lbltotal_grant.Text = ds.Tables[0].Rows[0][0].ToString();
                lbltotal_grant.Text = (Convert.ToInt32(ds.Tables[2].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables[3].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString())).ToString();
                lbl_approved.Text = ds.Tables[2].Rows[0][0].ToString();
                lbl_rejected.Text = ds.Tables[3].Rows[0][0].ToString();
                lbl_approval_pending.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            else
            {
                lbltotal_grant.Text = "0";
                lbl_approved.Text = "0";
                lbl_rejected.Text = "0";
                lbl_approval_pending.Text = "0";

            }
        }

        private void bind_approval_data_hr()
        {
            try

            {
                DataSet ds = objbal.get_hr_appraval_date(objbo);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    //grdpendingapproval.DataSource = ds.Tables[0];
                    //grdpendingapproval.DataBind();
                    //Session["dirStateP"] = ds.Tables[0];
                    //Session["sortdrP"] = "Asc";
                    //grdapproval.DataSource = ds.Tables[1];
                    //grdapproval.DataBind();
                    //Session["dirState"] = ds.Tables[1];
                    //Session["sortdr"] = "Asc";
                    //grdreject.DataSource = ds.Tables[2];
                    //grdreject.DataBind();
                    //Session["dirStateR"] = ds.Tables[2];
                    //Session["sortdrR"] = "Asc";




                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdpendingapproval.DataSource = ds.Tables[0];
                        grdpendingapproval.DataBind();

                        //  ViewState["PendingforApprovalRecords"] = ds.Tables[0];

                        // grdpendingapproval.UseAccessibleHeader = true;
                        // grdpendingapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        grdpendingapproval.DataSource = ds.Tables[0];
                        grdpendingapproval.DataBind();
                        btn_bulkApprove.Visible = false;
                        btn_bulkReject.Visible = false;

                        //  ViewState["PendingforApprovalRecords"] = ds.Tables[0];

                        //  grdpendingapproval.UseAccessibleHeader = false;
                        //grdpendingapproval.HeaderRow.TableSection = TableRowSection.TableHeader;

                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        grdapproval.DataSource = ds.Tables[1];
                        grdapproval.DataBind();
                        // ViewState["ApprovedRecords"] = ds.Tables[1];


                        //grdapproval.UseAccessibleHeader = true;
                        //  grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        grdapproval.DataSource = ds.Tables[1];
                        grdapproval.DataBind();
                        // btn_bulkApprove.Visible = false;
                        // btn_bulkReject.Visible = false;
                        // ViewState["ApprovedRecords"] = ds.Tables[1];


                        // grdapproval.UseAccessibleHeader = false;
                        // grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        grdreject.DataSource = ds.Tables[2];
                        grdreject.DataBind();
                        // ViewState["RejectRecords"] = ds.Tables[2];

                        // grdreject.UseAccessibleHeader = true;
                        // grdreject.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        grdreject.DataSource = ds.Tables[2];
                        grdreject.DataBind();
                        //  btn_bulkApprove.Visible = false;
                        //  btn_bulkReject.Visible = false;
                        // ViewState["RejectRecords"] = ds.Tables[2];


                    }
                }
                else
                {
                    grdpendingapproval.DataSource = null;
                    grdpendingapproval.DataBind();
                    ViewState["PendingforApprovalRecords"] = null;


                    grdapproval.DataSource = null;
                    grdapproval.DataBind();
                    ViewState["ApprovedRecords"] = null;

                    grdreject.DataSource = null;
                    grdreject.DataBind();
                    ViewState["RejectRecords"] = null;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        //protected void btn_Approve_Click(object sender, EventArgs e)
        //{

        //    try
        //    {

        //        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
                
        //        string status1 = "";
        //        objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[rowIndex].Values[0]);
        //        objbo.ecode = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
        //        objbo.emp_name = grdpendingapproval.Rows[rowIndex].Cells[2].Text;
        //        objbo.appraiser_name = grdpendingapproval.Rows[rowIndex].Cells[3].Text;
        //        objbo.date_of_grant = grdpendingapproval.Rows[rowIndex].Cells[4].Text;
        //        objbo.no_of_options = grdpendingapproval.Rows[rowIndex].Cells[5].Text;
        //        objbo.fmv_price = grdpendingapproval.Rows[rowIndex].Cells[6].Text;
        //        objbo.UPDETED_BY = Convert.ToString(Session["ECode"]);
        //        TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("txtremark");

        //        objbo.remark = txt.Text.ToString();
        //        objbo.status = "APPROVED_BY_HR";
        //        objbo.proxy = Convert.ToString(Session["Proxy"]);

        //        status1 = "Approved";
        //        bool val = objbal.update_status(objbo);

        //        if (val == true)
        //        {
        //            //Mail Functionaity--------------------------------------
        //            OEMailBO.RoleName = "HR";
        //            OEMailBO.userName = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
        //            string Attachment = "";// Server.MapPath(@"/Fmv_excel/Employee.xlsx");
        //            DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
        //            //    if (ds.Tables[0].Rows.Count > 0)
        //            //    {
        //            //        //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
        //            //        // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
        //            //        //SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Approved by HR", grdpendingapproval.DataKeys[rowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[rowIndex].Values[0].ToString(), grdpendingapproval.DataKeys[rowIndex].Values[3].ToString(), "", "", "");
        //            //        //SendMail_1(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
        //            //    }

        //        }
                
        //        bind_approval_data_hr();
        //        bind_hr_all_count();
        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record approved successfully!!');", true);
        //        //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);

        //        //}
        //        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
        //        showmsg.InnerText = "Grant has been approved.";
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        //throw ex;

        //    }
        //}

        public void SendMail_2(string status, string Empname, string ToEmailID, string Attachment)
        {
            try
            {

                EMailBO eMailBO = new EMailBO();
                EMailBAL eMailBAL = new EMailBAL();
                if (status == "Approved")
                {
                    eMailBO.userName = Empname;
                    eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/HRApproval.html");
                    eMailBO.EmailID = ToEmailID;//multple mail id
                    eMailBO.subject = "ESOP-Grant approved by HR.";
                    eMailBO.Status1 = status;
                }
                else
                {
                    eMailBO.userName = Empname;
                    eMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/HRReject.html");
                    eMailBO.EmailID = ToEmailID;//multple mail id
                    eMailBO.subject = "ESOP-Grant rejected by HR.";
                    eMailBO.Status1 = status;

                }
                eMailBO.Attachment = ""; //Attachment;
                if (ConfigurationManager.AppSettings["SendMail"].ToUpper() == "YES")
                {
                    string Data = eMailBAL.SendHtmlFormattedEmail(eMailBO);//SUB                               
                    if (!string.IsNullOrEmpty(Data))
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Sucess";
                        eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                    else
                    {
                        eMailBO.body = Data;
                        eMailBO.Status = "Failed";
                        eMailBO.CreatedBy = Convert.ToString(Session["LoginID"]);
                        bool retVal11 = eMailBAL.InsertEmailDetails(eMailBO);//SUB  
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }

        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

                //  CheckBox check = (CheckBox)grdpendingapproval.Rows[rowIndex].FindControl("chk");

                //if (check.Checked)
                //{
                string status1 = "";
                objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[rowIndex].Values[0]);
                objbo.ecode = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
                objbo.emp_name = grdpendingapproval.Rows[rowIndex].Cells[2].Text;
                objbo.appraiser_name = grdpendingapproval.Rows[rowIndex].Cells[3].Text;
                objbo.date_of_grant = grdpendingapproval.Rows[rowIndex].Cells[4].Text;
                objbo.no_of_options = grdpendingapproval.Rows[rowIndex].Cells[5].Text;
                objbo.fmv_price = grdpendingapproval.Rows[rowIndex].Cells[6].Text;
                objbo.UPDETED_BY = Convert.ToString(Session["ECode"]);
                TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("txtremark");

                objbo.remark = txt.Text.ToString();

                objbo.proxy = Convert.ToString(Session["Proxy"]);
                objbo.status = "REJECTED_BY_HR";
                status1 = "Rejected";


                bool val = objbal.update_status(objbo);
                // bind_approval_data_hr();
                // bind_hr_all_count();
                if (val == true)
                {
                    OEMailBO.RoleName = "Admin";
                    OEMailBO.userName = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
                    string Attachment = "";
                    DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                        // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Rejected by HR");
                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Rejected by HR", grdpendingapproval.DataKeys[rowIndex].Values[2].ToString(), "", "", grdpendingapproval.DataKeys[rowIndex].Values[3].ToString(), "", "", "");
                    }
                    // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage1();", true);

                    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record rejected successfully!!');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Grant has been rejected, sent to Admin for the correction.";
                    bind_approval_data_hr();
                    bind_hr_all_count();
                }


                // }


            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;

            }
        }

        //protected void btn_bulkApprove_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        foreach (GridViewRow gvrow in grdpendingapproval.Rows)
        //        {

        //            if (gvrow.RowType == DataControlRowType.DataRow)
        //            {

        //                var checkbox = gvrow.FindControl("chk") as CheckBox;
        //                //  bool isChecked = gvrow.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

        //                if (checkbox.Checked)
        //                {
        //                    string status1 = "";
        //                    objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[gvrow.RowIndex].Value);
        //                    objbo.ecode = gvrow.Cells[1].Text;
        //                    objbo.emp_name = gvrow.Cells[2].Text;
        //                    objbo.appraiser_name = gvrow.Cells[3].Text;
        //                    objbo.date_of_grant = gvrow.Cells[4].Text;
        //                    objbo.no_of_options = gvrow.Cells[5].Text;
        //                    objbo.fmv_price = gvrow.Cells[6].Text;
        //                    objbo.UPDETED_BY = Convert.ToString(Session["ECode"]);
        //                    objbo.proxy = Convert.ToString(Session["Proxy"]);
        //                    objbo.status = "APPROVED_BY_HR";
        //                    status1 = "Approved";
        //                    TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("txtremark");

        //                    objbo.remark = txt.Text.ToString();

        //                    bool val = objbal.update_status(objbo);
        //                    //// bind_approval_data_hr();
        //                    //// bind_hr_all_count();
        //                    //if (val == true)
        //                    //{
        //                    //    OEMailBO.RoleName = "President";
        //                    //    OEMailBO.userName = gvrow.Cells[1].Text;
        //                    //    string Attachment = "";
        //                    //    DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
        //                    //    if (ds.Tables[0].Rows.Count > 0)
        //                    //    {
        //                    //        //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
        //                    //        // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
        //                    //        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Approved by HR", grdpendingapproval.DataKeys[gvrow.RowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[gvrow.RowIndex].Value.ToString(), grdpendingapproval.DataKeys[gvrow.RowIndex].Values[3].ToString(), "", "", ""); ;
        //                    //    }

        //                    //}

        //                }
        //            }

        //        }
        //        bind_approval_data_hr();
        //        bind_hr_all_count();
        //        //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);

        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records approved successfully!!');", true);
        //        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
        //        showmsg.InnerText = "Grant has been approved.";
        //    }
        //    catch (Exception ex)

        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        //throw ex;

        //    }

        //}
        //protected void btn_bulkApprove_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        foreach (GridViewRow gvrow in grdpendingapproval.Rows)
        //        {

        //            if (gvrow.RowType == DataControlRowType.DataRow)
        //            {

        //                var checkbox = gvrow.FindControl("chk") as CheckBox;
        //                //  bool isChecked = gvrow.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

        //                if (checkbox.Checked)
        //                {
        //                    string status1 = "";
        //                    objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[gvrow.RowIndex].Value);
        //                    objbo.ecode = gvrow.Cells[1].Text;
        //                    objbo.emp_name = gvrow.Cells[2].Text;
        //                    objbo.appraiser_name = gvrow.Cells[3].Text;
        //                    objbo.date_of_grant = gvrow.Cells[4].Text;
        //                    objbo.no_of_options = gvrow.Cells[5].Text;
        //                    objbo.fmv_price = gvrow.Cells[6].Text;
        //                    objbo.UPDETED_BY = Convert.ToString(Session["ECode"]);
        //                    objbo.proxy = Convert.ToString(Session["Proxy"]);
        //                    objbo.status = "APPROVED_BY_HR";
        //                    status1 = "Approved";
        //                    TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("txtremark");

        //                    objbo.remark = txt.Text.ToString();

        //                    bool val = objbal.update_status(objbo);
        //                    //// bind_approval_data_hr();
        //                    //// bind_hr_all_count();
        //                    //if (val == true)
        //                    //{
        //                    //    OEMailBO.RoleName = "President";
        //                    //    OEMailBO.userName = gvrow.Cells[1].Text;
        //                    //    string Attachment = "";
        //                    //    DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
        //                    //    if (ds.Tables[0].Rows.Count > 0)
        //                    //    {
        //                    //        //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
        //                    //        // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
        //                    //        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Approved by HR", grdpendingapproval.DataKeys[gvrow.RowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[gvrow.RowIndex].Value.ToString(), grdpendingapproval.DataKeys[gvrow.RowIndex].Values[3].ToString(), "", "", ""); ;
        //                    //    }

        //                    //}

        //                }
        //            }

        //        }
        //        bind_approval_data_hr();
        //        bind_hr_all_count();
        //        //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);

        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records approved successfully!!');", true);
        //        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
        //        showmsg.InnerText = "Grant has been approved in bulk.";
        //    }
        //    catch (Exception ex)

        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

        //        //throw ex;

        //    }

        //}

        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (GridViewRow gvrow in grdpendingapproval.Rows)
                {

                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {

                        var checkbox = gvrow.FindControl("chk") as CheckBox;
                        //  bool isChecked = gvrow.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

                        if (checkbox.Checked)
                        {
                            string status1 = "";
                            objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[gvrow.RowIndex].Value);
                            objbo.ecode = gvrow.Cells[1].Text;
                            objbo.emp_name = gvrow.Cells[2].Text;
                            objbo.appraiser_name = gvrow.Cells[3].Text;
                            objbo.date_of_grant = gvrow.Cells[4].Text;
                            objbo.no_of_options = gvrow.Cells[5].Text;
                            objbo.fmv_price = gvrow.Cells[6].Text;
                            objbo.UPDETED_BY = Convert.ToString(Session["ECode"]);
                            objbo.proxy = Convert.ToString(Session["Proxy"]);
                            objbo.status = "APPROVED_BY_HR";
                            status1 = "Approved";
                            TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("txtremark");

                            objbo.remark = txt.Text.ToString();

                            bool val = objbal.update_status(objbo);
                            // bind_approval_data_hr();
                            // bind_hr_all_count();
                            if (val == true)
                            {
                                OEMailBO.RoleName = "President";
                                OEMailBO.userName = gvrow.Cells[1].Text;
                                string Attachment = "";
                                DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                    // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
                                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Approved by HR", grdpendingapproval.DataKeys[gvrow.RowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[gvrow.RowIndex].Value.ToString(), grdpendingapproval.DataKeys[gvrow.RowIndex].Values[3].ToString(), "", "", ""); ;
                                }

                            }

                        }
                    }

                }
                bind_approval_data_hr();
                bind_hr_all_count();
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records approved successfully!!');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been approved in bulk & sent to Secretarial team for approval.";
            }
            catch (Exception ex)

            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;

            }

        }
        protected void btn_Approve_Click(object sender, EventArgs e)
        {

            try
            {

                int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

                // CheckBox check = (CheckBox)grdpendingapproval.Rows[rowIndex].FindControl("chk");

                //if (check.Checked)
                //{
                string status1 = "";
                objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[rowIndex].Values[0]);
                objbo.ecode = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
                objbo.emp_name = grdpendingapproval.Rows[rowIndex].Cells[2].Text;
                objbo.appraiser_name = grdpendingapproval.Rows[rowIndex].Cells[3].Text;
                objbo.date_of_grant = grdpendingapproval.Rows[rowIndex].Cells[4].Text;
                objbo.no_of_options = grdpendingapproval.Rows[rowIndex].Cells[5].Text;
                objbo.fmv_price = grdpendingapproval.Rows[rowIndex].Cells[6].Text;
                objbo.UPDETED_BY = Convert.ToString(Session["ECode"]);
                TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("txtremark");

                objbo.remark = txt.Text.ToString();
                objbo.status = "APPROVED_BY_HR";
                objbo.proxy = Convert.ToString(Session["Proxy"]);

                status1 = "Approved";
                bool val = objbal.update_status(objbo);

                if (val == true)
                {
                    //Mail Functionaity--------------------------------------
                    OEMailBO.RoleName = "President";
                    OEMailBO.userName = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
                    string Attachment = "";// Server.MapPath(@"/Fmv_excel/Employee.xlsx");
                    DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                        // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Approved by HR", grdpendingapproval.DataKeys[rowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[rowIndex].Values[0].ToString(), grdpendingapproval.DataKeys[rowIndex].Values[3].ToString(), "", "", "");

                    }



                }
                bind_approval_data_hr();
                bind_hr_all_count();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record approved successfully!!');", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);

                //}
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been approved & sent to Secretarial team for approval.";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;

            }
        }

        protected void btn_bulkReject_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (GridViewRow gvrow in grdpendingapproval.Rows)
                {

                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {

                        var checkbox = gvrow.FindControl("chk") as CheckBox;
                        //  bool isChecked = gvrow.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

                        if (checkbox.Checked)
                        {

                            string status1 = "";
                            objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[gvrow.RowIndex].Value);
                            objbo.ecode = gvrow.Cells[1].Text;
                            objbo.emp_name = gvrow.Cells[2].Text;
                            objbo.appraiser_name = gvrow.Cells[3].Text;
                            objbo.date_of_grant = gvrow.Cells[4].Text;
                            objbo.no_of_options = gvrow.Cells[5].Text;
                            objbo.fmv_price = gvrow.Cells[6].Text;
                            objbo.UPDETED_BY = Convert.ToString(Session["ECode"]);
                            objbo.proxy = Convert.ToString(Session["Proxy"]);
                            objbo.status = "REJECTED_BY_HR";
                            status1 = "Rejected";
                            TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("txtremark");

                            objbo.remark = txt.Text.ToString();

                            bool val = objbal.update_rejected_status(objbo);
                            //  bind_approval_data_hr();
                            //  bind_hr_all_count();
                            if (val == true)
                            {
                                OEMailBO.RoleName = "Admin";
                                OEMailBO.userName = gvrow.Cells[1].Text;
                                string Attachment = "";
                                DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
                                    //SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Rejected by HR");
                                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Rejected by HR", grdpendingapproval.DataKeys[gvrow.RowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[gvrow.RowIndex].Value.ToString(), grdpendingapproval.DataKeys[gvrow.RowIndex].Values[3].ToString(), "", "", "");
                                }

                            }

                        }
                    }

                }
                bind_approval_data_hr();
                bind_hr_all_count();
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage1();", true);

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records rejected successfully!!');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been rejected, sent to Admin for the correction.";

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;

            }
        }

        protected void grdpendingapproval_PreRender(object sender, EventArgs e)

        {
            DataSet ds = objbal.get_hr_appraval_date(objbo);
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdpendingapproval.UseAccessibleHeader = true;
                grdpendingapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdpendingapproval.DataSource = ds.Tables[0];
                grdpendingapproval.DataBind();


                //grdpendingapproval.UseAccessibleHeader = true;
                //grdpendingapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdapproval_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.get_hr_appraval_date(objbo);
            if (ds.Tables[1].Rows.Count > 0)
            {

                grdapproval.UseAccessibleHeader = true;
                grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdreject_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.get_hr_appraval_date(objbo);
            if (ds.Tables[2].Rows.Count > 0)
            {

                grdreject.UseAccessibleHeader = true;
                grdreject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            //else
            //{
            //    grdreject.DataSource = ds.Tables[2];
            //    grdreject.DataBind();


            //    grdreject.UseAccessibleHeader = true;
            //    grdreject.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}

        }

        //protected void grdapproval_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable dtrslt = (DataTable)Session["dirState"];
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        if (Convert.ToString(Session["sortdr"]) == "Asc")
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //            Session["sortdr"] = "Desc";
        //        }
        //        else
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
        //            Session["sortdr"] = "Asc";
        //        }
        //        grdapproval.DataSource = dtrslt;
        //        grdapproval.DataBind();


        //    }
        //}

        //protected void grdreject_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable dtrslt = (DataTable)Session["dirStateR"];
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        if (Convert.ToString(Session["sortdrR"]) == "Asc")
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //            Session["sortdrR"] = "Desc";
        //        }
        //        else
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
        //            Session["sortdrR"] = "Asc";
        //        }
        //        grdreject.DataSource = dtrslt;
        //        grdreject.DataBind();


        //    }
        //}

        //protected void grdpendingapproval_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable dtrslt = (DataTable)Session["dirStateP"];
        //    if (dtrslt.Rows.Count > 0)
        //    {
        //        if (Convert.ToString(Session["sortdrP"]) == "Asc")
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //            Session["sortdrP"] = "Desc";
        //        }
        //        else
        //        {
        //            dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
        //            Session["sortdrP"] = "Asc";
        //        }
        //        grdpendingapproval.DataSource = dtrslt;
        //        grdpendingapproval.DataBind();


        //    }
        //}

        //protected void grdpendingapproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        grdpendingapproval.PageIndex = e.NewPageIndex;
        //        this.bind_approval_data_hr();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void grdapproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        grdapproval.PageIndex = e.NewPageIndex;
        //        this.bind_approval_data_hr();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void grdreject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        grdreject.PageIndex = e.NewPageIndex;
        //        this.bind_approval_data_hr();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void SendMail_1(string username, string type, string subtype, string Attachment, string Email, string GrantName, string GrantPrice)
        {
            string Mail_Functional = System.Configuration.ConfigurationManager.AppSettings["SendMail_Functionality"];
            if (Mail_Functional == "ON")
            {
                cEmailEntityRequest emailreq = new cEmailEntityRequest();
                EMailBO eMailBO = new EMailBO();
                eMailBO.Attachment = Attachment;

                string UserMailID = System.Configuration.ConfigurationManager.AppSettings["UserName"];
                string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
                string Mail_To = System.Configuration.ConfigurationManager.AppSettings["Mail_To"];

                OEMailBO.Em_Action = "SendEmail";
                OEMailBO.Em_Type = type;
                OEMailBO.Em_Sub_Type = subtype;
                emailreq.EmailEntity = OEMailBO;
                DataSet ds = OEMailBAL.insertEmail(emailreq);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
                        String SessionCheck = Convert.ToString(Session["UserName"]);
                        String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
                        //body = body.Replace("{{User}}", SessionCheck);
                        body = body.Replace("@To", username);
                        body = body.Replace("@From", Convert.ToString(Session["UserName"]));
                        body = body.Replace("@GrantName", GrantName);
                        body = body.Replace("@FMVPrice", GrantPrice);

                        string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
                        ccMailID = ccMailID.Replace(";", ",");
                        string[] CCMailId = ccMailID.Split(',');
                        string frommailId = UserMailID;// ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
                        string ToMailId = Mail_To;// "Prashant.shinde@cloverinfotech.com";

                        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                        SmtpClient smtp = new SmtpClient();
                        message.From = new MailAddress(frommailId);
                        message.To.Add(new MailAddress(ToMailId));
                        foreach (string CCEmail in CCMailId)
                        {
                            if (CCEmail != "")
                            {
                                message.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                            }
                        }
                        message.Subject = mailSubject;
                        message.IsBodyHtml = true;
                        message.Body = body;
                        if (!string.IsNullOrEmpty(eMailBO.Attachment))
                        {
                            Attachment atdoc = new Attachment(eMailBO.Attachment);
                            message.Attachments.Add(atdoc);
                        }

                        smtp.Port = 25;
                        smtp.Host = "email.cloverinfotech.com";
                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(UserMailID, UserPassword);

                        //Comeented Temporary

                        smtp.Send(message);
                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                    //throw ex;
                }
            }
            //added from PresidentsGrantApproval reference on 21/03/2022 by Pallavi
            //try
            //{
            //    EMailBO OEMailBO = new EMailBO();
            //    EMailBAL OEMailBAL = new EMailBAL();
            //    OEMailBO.userName = username;
            //    OEMailBO.Attachment = Attachment;
            //    if (status == "Approved")
            //    {
            //        OEMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantApproval.html");
            //    }
            //    else
            //    {
            //        OEMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantReject.html");
            //    }

            //    OEMailBO.EmailID = ToEmailID;//multple mail id
            //    OEMailBO.subject = "ESOP-Grant " + status + " status by President.";
            //    OEMailBO.Status1 = status;

            //    OEMailBO.Attachment = Attachment;
            //    if (ConfigurationManager.AppSettings["SendMail"].ToUpper() == "YES")
            //    {
            //        string Data = OEMailBAL.SendHtmlFormattedEmail(OEMailBO);//SUB                               
            //        if (!string.IsNullOrEmpty(Data))
            //        {
            //            OEMailBO.body = Data;
            //            OEMailBO.Status = "Sucess";
            //            OEMailBO.CreatedBy = Session["Ecode"].ToString();
            //            bool retVal11 = OEMailBAL.InsertEmailDetails(OEMailBO);//SUB  
            //        }
            //        else
            //        {
            //            OEMailBO.body = Data;
            //            OEMailBO.Status = "Failed";
            //            OEMailBO.CreatedBy = Session["Ecode"].ToString();
            //            bool retVal11 = OEMailBAL.InsertEmailDetails(OEMailBO);//SUB  
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            //    //throw ex;
            //}
            //cEmailEntityRequest emailreq = new cEmailEntityRequest();
            //if (status == "Approved")
            //{
            //    OEMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantApproval.html");
            //}
            //else
            //{
            //    OEMailBO.EmailTemPath = Server.MapPath("~/EmailTemplate/GrantReject.html");
            //}

            //OEMailBO.Em_Action = "SendEmail";
            //OEMailBO.Em_Type = "Grant";
            //OEMailBO.Em_Sub_Type = type;
            //emailreq.EmailEntity = OEMailBO;
            //DataSet ds = OEMailBAL.insertEmail(emailreq);

            //String mailSubject = ds.Tables[0].Rows[0]["Em_Sub"].ToString();
            //String SessionCheck = Convert.ToString(Session["UserName"]);
            //String body = ds.Tables[0].Rows[0]["Em_body"].ToString();
            ////body = body.Replace("{{User}}", SessionCheck);
            //body = body.Replace("{{To}}", username);
            //body = body.Replace("{{UserName}}", Convert.ToString(Session["UserName"]));

            //string ccMailID = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
            //ccMailID = ccMailID.Replace(";", ",");
            //string frommailId = ds.Tables[0].Rows[0]["EM_From_ID"].ToString();
            //string ToMailId = "Prashant.shinde@cloverinfotech.com";

            //MailMessage message = new MailMessage();
            //SmtpClient smtp = new SmtpClient();
            //message.From = new MailAddress(frommailId);
            //message.To.Add(new MailAddress(ToMailId));
            ////message.CC.Add(ccMailID);
            //message.Subject = mailSubject;
            //message.IsBodyHtml = true;
            //message.Body = body;

            //smtp.Port = 25;
            //smtp.Host = "email.cloverinfotech.com";
            //smtp.EnableSsl = false;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential("Prashant.shinde@cloverinfotech.com", "Shinde1234#");

            ////Comeented Temporary
            //try
            //{
            //    smtp.Send(message);
            //}
            //catch (Exception ex)
            //{
            //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

            //    //throw ex;
            //}


        }

        protected void grdpendingapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdpendingapproval.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdpendingapproval.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData.DataSource = ds.Tables[0];
                    grdData.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }
            if (e.CommandName == "download")
            {
                try
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string hd = (gvr.FindControl("HiddenField1") as HiddenField).Value;
                    string LtrFile = hd.ToString();

                    string filePath = Server.MapPath(LtrFile);
                    if (File.Exists(filePath))
                    {
                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                        Response.WriteFile(filePath);
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                        return;
                    }
                }
                catch (Exception)
                {
                }

            }
        }

        protected void grdapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdapproval.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdapproval.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData.DataSource = ds.Tables[0];
                    grdData.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }
        }

        protected void grdreject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdreject.Rows[index];
                objBO.GRANT_ID = Convert.ToInt32(grdreject.DataKeys[index].Values[0]);
                DataSet ds = objBAL.GET_GRANT_CORRECTION_AUDIT(objBO);
                ViewState["GrvPendingforApproval_app_rej"] = null;

                ViewState["GrvPendingforApproval_app_rej"] = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData.DataSource = ds.Tables[0];
                    grdData.DataBind();
                    //ViewState["dtAuditExport"] = ds.Tables[0];
                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }
        }
        protected void imgExportAudit_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.GetCurrent(this).RegisterPostBackControl(imgExportAudit);
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "HR_REPORT" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //grdData.GridLines = GridLines.Both;
            //grdData.HeaderStyle.Font.Bold = true;
            //DataTable dt = new DataTable("GridView_Data");

            //var gv = new GridView();

            //dt = (DataTable)ViewState["dtAuditExport"];
            //gv.DataSource = dt;
            //gv.DataBind();
            grdData.RenderControl(htmltextwrtter);
            Response.Output.Write(strwritter.ToString());
            Response.End();
        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Emp_filterRec"];
            if (ds.Tables.Count > 0)
            {
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
            }
        }
        protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_Code = (Label)e.Row.FindControl("lbl_Status");
                if (lbl_Code.Text.Contains("APP"))
                {
                    e.Row.BackColor = System.Drawing.Color.LightPink;
                }
                else if (lbl_Code.Text.Contains("REJ"))
                {
                    e.Row.BackColor = System.Drawing.Color.BurlyWood;
                }
            }
        }
        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";

            string filename = "HR_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdData.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            it.Document pdfDoc = new it.Document(it.PageSize.A2, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            grdData.AllowPaging = true;
            grdData.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void grdData_PreRender(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)ViewState["GrvPendingforApproval_app_rej"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    grdData.UseAccessibleHeader = true;
                    grdData.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        protected void lb_download_Click(object sender, EventArgs e)
        {
            string filename = (sender as LinkButton).CommandArgument;
            string filePath = Server.MapPath(filename);
            if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
            {
                ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                ViewState["filepath"] = filename.Replace("~/", "");
            }
            else
            {
                Common.ShowJavascriptAlert("File is not uploded");
            }
        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                //var  filePath = Request.Form["__EVENTARGUMENT"];
                string filePath = ViewState["filepath"].ToString();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                if (row != null)
                {
                    int rowindex = row.RowIndex;
                    HiddenField Hdf = grdpendingapproval.Rows[rowindex].FindControl("HiddenField1") as HiddenField;

                    if (Path.GetExtension(Hdf.Value.ToString()).ToString() == ".pdf")
                    {
                        string Path = Hdf.Value.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2('" + Path + "');", true);
                    }

                }
                else
                {
                    Common.ShowJavascriptAlert("File is not uploded");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}