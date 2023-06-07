using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Drawing;
using System.Net;
using Ionic.Zip;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace ESOP
{
    public partial class Employee_secretarial : System.Web.UI.Page
    {
        Employee_secretarialBAL objBAL = new Employee_secretarialBAL();
        Employee_SecretarialBO objBO = new Employee_SecretarialBO();
        exercise_reportBAL objBALEx = new exercise_reportBAL();
        exercise_reportBO objBOEx = new exercise_reportBO();
        employee_exerciseBO objBOExe = new employee_exerciseBO();
        employee_exerciseBAL objBALexe = new employee_exerciseBAL();


        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GET_Employee_Secretarial_Approve_Reject_Data();
            BindMainGrid();
            GET_ADMIN_EXERCISE_REPORT();
        }
        private void BindMainGrid()
        {
            try
            {
                DataSet de = new DataSet();
                DataSet ds = objBAL.GET_Employee_Secretarial_Main_Grid();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    btn_BulkApprove.Visible = true;
                    // btn_BulkReject.Visible = true;
                }
                else
                {
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    btn_BulkApprove.Visible = false;
                    //  btn_BulkReject.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        public void GET_Employee_Secretarial_Approve_Reject_Data()
        {
            try

            {
                DataSet ds = new DataSet();
                ds = objBAL.GET_Employee_Secretarial_Approve_Reject_Data();
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrvApproved.DataSource = ds.Tables[0];
                        GrvApproved.DataBind();
                        btn_BulkApprove.Visible = false;
                        ViewState["Approved"] = ds.Tables[0];
                        // btn_BulkReject.Visible = false;
                    }
                    else
                    {
                        GrvApproved.DataSource = ds.Tables[0];
                        GrvApproved.DataBind();
                        ViewState["Approved"] = null;
                        btn_BulkApprove.Visible = false;
                        //  btn_BulkReject.Visible = false;

                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GrvReject.DataSource = ds.Tables[1];
                        GrvReject.DataBind();
                        btn_BulkApprove.Visible = false;
                        // btn_BulkReject.Visible = false;
                    }
                    else
                    {
                        GrvReject.DataSource = ds.Tables[1];
                        GrvReject.DataBind();
                        btn_BulkApprove.Visible = false;
                        // btn_BulkReject.Visible = false;
                    }
                }
                else
                {


                    GrvApproved.DataSource = ds.Tables[0];
                    GrvApproved.DataBind();


                    GrvReject.DataSource = ds.Tables[1];
                    GrvReject.DataBind();
                    btn_BulkApprove.Visible = false;
                    // btn_BulkReject.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        
        protected void btn_bulkApprove_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            var checkbox = gvrow.FindControl("chk") as CheckBox;
                            if (checkbox.Checked)
                            {
                                flag = true;
                            }
                        }
                    }
                }

                if (flag == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast One check should be selected!!!');", true);
                    return;
                }

                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            var checkbox = gvrow.FindControl("chk") as CheckBox;

                            if (checkbox.Checked)
                            {
                                objBO.id = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                                objBO.etid = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);
                                //objBO.eetdid = Convert.ToInt32(GrvPendingforApproval.Rows[gvrow.RowIndex].Cells[10].Text);
                                objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                                TextBox txt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[15].FindControl("txt_remark");
                                objBO.remark = txt.Text.Replace(",", "");
                                objBO.status = "Approved";

                                bool val = objBAL.update_status(objBO);


                                string No_of_exercise = GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[8].Text;
                                objBOExe.ECODE = grdMain.DataKeys[i].Values[0].ToString();
                                objBOExe.VESTING_DETAIL_ID = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[3]);
                                objBOExe.OPTION_EXERCISE = Convert.ToInt32(No_of_exercise);

                                objBALexe.UPDATE_EMPLOYEE_EXERCISE(objBOExe);
                                if (val == true)
                                {
                                    OEMailBO.RoleName = "EMP";
                                    OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[4]);

                                    DataSet ds1 = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                                    string email2 = "";
                                    if (ds1.Tables[0].Rows.Count == 1)
                                    {
                                        email2 = ds1.Tables[0].Rows[0]["EMAILID"].ToString();
                                    }
                                    else
                                    {
                                        email2 = (ds1.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds1.Tables[0].Rows[1]["EMAILID"].ToString());
                                    }

                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds1.Tables[0].Rows[0]["USERNAME"].ToString(), "Secretarial Approval", "Exercise Approved By Secretarial", "", email2, "", "", "", "", "");
                                    }
                                }
                            }
                        }
                    }

                }
                GET_Employee_Secretarial_Approve_Reject_Data();
                BindMainGrid();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Exercise has been approved');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Exercise has been approved.";
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }

        }

        protected void btn_bulkReject_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;

                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            var checkbox = gvrow.FindControl("chk") as CheckBox;
                            if (checkbox.Checked)
                            {
                                flag = true;
                            }
                        }
                    }
                }

                if (flag == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast One check should be selected!!!');", true);
                    return;
                }

                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            var checkbox = gvrow.FindControl("chk") as CheckBox;
                            if (checkbox.Checked)
                            {
                                objBO.id = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[0]);
                                objBO.etid = Convert.ToInt32(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[2]);
                                objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                                TextBox txt = (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].Cells[15].FindControl("txt_remark");
                                objBO.remark = txt.Text.Replace(",", "");
                                objBO.status = "Reject";

                                bool val = objBAL.update_status(objBO);
                                if (val == true)
                                {
                                    OEMailBO.RoleName = "EMP";
                                    OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[4]);

                                    DataSet ds1 = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                                    string email2 = "";
                                    if (ds1.Tables[0].Rows.Count == 1)
                                    {
                                        email2 = ds1.Tables[0].Rows[0]["EMAILID"].ToString();
                                    }
                                    else
                                    {
                                        email2 = (ds1.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds1.Tables[0].Rows[1]["EMAILID"].ToString());
                                    }

                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds1.Tables[0].Rows[0]["USERNAME"].ToString(), "Exercise Reject", "Exercise Rejected By Secretarial", "", email2, "", "", "", "", "");
                                    }
                                }
                            }
                        }
                    }
                }
                GET_Employee_Secretarial_Approve_Reject_Data();
                BindMainGrid();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Exercise has been rejected!!');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Exercise has been rejected.";

            }
            catch (Exception ex)

            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }

        protected void GrvPFADB(object sender, GridViewRowEventArgs e)
        {
            GridView GrvPendingforApproval = e.Row.FindControl("GrvPendingforApproval") as GridView;
            DataSet ds = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= grdMain.Rows.Count; i++)
                {
                    //double id = grdMain.DataKeys[i].Values[0].ToString();
                    string id = (grdMain.DataKeys[i].Values[0].ToString());
                    ds = objBAL.GET_Employee_Secretarial_Main_Data(id);
                    GrvPendingforApproval.DataSource = ds.Tables[0];
                    GrvPendingforApproval.DataBind();
                }
            }
        }

        protected void GrvPendingforApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //try
            {

                if (e.CommandName == "Approve")
                {

                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                    int rowIndex = gvr.RowIndex;

                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                    double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                    // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                    objBO.id = ID;
                    objBO.etid = etID;
                    objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("txt_remark");
                    objBO.remark = txt.Text.Replace(",", "");
                    objBO.status = "Approved";

                    bool val = objBAL.update_status(objBO);

                    if (val == true)
                    {
                        //Label lbl = (Label)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("no_of_exercise");
                        string No_of_exercise = gv1.Rows[Convert.ToInt32(rowIndex)].Cells[8].Text;

                        //objBOExe.ECODE = grdMain.DataKeys[rowIndex].Values[0].ToString();
                        objBOExe.ECODE = gv1.Rows[Convert.ToInt32(rowIndex)].Cells[1].Text;
                        objBOExe.VESTING_DETAIL_ID = Convert.ToInt32(Convert.ToString(gv1.DataKeys[rowIndex].Values[3]));
                        objBOExe.OPTION_EXERCISE = Convert.ToInt32(No_of_exercise);
                        objBALexe.UPDATE_EMPLOYEE_EXERCISE(objBOExe);

                        GridViewRow gvr1 = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                        int rowIndex1 = gvr.RowIndex;

                        GridView gv11 = (GridView)sender;
                        OEMailBO.userName = (gv11.DataKeys[rowIndex1].Values[4].ToString());


                        OEMailBO.RoleName = "EMP";
                        // OEMailBO.userName = ecode;

                        DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                        string email2 = "";
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                        }
                        else
                        {
                            email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                        }


                        string Attachment = "";
                        if (objBO.status == "Approved")
                        {
                            SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Secretarial Approval", "Exercise Approved By Secretarial", "", email2, "", "", "", "", "");
                        }
                        else
                        {
                            SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Secretarial Reject", "Exercise Rejected By Secretarial", "", email2, "", "", "", "", "");
                        }

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Exercise has been approved!!');", true);
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Exercise has been approved.";
                        GET_Employee_Secretarial_Approve_Reject_Data();
                        BindMainGrid();
                    }

                }
                if (e.CommandName == "Reject")
                {
                    GridViewRow gvr = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    string Grant_ID = Convert.ToString(gv1.DataKeys[rowIndex].Values[1]);
                    double etID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[2]);

                    // GridView GrvPendingforApproval = (GridView)grdMain.Rows[rowIndex].FindControl("GrvPendingforApproval");

                    objBO.id = ID;
                    objBO.etid = etID;
                    objBO.modifiedBy = Convert.ToString(Session["ECode"]);
                    TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("txt_remark");
                    objBO.remark = txt.Text.Replace(",", "");
                    objBO.status = "Reject";

                    bool val = objBAL.update_status(objBO);
                    if (val == true)
                    {
                        GridViewRow gvr1 = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                        int rowIndex1 = gvr.RowIndex;

                        GridView gv11 = (GridView)sender;
                        OEMailBO.userName = (gv11.DataKeys[rowIndex1].Values[4].ToString());

                        OEMailBO.RoleName = "EMP";
                        // OEMailBO.userName = ecode;

                        DataSet ds = objBAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
                        string email2 = "";
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            email2 = ds.Tables[0].Rows[0]["EMAILID"].ToString();
                        }
                        else
                        {
                            email2 = (ds.Tables[0].Rows[0]["EMAILID"].ToString() + "," + ds.Tables[0].Rows[1]["EMAILID"].ToString());
                        }

                        string Attachment = "";
                        SendMail.Function_SendMail(Convert.ToString(Session["UserName"]), ds.Tables[0].Rows[0]["USERNAME"].ToString(), "Secretarial Reject", "Exercise Rejected By Secretarial", "", email2, "", "", "", "", "");
                    }

                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Record Reject successfully!.";
                    GET_Employee_Secretarial_Approve_Reject_Data();
                    BindMainGrid();
                }
                if (e.CommandName == "download")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    string Emp_Code= gv1.Rows[rowIndex].Cells[1].Text;
                    Download(ID, Emp_Code);
                }

                if (e.CommandName == "Preview")
                {
                    GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    GridView gv1 = (GridView)sender;
                    double ID = Convert.ToDouble(gv1.DataKeys[rowIndex].Values[0]);
                    DataSet ds = new DataSet();
                    ds = objBAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(ID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Extention = Path.GetExtension(ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString());
                        if (Extention == ".pdf")
                        {
                            DivPDF.Visible = true;
                            DivImage.Visible = false;
                            string Freshchequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                            embed1.Src = Freshchequefile;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        }
                        else
                        {
                            if (Extention == ".jpeg" || Extention == ".png" || Extention == ".jpg")
                            {
                                DivImage.Visible = true;
                                DivPDF.Visible = false;
                                string Freshchequefile = ds.Tables[0].Rows[0]["DEMAT_FILE_PATH"].ToString();//ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                                FreshChequeImage1.Src = Freshchequefile;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                            }
                            else
                            {
                                if (Extention == ".doc" || Extention == ".docx")
                                {
                                    string filePath = Server.MapPath(ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString());
                                    if (File.Exists(filePath))
                                    {
                                        Response.ContentType = ContentType;
                                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                                        Response.WriteFile(filePath);
                                        Response.End();
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder');", true);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No document Exist');", true);
                    }

                }

                for (int i = 0; i < grdMain.Rows.Count; i++)
                {
                    GridView GrvPendingforApproval = (GridView)grdMain.Rows[i].FindControl("GrvPendingforApproval");
                    foreach (GridViewRow gvrow in GrvPendingforApproval.Rows)
                    {
                        if (gvrow.RowType == DataControlRowType.DataRow)
                        {
                            TextBox txt = (TextBox)gvrow.FindControl("txt_remark");
                            string disply = txt.Text;
                            // TextBox txt = (TextBox)gv1.Rows[Convert.ToInt32(rowIndex)].FindControl("txt_remark");
                            txt.Text = string.Empty;
                        }
                    }
                }
            }
        }
        
        protected void Download(double id)
        {
            DataSet ds = new DataSet();
            ds = objBAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(id);

            //string _path = "D:/demo1234.txt";//Request.PhysicalApplicationPath + "Album\\" + name;
            //System.IO.FileInfo _file = new System.IO.FileInfo(_path);
            string chequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH"].ToString();
            if (chequefile != "")
            {
                string filePath = Server.MapPath(chequefile);
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                //HttpContext.Current.Response.ClearContent();
                //HttpContext.Current.Response.ClearHeaders();
                //Response.End();
            }

            string NEFTfile = ds.Tables[0].Rows[0]["NEFT_FILE_NAME"].ToString();
            if (NEFTfile != "")
            {
                string filePath = Server.MapPath(NEFTfile);
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                //Response.End();
            }

            string DEMATfile = ds.Tables[0].Rows[0]["DEMAT_FILE_PATH"].ToString();
            if (DEMATfile != "")
            {
                string filePath = Server.MapPath(DEMATfile);
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                //Response.End();
            }


        }
        
        protected void lnkBank_Statement_ServerClick(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Uploaded_Files/");

            bool FileExists = Directory.EnumerateFileSystemEntries(path).Any();

            if (FileExists == true)
            {
                var directory = new DirectoryInfo(path);
                var myFile = (from f in directory.GetFiles()
                              orderby f.LastWriteTime descending
                              select f).First().ToString();


                string filePath = Server.MapPath("~/Uploaded_Files/" + myFile);
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
                // or...
                //var myFile = directory.GetFiles()
                //             .OrderByDescending(f => f.LastWriteTime)
                //             .First();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No file found!!');", true);
            }

        }

        protected void lnkExcercise_Report_ServerClick(object sender, EventArgs e)
        {

            //Response.Clear();
            //Response.Buffer = true;
            //string filename = "EXERCISE_REPORT_" + Convert.ToString(Session["ECODE"]) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    gvExercise.AllowPaging = false;
            //    this.GET_ADMIN_EXERCISE_REPORT();
            //    if (gvExercise.Rows.Count > 0)
            //    {
            //        gvExercise.HeaderRow.BackColor = Color.White;
            //        foreach (TableCell cell in gvExercise.HeaderRow.Cells)
            //        {
            //            cell.BackColor = gvExercise.HeaderStyle.BackColor;
            //        }
            //        foreach (GridViewRow row in gvExercise.Rows)
            //        {
            //            row.BackColor = Color.White;
            //            foreach (TableCell cell in row.Cells)
            //            {
            //                if (row.RowIndex % 2 == 0)
            //                {
            //                    cell.BackColor = gvExercise.AlternatingRowStyle.BackColor;
            //                }
            //                else
            //                {
            //                    cell.BackColor = gvExercise.RowStyle.BackColor;
            //                }
            //                cell.CssClass = "textmode";
            //            }
            //        }

            //        gvExercise.RenderControl(hw);

            //        //style to format numbers to string
            //        string style = @"<style> .textmode { } </style>";
            //        Response.Write(style);
            //        Response.Output.Write(sw.ToString());
            //        Response.Flush();
            //        Response.End();
            //    }

            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No data to download!!');", true);
            //    }
            //}
            string id = "";
            DataSet ds = objBAL.GET_Employee_Secretarial_Main_Data(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdData.DataSource = ds.Tables[0];
                GrdData.DataBind();

                //Response.ContentType = "application/pdf";
                //string filename = "EXERCISE_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                //// Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");           
                //Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //GrdData.RenderControl(hw);
                //StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();
                //GrdData.AllowPaging = true;
                //GrdData.DataBind();

                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "SECRETARIAL_EXERCISE_REPORT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
                GrdData.GridLines = GridLines.Both;
                GrdData.HeaderStyle.Font.Bold = true;
                GrdData.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();

            }

        }

        public void GET_ADMIN_EXERCISE_REPORT()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objBALEx.GET_ADMIN_EXERCISE_REPORT(objBOEx);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvExercise.DataSource = ds.Tables[0];

                    gvExercise.DataBind();

                    // gvExercise.UseAccessibleHeader = true;
                    // gvExercise.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    gvExercise.DataSource = ds.Tables[0];
                    gvExercise.DataBind();

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                //throw ex;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void Download(double id, string Name)
        {
            DataSet ds = new DataSet();
            ds = objBAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(id);
            List<string> list = new List<string>();

            //string Freshchequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
            //if (Freshchequefile != "")
            //{
            //    list.Add(Freshchequefile);
            //}

            //Soaumya 
            string chequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH"].ToString();
            if (chequefile != "")
            {
                list.Add(chequefile);
            }

            string NEFTfile = ds.Tables[0].Rows[0]["NEFT_FILE_NAME"].ToString();
            if (NEFTfile != "")
            {
                list.Add(NEFTfile);
            }

            string DEMATfile = ds.Tables[0].Rows[0]["DEMAT_FILE_PATH"].ToString();
            if (DEMATfile != "")
            {
                list.Add(DEMATfile);
            }
            string[] str = list.ToArray();
            string EMPNAME = Convert.ToString(Name) + "_ExerciseDoc"; //Name;
            DownloadFiles(str, EMPNAME);
        }


        protected void DownloadFiles(string[] link, string ENAME)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                string In = "";
                foreach (string R in link)
                {

                    string filePath = Server.MapPath(R);
                    zip.AddFile(filePath, "Files");
                    In = "IN";
                }
                if (In == "IN")
                {
                    Response.Clear();
                    Response.BufferOutput = false;
                    //string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                    string zipName = String.Format("{0}.zip", ENAME);
                    Response.ContentType = "application/zip";
                    Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                    zip.Save(Response.OutputStream);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Documents are there to download!!');", true);
                }
            }
        }


        protected void DownloadFiles_Single(string[] link, string ENAME)
        {
            string In = "";
            string filePath = "";
            foreach (string R in link)
            {
                filePath = Server.MapPath(R);
                In = "IN";
            }
            if (In == "IN")
            {
                if (File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    Response.Clear();
                    Response.ContentType = ContentType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Documents Not exist in folder!!');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Documents are there to download!!');", true);
            }
        }
        protected void grdMain_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_Employee_Secretarial_Main_Grid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdMain.UseAccessibleHeader = true;
                grdMain.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvApproved.PageIndex = e.NewPageIndex;
            GET_Employee_Secretarial_Approve_Reject_Data();

        }

        protected void GrvApproved_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
            {
                ViewState["SortDirection"] = "ASC";
                GrvApproved.PageIndex = 0;
            }
            else if (ViewState["SortDirection"].ToString() == "ASC")
            {
                ViewState["SortDirection"] = "DESC";
            }
            else if (ViewState["SortDirection"].ToString() == "DESC")
            {
                ViewState["SortDirection"] = "ASC";
            }
            ViewState["SortExpression"] = e.SortExpression;

            DataTable dt = (DataTable)ViewState["Approved"];
            if (dt != null)
            {
                dt.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + ViewState["SortDirection"].ToString();
                GrvApproved.DataSource = dt;
                GrvApproved.DataBind();
            }
        }

        protected void GrvApproved_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_Employee_Secretarial_Approve_Reject_Data();
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}