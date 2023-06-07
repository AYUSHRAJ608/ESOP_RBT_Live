using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ESOP
{
    public partial class Employee_profile : System.Web.UI.Page
    {
        Employee_profileBO objbo = new Employee_profileBO();
        Employee_profileBAL objbal = new Employee_profileBAL();
        protected string UploadFolderPath = "~/EMP_BankDetail/";
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Convert.ToString(Session["Role"]) == "Admin" || (Convert.ToString(Session["Proxy"])) != "")

            {
                ddlempstatus.Attributes.Remove("readonly");

            }
            //Bind_Empbank_detail();

            if (!IsPostBack)
            {
                //Session["pageload_prifileimg"] = "";
                //Session["pageload_panimg"] = "";

                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();

                Bind_Empbank_detail();
            }
            else
            {

                if (Convert.ToString(ViewState["ViewStateId"]) != Convert.ToString(Session["SessionId"]))
                {
                    IsPageRefresh = true;
                }
                Session["SessionId"] = System.Guid.NewGuid().ToString();
                ViewState["ViewStateId"] = Session["SessionId"].ToString();
            }

        }

        private void Bind_Empbank_detail()

        {
            try
            {
                objbo.ECODE = Convert.ToString(Session["ECode"]);
                DataSet ds = objbal.get_empbank_detail(objbo);

                ViewState["Emp_filterRec"] = null;
                ViewState["Emp_filterRec"] = ds.Tables[0];
                ViewState["Emp_filterRec1"] = null;
                ViewState["Emp_filterRec1"] = ds.Tables[1];

                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0 || ds.Tables[2].Rows.Count > 0 || ds.Tables[3].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdbankdetail.DataSource = ds.Tables[0];
                        grdbankdetail.DataBind();
                        grdbankdetail.UseAccessibleHeader = true;
                        grdbankdetail.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }

                    else
                    {
                        grdbankdetail.DataSource = ds.Tables[0];
                        grdbankdetail.DataBind();

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        grdempdmatdetail.DataSource = ds.Tables[1];
                        grdempdmatdetail.DataBind();

                        grdempdmatdetail.UseAccessibleHeader = true;
                        grdempdmatdetail.HeaderRow.TableSection = TableRowSection.TableHeader;

                    }

                    else
                    {
                        grdempdmatdetail.DataSource = ds.Tables[1];
                        grdempdmatdetail.DataBind();

                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtempname.Text = ds.Tables[2].Rows[0][2].ToString();
                        txtdoj.Text = ds.Tables[2].Rows[0][3].ToString();



                        ddldesignation.DataTextField = ds.Tables[2].Columns["designation"].ToString(); // text field name of table dispalyed in dropdown
                        ddldesignation.DataValueField = ds.Tables[2].Columns["ECODE"].ToString();             // to retrive specific  textfield name 
                        ddldesignation.DataSource = ds.Tables[2];      //assigning datasource to the dropdownlist
                        ddldesignation.DataBind();
                        txtlocation.Text = ds.Tables[2].Rows[0][5].ToString();
                        if (ds.Tables[2].Rows[0][6].ToString() != "")
                        {

                            ddlempstatus.SelectedIndex = Convert.ToInt32(ds.Tables[2].Rows[0][6]);
                        }
                        if (Convert.ToString(Session["Role"]) != "Admin" && (Convert.ToString(Session["Proxy"])) == "")
                        {
                            ddlempstatus.Attributes.Add("disabled", "disabled");

                            if (ds.Tables[2].Rows[0][6].ToString() != "")
                            {
                                ddlempstatus.SelectedIndex = Convert.ToInt32(ds.Tables[2].Rows[0][6].ToString());
                            }
                        }
                        ddlband.DataTextField = ds.Tables[2].Columns["bands"].ToString(); // text field name of table dispalyed in dropdown
                        ddlband.DataValueField = ds.Tables[2].Columns["ECODE"].ToString();             // to retrive specific  textfield name 
                        ddlband.DataSource = ds.Tables[2];      //assigning datasource to the dropdownlist
                        ddlband.DataBind();

                        txtemailid.Text = ds.Tables[2].Rows[0][8].ToString();
                        txtmanagername.Text = ds.Tables[2].Rows[0][9].ToString();
                        txtpanno.Text = ds.Tables[2].Rows[0][10].ToString();

                    }
                    else
                    {

                    }


                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        //if (Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]) != "" || Convert.ToString(ds.Tables[3].Rows[0]["FILE_PAN_CARD_PATH"]) != "")
                        {
                            string display2 = "";
                            string display = "";
                            string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                            Session["pageload_prifileimg"] = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                            if (!string.IsNullOrEmpty(img1))
                            {
                                display = img1.Remove(0, 1);
                            }
                            else
                            {
                                DivProfilPic.Attributes.Add("style", "display:none");
                            }
                            string img2 = Convert.ToString(ds.Tables[3].Rows[0]["FILE_PAN_CARD_PATH"]);
                            Session["pageload_panimg"] = Convert.ToString(ds.Tables[3].Rows[0]["FILE_PAN_CARD_PATH"]);
                            if (!string.IsNullOrEmpty(img2))
                            {
                                display2 = img2.Remove(0, 1);
                            }
                            else
                            {
                                DivPanCard.Attributes.Add("style", "display:none");
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "displayimg('" + display + "','" + display2 + "');", true);
                        }
                        //else
                        {


                        }
                    }
                    else
                    {


                    }
                }
                else
                {
                    grdbankdetail.DataSource = null;
                    grdbankdetail.DataBind();
                    grdempdmatdetail.DataSource = null;
                    grdempdmatdetail.DataBind();

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void save_bankdetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPageRefresh)
                {
                    return;
                }

                string extension = Path.GetExtension(calcel_cheque_file.FileName);
                string filaname = Convert.ToString(Session["ECode"]) + "_" + "CHEQUE" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string filepath = "~/EMP_BankDetail/" + filaname;
                string PhysicalPath = Server.MapPath(filepath);
                calcel_cheque_file.SaveAs(PhysicalPath);
                objbo.ECODE = Convert.ToString(Session["ECode"]);
                objbo.BANK_NAME = txtbankname.Text;
                objbo.BRANCH_NAME = txtbranchname.Text;
                objbo.ACC_NO = txtaccnumber.Text;
                objbo.IFSC = txtifsccode.Text;
                objbo.FILE_PATH = filepath;
                objbo.CREATEDBY = Convert.ToString(Session["ECode"]);

                //string F_Path = Server.MapPath("~/EMP_BankDetail/" + filaname);
                //Common.UploadFtpFile("EMP_BankDetail/" + filaname, F_Path);


                bool result = objbal.Insert_Emp_bankDetail(objbo);
                if (result == true)

                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bank details created successfully.'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Bank details created successfully";
                }


                Bind_Empbank_detail();
                clearcontrol();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;

            }
        }



        private void clearcontrol()
        {
            txtbankname.Text = txtbranchname.Text = txtaccnumber.Text = txtifsccode.Text = string.Empty;
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            // LinkButton btn = sender as LinkButton;
            // GridViewRow gvrow = btn.NamingContainer as GridViewRow;

            // LinkButton lbn = FindControl("lnkDownload") as LinkButton;
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(lbn);
            string filename = (sender as LinkButton).CommandArgument;
            string filePath = Server.MapPath(filename);
            if (File.Exists(filePath) && Path.HasExtension(filePath))
            {
                ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                ViewState["filepath"] = filename.Replace("~/", "");
                //Response.ContentType = ContentType;
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                //Response.WriteFile(filePath);
                //// Response.TransmitFile(Server.MapPath(filePath));
                //Response.End();
            }
            else
            {
                Common.ShowJavascriptAlert("File is not exist.");
            }
        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            //var  filePath = Request.Form["__EVENTARGUMENT"];
            string filePath = ViewState["filepath"].ToString();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
        protected void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)cb.NamingContainer;
            int rowindex = row.RowIndex;
            objbo.ID = Convert.ToInt32(grdbankdetail.DataKeys[rowindex].Values[0]);
            objbo.ECODE = Convert.ToString(Session["ECode"]); //"CI4197";
                                                              // objbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);

            if (cb.Checked)
            {
                objbo.ISACTIVE = "1";
            }
            else
            {
                DataSet dscheck = objbal.CHECK_activeinactive_status(objbo);
                if (dscheck.Tables[1].Rows.Count == 1)
                {
                    Bind_Empbank_detail();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast one record should be enable.');", true);
                    return;

                }
                objbo.ISACTIVE = "0";
            }
            objbal.Update_Emp_Active_Status(objbo);


        }

        protected void savedmatdetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPageRefresh)
                {
                    return;
                }

                string extension = Path.GetExtension(fileuploadproof.PostedFile.FileName);
                string filaname = Convert.ToString(Session["ECode"]) + "_" + "DEMAT" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string filepath = "~/EMP_BankDetail/" + filaname;
                string PhysicalPath = Server.MapPath(filepath);
                fileuploadproof.SaveAs(PhysicalPath);
                objbo.ECODE = Convert.ToString(Session["ECode"]);
                objbo.SECURITY_NAME = txtsecurityname.Text;
                objbo.DPID = txtdpid.Text;
                objbo.CLIENT_ID = txtclientid.Text;
                objbo.MEMBER_TYPE = ddlmembertype.SelectedItem.Text;
                objbo.FILE_PATH = filepath;
                objbo.CREATEDBY = Convert.ToString(Session["ECode"]);

                //string F_Path = Server.MapPath("~/EMP_BankDetail/" + filaname);
                //Common.UploadFtpFile("EMP_BankDetail/" + filaname, F_Path);


                bool result = objbal.Insert_Emp_DmatDetail(objbo);
                if (result == true)

                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dmat details created successfully.'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "Dmat details created successfully";
                }


                Bind_Empbank_detail();
                clearcontrol1();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;

            }
        }

        private void clearcontrol1()
        {
            txtsecurityname.Text = txtdpid.Text = txtclientid.Text = string.Empty;
            ddlmembertype.SelectedIndex = -1;
        }

        protected void lnkDownload1_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = (sender as LinkButton).CommandArgument;
                string filePath = Server.MapPath(filename);
                if (File.Exists(filePath) && Path.HasExtension(filePath))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                    ViewState["filepath"] = filename.Replace("~/", "");
                    //Response.ContentType = ContentType;
                    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    //Response.WriteFile(filePath);
                    //// Response.TransmitFile(Server.MapPath(filePath));
                    //Response.End();
                }
                else
                {
                    Common.ShowJavascriptAlert("File is not exist.");
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void chkOnOff1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)cb.NamingContainer;
            int rowindex = row.RowIndex;
            objbo.ID = Convert.ToInt32(grdempdmatdetail.DataKeys[rowindex].Values[0]);
            // Session["id"] = id;
            objbo.ECODE = Convert.ToString(Session["ECode"]); //"CI4197";
                                                              //objbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);


            if (cb.Checked)
            {

                objbo.ISACTIVE = "1";
            }
            else
            {
                DataSet dscheck = objbal.CHECK_activeinactive_status(objbo);
                if (dscheck.Tables[0].Rows.Count == 1)
                {
                    Bind_Empbank_detail();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Atleast one record should be enable.');", true);
                    return;

                }
                objbo.ISACTIVE = "0";
            }
            objbal.Update_Emp_Dmat_Active_Status(objbo);



        }

        protected void saveempdetails_Click(object sender, EventArgs e)
        {
            try
            {
                objbo.ECODE = Convert.ToString(Session["ECode"]);
                objbo.email_id = txtemailid.Text;
                objbo.profile_img = Convert.ToString(Session["PROFILE_FilePath"]);
                objbo.FILE_PATH = Convert.ToString(Session["FILE_PAN_CARD_PATH"]);
                objbo.MODIFIEDBY = Convert.ToString(Session["ECode"]);
                objbo.empstatus = Convert.ToString(ddlempstatus.SelectedIndex);
                //ddlempstatus.Items.Clear();
                objbal.Update_Emp_Profile_Status(objbo);
                //commented by Pallavi on 01/03/2022 start
                //if (ddlempstatus.SelectedIndex == 2 || ddlempstatus.SelectedIndex == 3)
                //{
                //    Laps();
                //}
                //commented by Pallavi on 01/03/2022 end
                //added by Pallavi on 01/03/2022 start
                if (ddlempstatus.SelectedIndex == 3)
                {
                    Laps();
                }
                //added by Pallavi on 01/03/2022 end
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Employee details updated successfully.'); ", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                showmsg.InnerText = "Employee details updated successfully";
                ((System.Web.UI.HtmlControls.HtmlImage)(Master.FindControl("imgLoad"))).Src = Convert.ToString(Session["PROFILE_FilePath"]);

                Bind_Empbank_detail();
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }
        private void getempimg()
        {
            objbo.ECODE = Convert.ToString(Session["ECode"]);
            DataSet ds = objbal.get_empbank_detail(objbo);
            if (ds.Tables[3].Rows.Count > 0)
            {
                string img1 = ds.Tables[3].Rows[0]["PROFILE_IMG"].ToString();
                ((System.Web.UI.HtmlControls.HtmlImage)(Master.FindControl("imgLoad"))).Src = img1;
                //  empprofileimg.Src = Page.ResolveClientUrl(img1);

                string img2 = ds.Tables[3].Rows[0]["FILE_PAN_CARD_PATH"].ToString();


            }
            else
            {

            }
        }
        private void clearcontrol2()
        {
            txtempname.Text = string.Empty;

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string filename = (sender as LinkButton).CommandArgument;
            string filePath = Server.MapPath(filename);
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
        }

        protected void lnkprofileDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileempprofileimg.IsUploading) return;
                if (Convert.ToString(Session["PROFILE_FilePath"]) == "")
                {
                    string filePath = Server.MapPath(Convert.ToString(Session["pageload_prifileimg"]));
                    if (File.Exists(filePath))
                    {
                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                        Response.WriteFile(filePath);
                        Response.End();
                    }
                    else
                    {
                        Common.ShowJavascriptAlert("File does not exist.");
                    }
                }
                else
                {
                    string filePath = Server.MapPath(Convert.ToString(Session["PROFILE_FilePath"]));
                    if (File.Exists(filePath))
                    {
                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                        Response.WriteFile(filePath);
                        Response.End();
                    }
                    else
                    {
                        Common.ShowJavascriptAlert("File does not exist.");
                    }
                }
                // Session["PROFILE_FilePath"] = null;
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        protected void fileempprofileimg_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            try
            {
                // divletter.Visible = true;
                // divletter1.Visible = true;
                string fileName = Path.GetFileName(fileempprofileimg.FileName).ToLower();
                string extension = Path.GetExtension(fileempprofileimg.FileName).ToLower();

                if (Path.GetExtension(fileName).Contains(".png") || Path.GetExtension(fileName).Contains(".jpeg") || Path.GetExtension(fileName).Contains(".jpg"))
                {


                    fileName = Convert.ToString(Session["ECode"]) + "_" + "PROFILE" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                    fileempprofileimg.SaveAs(Server.MapPath(this.UploadFolderPath + fileName));
                    Session["PROFILE_FilePath"] = this.UploadFolderPath + fileName;
                    hdfield1.Value = Server.MapPath(this.UploadFolderPath + fileName);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "filePath", "top.$get(\"" + hdfield1.ClientID + "\").value = '" + ResolveClientUrl(this.UploadFolderPath + fileName) + "';", true);



                    // ((System.Web.UI.HtmlControls.HtmlImage)(Master.FindControl("imgLoad"))).Src = Convert.ToString(Session["PROFILE_FilePath"]);

                    // getempimg();
                    //string F_Path = Server.MapPath(this.UploadFolderPath + fileName);
                    //Common.UploadFtpFile("EMP_BankDetail/" + fileName, F_Path);
                    //DivProfilPic.Attributes.Remove("style");
                    //DivProfilPic.Style.Add("Display", "block");
                    //DivProfilPic.Attributes.Add("style", "padding: 0px; margin - top: 10px"); 
                    DivProfilPic.Attributes.Add("style", "display:block");
                }
                else
                {
                    Common.ShowJavascriptAlert("File type should be in jpg,jpeg,png format");

                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

        protected void filepancard_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                // divletter.Visible = true;
                //  divletter1.Visible = true;
                string fileName = Path.GetFileName(filepancard.FileName).ToLower();
                string extension = Path.GetExtension(filepancard.FileName).ToLower();

                if (Path.GetExtension(fileName).Contains(".png") || Path.GetExtension(fileName).Contains(".jpeg") || Path.GetExtension(fileName).Contains(".jpg"))
                {



                    fileName = Convert.ToString(Session["ECode"]) + "_" + "PAN" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                    filepancard.SaveAs(Server.MapPath(this.UploadFolderPath + fileName));
                    Session["FILE_PAN_CARD_PATH"] = this.UploadFolderPath + fileName;
                    hdfield2.Value = Server.MapPath(this.UploadFolderPath + fileName);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "filePath", "top.$get(\"" + hdfield2.ClientID + "\").value = '" + ResolveClientUrl(this.UploadFolderPath + fileName) + "';", true);
                    // ((System.Web.UI.HtmlControls.HtmlImage)(Master.FindControl("imgLoad"))).Src = Convert.ToString(Session["FILE_PAN_CARD_PATH"]);

                    //getempimg();
                    //string F_Path = Server.MapPath(this.UploadFolderPath + fileName);
                    //Common.UploadFtpFile("EMP_BankDetail/" + fileName, F_Path);
                    DivPanCard.Attributes.Add("style", "display:block");
                }
                else
                {
                    Common.ShowJavascriptAlert("File type should be in jpg,jpeg,png format");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void lnkpandownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (filepancard.IsUploading) return;

                if (Convert.ToString(Session["FILE_PAN_CARD_PATH"]) == "")
                {
                    string filePath = Server.MapPath(Convert.ToString(Session["pageload_panimg"]));
                    if (File.Exists(filePath))
                    {
                        Response.ContentType = ContentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                        Response.WriteFile(filePath);
                        Response.End();
                    }
                    else
                    {
                        Common.ShowJavascriptAlert("File does not exist.");
                    }
                }
                else
                {
                    string filePath = Server.MapPath(Convert.ToString(Session["FILE_PAN_CARD_PATH"]));
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        private void Laps()
        {
            DataSet ds;
            ds = GET_LAPS_EMP_STOCK_MAPPING();
        }
        private DataSet GET_LAPS_EMP_STOCK_MAPPING()
        {
            //vesting_creation_BO VestingBO;
            //vesting_creation_BAL VestingBAL = new vesting_creation_BAL();

            //VestingBO = new vesting_creation_BO();
            //DataSet ds = VestingBAL.GET_LAPS_EMP_STOCK_MAPPING();
            //return ds;

            objbo.ECODE = Convert.ToString(Session["ECode"]);
            DataSet ds = objbal.GET_LAPS_EMP_STOCK_MAPPING(objbo);
            return ds;
        }

        protected void grdbankdetail_PreRender(object sender, EventArgs e)
        {
            // objbo.ECODE = Convert.ToString(Session["ECode"]);
            DataTable ds = (DataTable)ViewState["Emp_filterRec"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {

                    grdbankdetail.UseAccessibleHeader = true;
                    grdbankdetail.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        protected void grdempdmatdetail_PreRender(object sender, EventArgs e)
        {
            // objbo.ECODE = Convert.ToString(Session["ECode"]);
            DataTable ds = (DataTable)ViewState["Emp_filterRec1"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {

                    grdempdmatdetail.UseAccessibleHeader = true;
                    grdempdmatdetail.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string Bank_Checked(string BankID, string IsActive)
        {
            string result = string.Empty;
            Employee_profileBO objbo = new Employee_profileBO();
            Employee_profileBAL objbal = new Employee_profileBAL();
            try
            {
                objbo.ID = Convert.ToInt32(BankID);
                objbo.ECODE = Convert.ToString(HttpContext.Current.Session["ECode"]);
                if (IsActive == "1")
                {
                    objbo.ISACTIVE = IsActive;
                    result = "";
                }
                else
                {
                    DataSet dscheck = objbal.CHECK_activeinactive_status(objbo);
                    if (dscheck.Tables[1].Rows.Count == 1)
                    {
                        return result = "Atleast one record should be enable.";
                    }
                    objbo.ISACTIVE = IsActive;
                    result = "";
                }
                objbal.Update_Emp_Active_Status(objbo);
                return result;
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string Demat_Checked(string DematID, string IsActive)
        {
            string result = string.Empty;
            Employee_profileBO objbo = new Employee_profileBO();
            Employee_profileBAL objbal = new Employee_profileBAL();
            try
            {
                objbo.ID = Convert.ToInt32(DematID);
                objbo.ECODE = Convert.ToString(HttpContext.Current.Session["ECode"]);
                if (IsActive == "1")
                {
                    objbo.ISACTIVE = IsActive;
                    result = "";
                }
                else
                {
                    DataSet dscheck = objbal.CHECK_activeinactive_status(objbo);
                    if (dscheck.Tables[0].Rows.Count == 1)
                    {
                        return result = "Atleast one record should be enable.";
                    }
                    objbo.ISACTIVE = IsActive;
                    result = "";
                }
                objbal.Update_Emp_Dmat_Active_Status(objbo);
                return result;
            }
            catch (Exception ex)
            {
                return result = ex.ToString();
            }
        }
    }
}