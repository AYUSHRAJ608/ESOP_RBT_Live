
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
    public partial class Secretarial_Grant_Approve_Reject : System.Web.UI.Page
    {
        Secretarial_grant_approvalBO objbo = new Secretarial_grant_approvalBO();
        Secretarial_grant_approvalBAL objbal = new Secretarial_grant_approvalBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        Grant_CorrectionBO objBO = new Grant_CorrectionBO();
        Grant_CorrectionBAL objBAL = new Grant_CorrectionBAL();
        FMVCreationBO objfmvbo = new FMVCreationBO();
        FMVCreationBAL objfmvbal = new FMVCreationBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                bind_secretarial_all_count();
                bind_secretarial_approval_data();
            }

        }

        private void bind_secretarial_all_count()
        {
            DataSet ds = objbal.get_secretarial_all_count(objbo);
            if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
            {
                //lbltotal_grant.Text = ds.Tables[0].Rows[0][0].ToString();
                lbltotal_grant.Text = (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables[2].Rows[0][0].ToString())).ToString();
                lbl_approved.Text = ds.Tables[1].Rows[0][0].ToString();
                lbl_rejected.Text = ds.Tables[2].Rows[0][0].ToString();
                lbl_approval_pending.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbltotal_grant.Text = "0";
                lbl_approved.Text = "0";
                lbl_rejected.Text = "0";
                lbl_approval_pending.Text = "0";

            }
        }

        private void bind_secretarial_approval_data()
        {
            try

            {
                DataSet ds = objbal.get_secretarial_appraval_data(objbo);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdpendingapproval.DataSource = ds.Tables[0];
                        grdpendingapproval.DataBind();
                    }
                    else
                    {
                        grdpendingapproval.DataSource = ds.Tables[0];
                        grdpendingapproval.DataBind();
                        btn_bulkApprove.Visible = false;
                        btn_bulkReject.Visible = false;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        grdapproval.DataSource = ds.Tables[1];
                        grdapproval.DataBind();
                    }
                    else
                    {
                        grdapproval.DataSource = ds.Tables[1];
                        grdapproval.DataBind();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        grdreject.DataSource = ds.Tables[2];
                        grdreject.DataBind();
                    }
                    else
                    {
                        grdreject.DataSource = ds.Tables[2];
                        grdreject.DataBind();
                    }
                }
                else
                {
                    grdpendingapproval.DataSource = null;
                    grdpendingapproval.DataBind();

                    grdapproval.DataSource = null;
                    grdapproval.DataBind();

                    grdreject.DataSource = null;
                    grdreject.DataBind();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in grdpendingapproval.Rows)
                {
                    if (gvrow.RowType == DataControlRowType.DataRow)
                    {
                        var checkbox = gvrow.FindControl("chk") as CheckBox;

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
                            DropDownList ddlvaluedby = (DropDownList)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("ddlvaluedby");
                            Label lblFileUpload1 = (Label)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("lblFileUpload1");
                            if (ddlvaluedby.SelectedValue == "0")
                            {
                                showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                                showmsg.InnerText = "Please select Valued By.";
                                return;
                            }

                            objbo.Valued_by = ddlvaluedby.SelectedValue.ToString();
                            FileUpload fileFMV = (FileUpload)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("fileFMV");

                            if (!fileFMV.HasFile && fileFMV.Visible == true)
                            {
                                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                                showmsg.InnerText = "Please upload file.";
                                return;
                            }
                            else
                            {
                                string fileName = System.IO.Path.GetFileName(fileFMV.FileName);
                                string ext = System.IO.Path.GetExtension(fileFMV.FileName);

                                if (System.IO.Path.GetExtension(fileName).Contains(".xls") || System.IO.Path.GetExtension(fileName).Contains(".xlsx"))
                                {
                                    fileFMV.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), fileFMV.FileName));
                                }
                                else if(lblFileUpload1.Text == "")
                                {
                                    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                                    showmsg.InnerText = "Only .xls and .xlsx files are allowed";
                                    return;
                                }
                            }

                            objbo.Upload_File = "Fmv_excel/" + fileFMV.FileName.ToString();
                            objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                            objbo.proxy = Convert.ToString(Session["Proxy"]);
                            objbo.status = "APPROVED_BY_SECRETARIAL";
                            status1 = "Approved";
                            TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("txtremark");

                            objbo.remark = txt.Text.ToString();

                            bool val = objbal.update_status(objbo);

                        }
                    }
                }

                bind_secretarial_approval_data();
                bind_secretarial_all_count();
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records approved successfully!!');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been approved in bulk.";
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
                            DropDownList ddl = (DropDownList)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("ddlvaluedby");
                            objbo.Valued_by = ddl.SelectedValue.ToString();
                            FileUpload fileFMV = (FileUpload)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("fileFMV");
                            Label lblFileUpload1 = (Label)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("lblFileUpload1");

                            if (!fileFMV.HasFile && fileFMV.Visible == true)
                            {
                                //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                                //showmsg.InnerText = "Please upload file.";
                                //return;
                            }
                            else
                            {
                                string fileName = System.IO.Path.GetFileName(fileFMV.FileName);
                                string ext = System.IO.Path.GetExtension(fileFMV.FileName);

                                if (System.IO.Path.GetExtension(fileName).Contains(".xls") || System.IO.Path.GetExtension(fileName).Contains(".xlsx"))
                                {
                                    fileFMV.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), fileFMV.FileName));
                                }
                                else if (lblFileUpload1.Text == "")
                                {
                                    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                                    showmsg.InnerText = "Only .xls and .xlsx files are allowed";
                                    return;
                                }
                            }

                            objbo.Upload_File = "Fmv_excel/" + fileFMV.FileName.ToString();

                            objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                            objbo.proxy = Convert.ToString(Session["Proxy"]);
                            objbo.status = "REJECTED_BY_SECRETARIAL";
                            status1 = "Rejected";
                            TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("txtremark");

                            objbo.remark = txt.Text.ToString();

                            bool val = objbal.update_status(objbo);

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
                                    SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Rejected by Secretarial Team", grdpendingapproval.DataKeys[gvrow.RowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[gvrow.RowIndex].Value.ToString(), grdpendingapproval.DataKeys[gvrow.RowIndex].Values[3].ToString(), "", "", "");
                                }

                            }

                        }
                    }

                }
                bind_secretarial_approval_data();
                bind_secretarial_all_count();
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage1();", true);

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records rejected successfully!!');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Grant has been rejected, sent to Admin for the correction.";

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdpendingapproval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlvaluedby = (DropDownList)e.Row.FindControl("ddlvaluedby");
                    Label lblvaluedby = (Label)e.Row.FindControl("lblvaluedby");
                    System.Data.DataTable ds_valuedby = objfmvbal.getvaluedbyddl(objfmvbo);
                    if (ds_valuedby.Rows.Count > 0)
                    {
                        ddlvaluedby.DataSource = ds_valuedby;
                        ddlvaluedby.DataBind();
                        ddlvaluedby.DataTextField = "Valued_By";
                        ddlvaluedby.DataValueField = "AGENCY_ID";
                        ddlvaluedby.DataBind();
                        ddlvaluedby.Items.Insert(0, new ListItem("Select", "0"));
                        if (lblvaluedby.Text.ToString() != "0")
                        {
                            ddlvaluedby.SelectedValue = lblvaluedby.Text.ToString();
                            ddlvaluedby.Enabled = false;
                        }
                        else
                        {
                            ddlvaluedby.SelectedValue = "0";
                            ddlvaluedby.Enabled = true;
                        }
                    }
                    else
                    {
                        ddlvaluedby.Items.Insert(0, new ListItem("Select", "0"));
                    }

                    FileUpload FileUpload1 = (FileUpload)e.Row.FindControl("fileFMV");
                    Label lblFileUpload1 = (Label)e.Row.FindControl("lblFileUpload1");
                    LinkButton btn_Download = (LinkButton)e.Row.FindControl("btn_Download");
                    if (lblFileUpload1.Text.ToString() != "")
                    {
                        btn_Download.Visible = true;
                        FileUpload1.Visible = false;
                    }
                    else
                    {
                        btn_Download.Visible = false;
                        FileUpload1.Visible = true;
                    }
                }
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

        //protected void btn_Approve_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GridViewRow grow = (GridViewRow)((Button)sender).NamingContainer;
        //        int rowIndex = grow.RowIndex;

        //        string status1 = "";
        //        objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[rowIndex].Values[0]);
        //        objbo.ecode = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
        //        objbo.emp_name = grdpendingapproval.Rows[rowIndex].Cells[2].Text;
        //        objbo.appraiser_name = grdpendingapproval.Rows[rowIndex].Cells[3].Text;
        //        objbo.date_of_grant = grdpendingapproval.Rows[rowIndex].Cells[4].Text;
        //        objbo.no_of_options = grdpendingapproval.Rows[rowIndex].Cells[5].Text;
        //        objbo.fmv_price = grdpendingapproval.Rows[rowIndex].Cells[6].Text;
        //        DropDownList ddlvaluedby = (DropDownList)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("ddlvaluedby");

        //        if (ddlvaluedby.SelectedValue == "0")
        //        {
        //            showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
        //            showmsg.InnerText = "Please select Valued By.";
        //            return;
        //        }

        //        objbo.Valued_by = ddlvaluedby.SelectedValue.ToString();
        //        FileUpload fileFMV = (FileUpload)grow.FindControl("fileFMV");

        //        //if (!FileUpload1.HasFile && FileUpload1.Visible == true)
        //        //{
        //        //    showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
        //        //    showmsg.InnerText = "Please upload file.";
        //        //    return;
        //        //}
        //        //if (FileUpload1.FileName != "" && FileUpload1.HasFile)
        //        //{
        //        //    FileUpload1.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), FileUpload1.FileName));
        //        //}

        //        //if (!fileFMV.HasFile && fileFMV.Visible == true)
        //        //{
        //        //    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
        //        //    showmsg.InnerText = "Please upload file.";
        //        //    return;
        //        //}
        //        //else
        //        //{
        //        //    string fileName = System.IO.Path.GetFileName(fileFMV.FileName);
        //        //    string ext = System.IO.Path.GetExtension(fileFMV.FileName);

        //        //    if (System.IO.Path.GetExtension(fileName).Contains(".xls") || System.IO.Path.GetExtension(fileName).Contains(".xlsx"))
        //        //    {
        //        //        fileFMV.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), fileFMV.FileName));
        //        //    }
        //        //    else
        //        //    {
        //        //        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
        //        //        showmsg.InnerText = "Only .xls and .xlsx files are allowed";
        //        //        return;
        //        //    }
        //        //}

        //        objbo.Upload_File = "Fmv_excel/" + Session["FileName"].ToString();
        //        objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
        //        TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("txtremark");

        //        objbo.remark = txt.Text.ToString();
        //        objbo.status = "APPROVED_BY_SECRETARIAL";
        //        objbo.proxy = Convert.ToString(Session["Proxy"]);

        //        status1 = "Approved";
        //        bool val = objbal.update_status(objbo);

        //        if (val == true)
        //        {
        //            //Mail Functionaity--------------------------------------
        //            OEMailBO.RoleName = "President";
        //            OEMailBO.userName = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
        //            string Attachment = "";// Server.MapPath(@"/Fmv_excel/Employee.xlsx");
        //            DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
        //                // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Approved by HR");
        //                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Approved by Secretarial Team", grdpendingapproval.DataKeys[rowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[rowIndex].Values[0].ToString(), grdpendingapproval.DataKeys[rowIndex].Values[3].ToString(), "", "", "");

        //            }
        //        }

        //        bind_secretarial_approval_data();
        //        bind_secretarial_all_count();

        //        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
        //        showmsg.InnerText = "Grant has been approved.";
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}

        //protected void btn_Reject_Click(object sender, EventArgs e)
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
        //        DropDownList ddl = (DropDownList)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("ddlvaluedby");
        //        objbo.Valued_by = ddl.SelectedValue.ToString();
        //        FileUpload fileFMV = (FileUpload)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("fileFMV");

        //        if (!fileFMV.HasFile && fileFMV.Visible == true)
        //        {
        //            //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
        //            //showmsg.InnerText = "Please upload file.";
        //            //return;
        //        }
        //        else
        //        {
        //            string fileName = System.IO.Path.GetFileName(fileFMV.FileName);
        //            string ext = System.IO.Path.GetExtension(fileFMV.FileName);

        //            if (System.IO.Path.GetExtension(fileName).Contains(".xls") || System.IO.Path.GetExtension(fileName).Contains(".xlsx"))
        //            {
        //                fileFMV.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), fileFMV.FileName));
        //            }
        //            else
        //            {
        //                showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
        //                showmsg.InnerText = "Only .xls and .xlsx files are allowed";
        //                return;
        //            }
        //        }

        //        objbo.Upload_File = "Fmv_excel/" + fileFMV.FileName.ToString();
        //        objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
        //        TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("txtremark");

        //        objbo.remark = txt.Text.ToString();

        //        objbo.proxy = Convert.ToString(Session["Proxy"]);
        //        objbo.status = "REJECTED_BY_SECRETARIAL";
        //        status1 = "Rejected";


        //        bool val = objbal.update_status(objbo);

        //        if (val == true)
        //        {
        //            OEMailBO.RoleName = "Admin";
        //            OEMailBO.userName = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
        //            string Attachment = "";
        //            DataSet ds = OEMailBAL.GetEMPDetails(OEMailBO);
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                //SendMail(status1, ds.Tables[0].Rows[0]["USERNAME"].ToString(), ds.Tables[0].Rows[0]["EMAILID"].ToString(), Attachment);
        //                // SendMail(ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant Rejected by HR");
        //                SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Rejected by Secretarial Team", grdpendingapproval.DataKeys[rowIndex].Values[2].ToString(), "", "", grdpendingapproval.DataKeys[rowIndex].Values[3].ToString(), "", "", "");
        //            }

        //            showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
        //            showmsg.InnerText = "Grant has been rejected, sent to Admin for the correction.";
        //            bind_secretarial_approval_data();
        //            bind_secretarial_all_count();
        //        }


        //        // }


        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}

        protected void grdpendingapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
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
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    Label lblFileUpload1 = gvr.FindControl("lblFileUpload1") as Label;
                    string filePath = Server.MapPath(lblFileUpload1.Text);
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

                if (e.CommandName == "Approve")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string status1 = "";
                    objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[rowIndex].Values[0]);
                    objbo.ecode = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
                    objbo.emp_name = grdpendingapproval.Rows[rowIndex].Cells[2].Text;
                    objbo.appraiser_name = grdpendingapproval.Rows[rowIndex].Cells[3].Text;
                    objbo.FMVId = Convert.ToInt32(((Label)grdpendingapproval.Rows[rowIndex].FindControl("lblFMVId")).Text);
                    //objbo.FMVId = Convert.ToInt32(grdpendingapproval.Rows[rowIndex].Cells[4].Text);
                    objbo.date_of_grant = grdpendingapproval.Rows[rowIndex].Cells[6].Text;
                    objbo.no_of_options = grdpendingapproval.Rows[rowIndex].Cells[7].Text;
                    objbo.fmv_price = grdpendingapproval.Rows[rowIndex].Cells[8].Text;
                    DropDownList ddlvaluedby = (DropDownList)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("ddlvaluedby");

                    if (ddlvaluedby.SelectedValue == "0")
                    {
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Please select Valued By.";
                        return;
                    }

                    objbo.Valued_by = ddlvaluedby.SelectedValue.ToString();
                    LinkButton bts = e.CommandSource as LinkButton;
                    FileUpload fileFMV = bts.FindControl("fileFMV") as FileUpload;
                    Label lblFileUpload1 = bts.FindControl("lblFileUpload1") as Label;

                    if (!fileFMV.HasFile && fileFMV.Visible == true)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Please upload file.";
                        return;
                    }
                    else
                    {
                        if (fileFMV.HasFile)
                        {
                            string fileName = System.IO.Path.GetFileName(fileFMV.FileName);
                            string ext = System.IO.Path.GetExtension(fileFMV.FileName);

                            if (System.IO.Path.GetExtension(fileName).Contains(".xls") || System.IO.Path.GetExtension(fileName).Contains(".xlsx"))
                            {
                                fileFMV.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), fileFMV.FileName));
                                objbo.Upload_File = "Fmv_excel/" + fileFMV.FileName.ToString();
                            }
                            else if (lblFileUpload1.Text == "")
                            {
                                showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                                showmsg.InnerText = "Only .xls and .xlsx files are allowed";
                                return;
                            }
                        }
                    }

                    if (fileFMV.Visible == false)
                    {
                        objbo.Upload_File = lblFileUpload1.Text.ToString();
                    }
                    objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("txtremark");

                    objbo.remark = txt.Text.ToString();
                    objbo.status = "APPROVED_BY_SECRETARIAL";
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
                            SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Grant Approved by Secretarial Team", grdpendingapproval.DataKeys[rowIndex].Values[2].ToString(), "", grdpendingapproval.DataKeys[rowIndex].Values[0].ToString(), grdpendingapproval.DataKeys[rowIndex].Values[3].ToString(), "", "", "");

                        }
                    }

                    bind_secretarial_approval_data();
                    bind_secretarial_all_count();

                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Grant has been approved.";
                }

                if (e.CommandName == "Reject")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    string status1 = "";
                    objbo.grantid = Convert.ToInt32(grdpendingapproval.DataKeys[rowIndex].Values[0]);
                    objbo.ecode = grdpendingapproval.DataKeys[rowIndex].Values[1].ToString();
                    objbo.emp_name = grdpendingapproval.Rows[rowIndex].Cells[2].Text;
                    objbo.appraiser_name = grdpendingapproval.Rows[rowIndex].Cells[3].Text;
                    objbo.FMVId = Convert.ToInt32(((Label)grdpendingapproval.Rows[rowIndex].FindControl("lblFMVId")).Text);
                    //objbo.FMVId = Convert.ToInt32(grdpendingapproval.Rows[rowIndex].Cells[4].Text);
                    objbo.date_of_grant = grdpendingapproval.Rows[rowIndex].Cells[6].Text;
                    objbo.no_of_options = grdpendingapproval.Rows[rowIndex].Cells[7].Text;
                    objbo.fmv_price = grdpendingapproval.Rows[rowIndex].Cells[8].Text;
                    DropDownList ddlvaluedby = (DropDownList)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("ddlvaluedby");
                    objbo.Valued_by = ddlvaluedby.SelectedValue.ToString();

                    LinkButton bts = e.CommandSource as LinkButton;
                    FileUpload fileFMV = bts.FindControl("fileFMV") as FileUpload;
                    Label lblFileUpload1 = bts.FindControl("lblFileUpload1") as Label;

                    if (!fileFMV.HasFile && fileFMV.Visible == true)
                    {
                        //showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        //showmsg.InnerText = "Please upload file.";
                        //return;
                        objbo.Upload_File = "";                                                         //Added by Krutika on 04-01-23
                    }
                    else
                    {
                        if (fileFMV.HasFile)
                        {
                            string fileName = System.IO.Path.GetFileName(fileFMV.FileName);
                            string ext = System.IO.Path.GetExtension(fileFMV.FileName);

                            if (System.IO.Path.GetExtension(fileName).Contains(".xls") || System.IO.Path.GetExtension(fileName).Contains(".xlsx"))
                            {
                                fileFMV.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), fileFMV.FileName));
                                objbo.Upload_File = "Fmv_excel/" + fileFMV.FileName.ToString();
                            } 
                            else if (lblFileUpload1.Text == "")
                            {
                                showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                                showmsg.InnerText = "Only .xls and .xlsx files are allowed";
                                return;
                            }
                        }
                    }

                    if (fileFMV.Visible == false)
                    {
                        objbo.Upload_File = lblFileUpload1.Text.ToString();
                    }
                    objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)grdpendingapproval.Rows[Convert.ToInt32(rowIndex)].FindControl("txtremark");

                    objbo.remark = txt.Text.ToString();

                    objbo.proxy = Convert.ToString(Session["Proxy"]);
                    objbo.status = "REJECTED_BY_SECRETARIAL";
                    status1 = "Rejected";


                    bool val = objbal.update_status(objbo);

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
                            SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Grant", "Rejected by Secretarial Team", grdpendingapproval.DataKeys[rowIndex].Values[2].ToString(), "", "", grdpendingapproval.DataKeys[rowIndex].Values[3].ToString(), "", "", "");
                        }

                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Grant has been rejected, sent to Admin for the correction.";
                        bind_secretarial_approval_data();
                        bind_secretarial_all_count();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdapproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
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

                if (e.CommandName == "download")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    Label lblFileUpload1 = gvr.FindControl("lblFileUpload1") as Label;
                    string filePath = Server.MapPath(lblFileUpload1.Text);
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
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
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

        protected void grdpendingapproval_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.get_secretarial_appraval_data(objbo);
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdpendingapproval.UseAccessibleHeader = true;
                grdpendingapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdpendingapproval.DataSource = ds.Tables[0];
                grdpendingapproval.DataBind();
            }
        }

        protected void grdapproval_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.get_secretarial_appraval_data(objbo);
            if (ds.Tables[1].Rows.Count > 0)
            {
                grdapproval.UseAccessibleHeader = true;
                grdapproval.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdreject_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.get_secretarial_appraval_data(objbo);
            if (ds.Tables[2].Rows.Count > 0)
            {
                grdreject.UseAccessibleHeader = true;
                grdreject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

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

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(hdnFileIndex.Value);
                FileUpload fileFMV = (FileUpload)grdpendingapproval.Rows[i].FindControl("fileFMV");
                //HiddenField hdnFileIndex1 = (HiddenField)grdpendingapproval.Rows[i].FindControl("hdnFileIndex");

                if (!fileFMV.HasFile && fileFMV.Visible == true)
                {
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Please upload file.";
                    return;
                }
                else
                {
                    string fileName = System.IO.Path.GetFileName(fileFMV.FileName);
                    string ext = System.IO.Path.GetExtension(fileFMV.FileName);
                    Session["FileName"] = fileName;

                    if (System.IO.Path.GetExtension(fileName).Contains(".xls") || System.IO.Path.GetExtension(fileName).Contains(".xlsx"))
                    {
                        fileFMV.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), fileFMV.FileName));
                    }
                    else
                    {
                        showmsg.Attributes["style"] = "color:red; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Only .xls and .xlsx files are allowed";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdpendingapproval_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            FileUpload fileFMV = grdpendingapproval.Rows[e.RowIndex].FindControl("fileFMV") as FileUpload;

            if (fileFMV.HasFile)
            {

            }
        }

        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";

            string filename = "SECRETARIAL_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
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

        protected void imgExportAudit_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.GetCurrent(this).RegisterPostBackControl(imgExportAudit);
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "SECRETARIAL_REPORT" + DateTime.Now + ".xls";
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


    }
}

