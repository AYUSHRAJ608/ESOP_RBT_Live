using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;

namespace ESOP
{
    public partial class Admin_Details_Approve_Reject : System.Web.UI.Page
    {
        employee_exerciseBO objBO = new employee_exerciseBO();
        employee_exerciseBAL objBAL = new employee_exerciseBAL();
        EMailBO OEMailBO = new EMailBO();
        EMailBAL OEMailBAL = new EMailBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            GET_Employee_Secretarial_Approve_Reject_Data();
            BindMainGrid();
        }
        private void BindMainGrid()
        {
            try
            {
                DataSet de = new DataSet();
                //DataSet ds = objBAL.GET_Employee_Admin_Main_Grid();
                DataSet ds = objBAL.GET_Employee_Admin_Main_Grid_1();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    btn_BulkApprove.Visible = true;
                    btn_BulkReject.Visible = true;
                }
                else
                {
                    grdMain.DataSource = ds.Tables[0];
                    grdMain.DataBind();
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;
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
                ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA(objBO);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    GrvApproved.DataSource = ds.Tables[1];
                    GrvApproved.DataBind();
                    btn_BulkApprove.Visible = false;
                    ViewState["Approved"] = ds.Tables[1];
                    btn_BulkReject.Visible = false;
                }
                else
                {
                    GrvApproved.DataSource = ds.Tables[1];
                    GrvApproved.DataBind();
                    ViewState["Approved"] = null;
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;

                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    GrvReject.DataSource = ds.Tables[2];
                    GrvReject.DataBind();
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;
                }
                else
                {
                    GrvReject.DataSource = ds.Tables[2];
                    GrvReject.DataBind();
                    btn_BulkApprove.Visible = false;
                    btn_BulkReject.Visible = false;
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
                                objBO.status = "APPROVED_BY_ADMIN";
                                bool val = objBAL.update_status(objBO);
                            }
                        }
                    }
                }
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Record Approved successfully!.";
                GET_Employee_Secretarial_Approve_Reject_Data();
                BindMainGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
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
                                objBO.status = "REJECTED_BY_ADMIN";
                                bool val = objBAL.update_status(objBO);
                                if (val == true)
                                {
                                    OEMailBO.RoleName = "EMP";
                                    OEMailBO.userName = Convert.ToString(GrvPendingforApproval.DataKeys[gvrow.RowIndex].Values[4]);

                                    Employee_secretarialBAL objBAL_BAL = new Employee_secretarialBAL();
                                    DataSet ds1 = objBAL_BAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
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
                    ds = objBAL.GET_Employee_Admin_Main_Data_1(id);
                   
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
                    objBO.status = "APPROVED_BY_ADMIN";

                    bool val = objBAL.update_status(objBO);
                    if (val == true)
                    {
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "Record Accept successfully. Sent to Secretarial for approval.";
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
                    objBO.status = "REJECTED_BY_ADMIN";

                    bool val = objBAL.update_status(objBO);
                    if (val == true)
                    {
                        GridViewRow gvr1 = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                        int rowIndex1 = gvr.RowIndex;

                        GridView gv11 = (GridView)sender;
                        OEMailBO.userName = (gv11.DataKeys[rowIndex1].Values[4].ToString());

                        OEMailBO.RoleName = "EMP";
                        // OEMailBO.userName = ecode;

                        Employee_secretarialBAL objBAL_BAL = new Employee_secretarialBAL();
                        DataSet ds = objBAL_BAL.USP_GET_EMP_DETAILS_for_sell(OEMailBO);
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
                    string Emp_Name = gv1.Rows[rowIndex].Cells[2].Text;
                    Download(ID);
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
                            DivImage1.Visible = false;
                            string Freshchequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                            embed1.Src = Freshchequefile;
                            string FreshDEMATfile = ds.Tables[0].Rows[0]["DEMAT_FILE_PATH"].ToString();
                            embed2.Src = FreshDEMATfile;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        }
                        else
                        {
                            if (Extention == ".jpeg" || Extention == ".png" || Extention == ".jpg")
                            {
                                DivImage.Visible = true;
                                DivImage1.Visible = true;
                                DivPDF.Visible = false;
                                string FreshDEMATfile = ds.Tables[0].Rows[0]["DEMAT_FILE_PATH"].ToString();
                                string Freshchequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
                                FreshChequeImage1.Src = Freshchequefile;
                                FreshDEMATImage1.Src = FreshDEMATfile;
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
            List<string> list = new List<string>();
            //Soaumya 
            string chequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
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
            string EMPNAME = Convert.ToString(id) + "_ExerciseDoc"; //Name;
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
                    string zipName = String.Format("Documents_{0}.zip", ENAME);
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
        protected void Download_OLD(double id)
        {
            DataSet ds = new DataSet();
            ds = objBAL.GET_EMPLOYEE_SECRETARIAL_DownloadLink(id);
                        
            string chequefile = ds.Tables[0].Rows[0]["CHEQUE_FILE_PATH_FRESH"].ToString();
            if (chequefile != "")
            {
                string filePath = Server.MapPath(chequefile);
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

                HttpContext.Current.Response.ClearContent();
            }

            string NEFTfile = ds.Tables[0].Rows[0]["NEFT_FILE_NAME"].ToString();
            //string NEFTfile = ds.Tables[0].Rows[0]["NEFT_FILE_PATH"].ToString();
            if (NEFTfile != "")
            {
                string filePath = Server.MapPath(NEFTfile);
                Response.ClearHeaders();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                
                HttpContext.Current.Response.ClearContent();
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
            }
            Response.End();
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



        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }




        //protected void DownloadFiles(string[] link, string ENAME)
        //{
        //    using (ZipFile zip = new ZipFile())
        //    {
        //        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
        //        zip.AddDirectoryByName("Files");               
        //        string In = "";
        //        foreach (string R in link)
        //        {

        //            string filePath = Server.MapPath(R);
        //            zip.AddFile(filePath, "Files");
        //            In = "IN";
        //        }
        //        if (In == "IN")
        //        {
        //            Response.Clear();
        //            Response.BufferOutput = false;
        //            //string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //            string zipName = String.Format("Documents_{0}.zip", ENAME);
        //            Response.ContentType = "application/zip";
        //            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        //            zip.Save(Response.OutputStream);
        //            Response.End();
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No Documents are there to download!!');", true);
        //        }
        //    }
        //}


        protected void DownloadFiles_OLD(string[] link, string ENAME)
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
            DataSet ds = objBAL.GET_Employee_Admin_Main_Grid();
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
            DataSet ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA(objBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                GrvApproved.UseAccessibleHeader = true;
                GrvApproved.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvReject_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objBAL.GET_EMPLOYEE_EXERCISE_DATA(objBO);
            if (ds.Tables[1].Rows.Count > 0)
            {

                GrvReject.UseAccessibleHeader = true;
                GrvReject.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrvPendingforApproval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    TextBox txt = (TextBox)e.Row.FindControl("txt_remark");

                //    //string Repeat = ((HiddenField)e.Row.FindControl("Repeat")).Value;
                //    string Repeat = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Repeat"));

                //    if (Repeat == "Repeat")
                //    {
                //        txt.Text = "Repeat";
                //    }

                //}
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ADMIN_APPROVED_EXERCISE_REPORT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            GrvApproved.GridLines = GridLines.Both;
            GrvApproved.HeaderStyle.Font.Bold = true;
            GrvApproved.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

    }
}