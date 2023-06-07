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
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace ESOP
{
    public partial class ESOP : System.Web.UI.MasterPage
    {
        string role;
        string gender;
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        EmployeeBO objEmpBo = new EmployeeBO();
        EmployeeBAL objEmpBal = new EmployeeBAL();
        Employee_profileBO objempprofilebo = new Employee_profileBO();
        Employee_profileBAL objempprofilebal = new Employee_profileBAL();
        UserBO objcUserEntity = new UserBO();
        UserBAL objcUserBAL = new UserBAL();
        cUserEntityRequest objcUserEntityRequest = new cUserEntityRequest();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    #region ReportBuiilder Session Details

                    //if (string.IsNullOrEmpty(Session["LoginId"].ToString()))
                    if (Convert.ToString(Session["LoginId"]) == "")
                    {
                        Response.Redirect("~/login.aspx", false);
                        return;
                    }

                    string queryUserName_Ency = Convert.ToString(Session["LoginId"]); 
                    string queryPassword_Ency = Convert.ToString(Session["LoginPassword"]);
                    string queryConStr_Ency = "ESOP";

                    Session["LoginId_encrypt"] = HttpUtility.UrlEncode(Encrypt(queryUserName_Ency.Trim()));
                    Session["LoginPassword_encrypt"] = HttpUtility.UrlEncode(Encrypt(queryPassword_Ency.Trim()));
                    Session["ConStr_encrypt"] = HttpUtility.UrlEncode(Encrypt(queryConStr_Ency.Trim()));

                    #endregion

                    A5.Style["display"] = "none";

                    FillUserName();

                    if (Session["Proxy"] != null)
                    {
                        A5.Style["display"] = "block";
                        lblProxy.Text = Convert.ToString(Session["ProxyName"]) + " Logged In on the behalf of " + Convert.ToString(Session["UserName"]);
                    }
                    if (Convert.ToString(Session["Role"]) != "Admin")
                    {
                        lnkProxy.Style["display"] = "none";
                    }
                    if ((Session["Proxy"] is string))
                    {
                        lnkProxy.Style["display"] = "block";
                    }
                    else
                    {
                        //lnkProxyLogOut.Style["display"] = "none";
                    }
                    if (Session["UserName"] == null)
                    {
                        Response.Redirect("~/login.aspx", false);
                    }
                    if (Session["Tab"] == null)
                    {
                        Response.Redirect("~/login.aspx", false);
                    }
                    if (Session["Role"] != null)
                    {
                        spnUserName.InnerHtml = Convert.ToString(Session["UserName"]);
                        role = Convert.ToString(Session["Role"]);
                        gender = Convert.ToString(Session["Gender"]);
                        objempprofilebo.ECODE = Convert.ToString(Session["ECode"]);
                        DataSet ds = objempprofilebal.get_empbank_detail(objempprofilebo);
                        if (role == "Admin")
                        {

                            if (Convert.ToString(Session["MasterRole"]) != "Employee" && Convert.ToString(Session["MasterRole"]) != "HR Head" && Convert.ToString(Session["MasterRole"]) != "President" && Convert.ToString(Session["MasterRole"]) != "Secretarial")
                            //if (Convert.ToString(Session["MasterRole"]) != "Admin")
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }

                                ////Adminlnk.Visible = true;
                                ////lnkAdmin.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Presidentlnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Employeelnk.Visible = false;
                                ////SecretialLnk.Visible = false;
                                ////lnkAdmin.Visible = true;
                                ////lnkHrHead.Visible = false;
                                ////lnkPresident.Visible = false;
                                ////lnkEmployee.Visible = true;
                                ////lnksecretarial.Visible = false;
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
                            }
                            else if (Convert.ToString(Session["MasterRole"]) == "Employee")
                            {

                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }
                                ////lnkAdmin.Visible = true;
                                ////lnkHrHead.Visible = false;
                                ////lnkPresident.Visible = false;
                                ////lnksecretarial.Visible = false;
                                ////Employeelnk.Visible = true;
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Presidentlnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////SecretialLnk.Visible = false;
                                ////lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
                                //////LblTitle.Text = "ESOP - Employee Dashboard";
                            }
                            else if (Convert.ToString(Session["MasterRole"]) == "HR Head")
                            {

                                ////Presidentlnk.Visible = false;
                                ////Employeelnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////HRlnk.Visible = true;
                                ////SecretialLnk.Visible = false;

                                ////lnkHrHead.Attributes.Add("class", "btn btn-outline-primary active");
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
                                //LblTitle.Text = "ESOP - HR Head Dashboard";
                            }
                            else if (Convert.ToString(Session["MasterRole"]) == "President")
                            {
                                //Presidentlnk.Visible = true;
                                //lnkPresident.Attributes.Add("class", "btn btn-outline-primary active");
                                //Employeelnk.Visible = false;
                                //HRlnk.Visible = false;
                                //Adminlnk.Visible = false;
                                //SecretialLnk.Visible = false;
                                //lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");

                            }
                            else if (Convert.ToString(Session["MasterRole"]) == "Secretarial")
                            {

                                ////Presidentlnk.Visible = false;
                                ////lnkPresident.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Employeelnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////SecretialLnk.Visible = true;
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
                                //LblTitle.Text = "ESOP - Employee Dashboard";
                            }

                        }
                        else if (role == "HR Head")
                        {

                            if (Convert.ToString(Session["MasterRole"]) != "Employee")
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }
                                ////HRlnk.Visible = true;
                                ////lnkHrHead.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Presidentlnk.Visible = false;
                                ////Employeelnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////SecretialLnk.Visible = false;

                                //////LblTitle.Text = "ESOP - HR Head Dashboard";
                                ////lnkAdmin.Visible = false;
                                ////lnkHrHead.Visible = true;
                                ////lnkPresident.Visible = false;
                                ////lnkEmployee.Visible = true;
                                ////lnksecretarial.Visible = false;
                                ////// lnkHrHead.Attributes.Add("class", "btn btn-outline-primary active");
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
                            }

                            else
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }
                                ////Employeelnk.Visible = true;
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Presidentlnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////SecretialLnk.Visible = false;

                                //////LblTitle.Text = "ESOP - Employee Dashboard";
                                ////lnkAdmin.Visible = false;
                                ////lnkHrHead.Visible = true;
                                ////lnkPresident.Visible = false;
                                ////lnkEmployee.Visible = true;
                                ////lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
                                ////lnksecretarial.Visible = false;

                            }
                        }
                        else if (role == "President")
                        {

                            if (Convert.ToString(Session["MasterRole"]) != "Employee")
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }
                                ////Presidentlnk.Visible = true;
                                ////lnkPresident.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Employeelnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////SecretialLnk.Visible = false;

                                ////lnkAdmin.Visible = false;
                                ////lnkHrHead.Visible = false;
                                ////lnkPresident.Visible = true;
                                ////lnkEmployee.Visible = true;
                                ////lnksecretarial.Visible = false;
                                //////LblTitle.Text = "ESOP - President Dashboard";

                                ////// lnkPresident.Attributes.Add("class", "btn btn-outline-primary active");
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
                            }
                            else
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }
                                ////Employeelnk.Visible = true;
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Presidentlnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////SecretialLnk.Visible = false;

                                //////LblTitle.Text = "ESOP -  Employee Dashboard";
                                ////lnkAdmin.Visible = false;
                                ////lnkHrHead.Visible = false;
                                ////lnkPresident.Visible = true;
                                ////lnkEmployee.Visible = true;
                                ////lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
                                ////lnksecretarial.Visible = false;


                            }


                        }



                        else if (role == "Secretarial")
                        {

                            if (Convert.ToString(Session["MasterRole"]) != "Employee")
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }
                                ////SecretialLnk.Visible = true;

                                ////lnksecretarial.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Employeelnk.Visible = false;
                                ////Presidentlnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Adminlnk.Visible = false;

                                ////lnkPresident.Visible = false;
                                ////lnkAdmin.Visible = false;
                                ////lnkHrHead.Visible = false;
                                ////lnksecretarial.Visible = true;
                                ////lnkEmployee.Visible = true;
                                ////// lnkSecretarial.Visible = false;
                                //////LblTitle.Text = "ESOP - President Dashboard";

                                ////// lnksecretarial.Attributes.Add("class", "btn btn-outline-primary active");
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
                            }
                            else
                            {
                                if (ds.Tables[3].Rows.Count > 0)
                                {
                                    string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                    if (img1 == "")
                                    {
                                        imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                    }
                                    else
                                    {

                                        imgLoad.Src = (img1);
                                        // Session["PROFILE_IMG"] = img1;
                                    }

                                }
                                ////Employeelnk.Visible = true;
                                ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");
                                ////Presidentlnk.Visible = false;
                                ////HRlnk.Visible = false;
                                ////Adminlnk.Visible = false;
                                ////SecretialLnk.Visible = false;

                                //////LblTitle.Text = "ESOP -  Employee Dashboard";
                                ////lnkAdmin.Visible = false;
                                ////lnkHrHead.Visible = false;
                                ////lnkPresident.Visible = false;
                                ////lnkEmployee.Visible = true;
                                ////lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");
                                ////lnksecretarial.Visible = true;



                            }


                        }



                        else
                        {

                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                string img1 = Convert.ToString(ds.Tables[3].Rows[0]["PROFILE_IMG"]);
                                if (img1 == "")
                                {
                                    imgLoad.Src = Page.ResolveUrl("~/assets/img/user.png");
                                }
                                else
                                {

                                    imgLoad.Src = (img1);
                                    // Session["PROFILE_IMG"] = img1;
                                }

                            }


                            ////Employeelnk.Visible = true;
                            ////lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");
                            ////Presidentlnk.Visible = false;
                            ////HRlnk.Visible = false;
                            ////Adminlnk.Visible = false;
                            ////SecretialLnk.Visible = false;

                            //////LblTitle.Text = "ESOP -  Employee Dashboard";
                            ////lnkAdmin.Visible = false;
                            ////lnkHrHead.Visible = false;
                            ////lnkPresident.Visible = false;
                            lnkEmployee.Visible = true;
                            ////lnksecretarial.Visible = false;
                            ////lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");
                        }


                    }
                    //Session["Return"] = null;
                    ShowTab_1();
                    ShowTab();
                }

                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                    //throw ex;
                }
            }
        }
        protected void lnkLogout_ServerClick(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

            Session["LoginId_encrypt"] = "";
            Session["LoginPassword_encrypt"] = "";
            Session["ConStr_encrypt"] = "";

            Response.Redirect("~/login.aspx", false);
        }


        protected void lnkEmployee_Click(object sender, EventArgs e)
        {
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary");

            Session["MasterRole"] = "Employee";
            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");
            Employeelnk.Visible = true;
            Presidentlnk.Visible = false;
            HRlnk.Visible = false;
            Chklnk.Visible = false;
            Adminlnk.Visible = false;
            lnkAdmin.Visible = false;
            lnkHrHead.Visible = false;
            lnkchecker.Visible = false;
            lnkPresident.Visible = false;
            lnksecretarial.Visible = false;

            Response.Redirect("~/employee-dashboard.aspx", false);

            Session["lnkDoc"] = "~/User Manual Docs/ESOP_Employee Flow.pdf";

        }

        protected void lnkPresident_Click(object sender, EventArgs e)
        {
            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary");
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");

            Session["MasterRole"] = "President";
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary active");
            Presidentlnk.Visible = true;
            Employeelnk.Visible = false;
            HRlnk.Visible = false;
            Chklnk.Visible = false;
            Adminlnk.Visible = false;

            Response.Redirect("~/president-dashboard.aspx", false);

            Session["lnkDoc"] = "~/User Manual Docs/ESOP_President Flow.pdf";
        }

        protected void lnkHrHead_Click(object sender, EventArgs e)
        {
            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary");
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");

            Session["MasterRole"] = "HR Head";
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary active");
            HRlnk.Visible = false;
            Chklnk.Visible = true;
            Presidentlnk.Visible = false;
            Employeelnk.Visible = false;
            Adminlnk.Visible = false;

            Response.Redirect("~/hr-dashboard.aspx", false);

            Session["lnkDoc"] = "~/User Manual Docs/ESOP_HRFlow.pdf";



        }

        protected void lnkAdmin_Click(object sender, EventArgs e)
        {
            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary");
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");

            Session["MasterRole"] = "Admin";
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary active");
            ////Adminlnk.Visible = true;
            ////Presidentlnk.Visible = false;
            ////HRlnk.Visible = false;
            ////Employeelnk.Visible = false;

            Adminlnk.Visible = false;
            //lnkAdmin.Attributes.Add("class", "btn btn-outline-primary active");
            Presidentlnk.Visible = false;
            HRlnk.Visible = false;
            Chklnk.Visible = false;
            Employeelnk.Visible = true;
            SecretialLnk.Visible = false;
            lnkAdmin.Visible = false;
            lnkHrHead.Visible = false;
            lnkchecker.Visible = false;
            lnkPresident.Visible = false;
            lnkEmployee.Visible = true;
            lnksecretarial.Visible = false;

            Response.Redirect("~/admin-dashboard.aspx", false);

            Session["lnkDoc"] = "~/User Manual Docs/ESOP_AdminFlow.pdf";


        }
        protected void lnkProxyLogOut_ServerClick(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Proxy"] != null)
            {
                Session["ECode"] = Convert.ToString(Session["Proxy"]);
            }
            else
            {
                //Session["ECode"] = Convert.ToString(Session["Proxy"]);
            }
            Session["Role"] = "Admin";
            Session["MasterRole"] = "Admin";
            Session.Remove("Proxy");
            Session["UserName"] = Convert.ToString(Session["ProxyName"]);
            Response.Redirect("~/admin-dashboard.aspx", false);
            Adminlnk.Visible = true;

            objcUserEntity.LoginID = Convert.ToString(Session["ECode"]);
            objcUserEntityRequest.UserEntity = objcUserEntity;

            DataSet ds1 = objcUserBAL.GetRole(objcUserEntityRequest);
            Session["Tab"] = ds1.Tables[2];
            ShowTab_1();
            ShowTab();

        }
        protected void lnkProxy_ServerClick(object sender, EventArgs e)
        {
            //HttpContext.Current.Session.Clear();
            //HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));


            //Response.Redirect("~/Proxy.aspx");

            btnClear_Click(new object(), new EventArgs());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShow();", true);
        }
        protected void btnFilter_Click_1(object sender, EventArgs e)
        {
            objEmpBo.ECode = txtEmpCode.Text;
            objEmpBo.Emp_Name = txtEmpName.Text;
            objEmpBo.Dept = ddlDept.SelectedValue != "0" ? ddlDept.SelectedValue : ""; // ddlDept.SelectedValue;
            objEmpBo.Band = ddlBand.SelectedValue != "0" ? ddlBand.SelectedValue : "";
            objEmpBo.Location = ddlLocation.SelectedValue != "0" ? ddlLocation.SelectedValue : "";
            DataSet ds = objbal.UserFilter(objEmpBo);
            if (ds.Tables.Count > 0)
            {
                //int count = ds.Tables[0].Rows.Count;
                //lbl_text.Text = "Filtered " + count + " Names";
                //ddlUserName.DataSource = ds.Tables[0];
                //ddlUserName.DataTextField = "USERNAME";
                //ddlUserName.DataValueField = "USERID";
                //ddlUserName.DataBind();
                //ddlUserName.Items.Insert(0, new ListItem("Select an Option", "0"));
                grdData.DataSource = ds.Tables[0];
                grdData.DataBind();
            }
            ViewState["Emp_filterRec"] = ds;

        }
        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUserName();
        }
        protected void FillUserName()
        {
            //objbo.Role_ID = Convert.ToInt32(ddlUser.SelectedItem.Value);
            DataSet ds = objbal.GetUserDropDown(objbo);
            //ddlUserName.DataSource = ds.Tables[0];
            if (ds.Tables.Count > 0)
            {
                //ddlUserName.DataTextField = "USERNAME";
                //ddlUserName.DataValueField = "USERID";
                //ddlUserName.DataBind();
                //ddlUserName.Items.Insert(0, new ListItem("", "0"));
            }

            if (ds.Tables.Count > 1)
            {
                ddlDept.DataSource = ds.Tables[1];
                ddlDept.DataTextField = "department";
                ddlDept.DataValueField = "ID";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, new ListItem("Department", "0"));
            }

            if (ds.Tables.Count > 1)
            {
                ddlBand.DataSource = ds.Tables[2];
                ddlBand.DataTextField = "bands";
                ddlBand.DataValueField = "ID";
                ddlBand.DataBind();
                ddlBand.Items.Insert(0, new ListItem("Bands", "0"));
            }
            if (ds.Tables.Count > 1)
            {
                ddlLocation.DataSource = ds.Tables[3];
                ddlLocation.DataTextField = "location";
                ddlLocation.DataValueField = "ID";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem("Location", "0"));
            }

        }
        protected void btnProxyLogin_Click(object sender, EventArgs e)
        {
            //if (ddlUserName.SelectedValue != "0")
            try
            {
                GetSelectedRecord();

                //string NameRole = ddlUserName.SelectedItem.Text;
                if (Session["Proxy"] is string)
                {

                }
                else
                {
                    Session["Proxy"] = Convert.ToString(Session["ECode"]);
                    Session["ProxyName"] = Convert.ToString(Session["UserName"]);
                }
                //Session["UserName"] = ddlUserName.SelectedItem.Text;
                Session["UserName"] = Convert.ToString(ViewState["empNameProxy"]);

                //objbo.EMP_ID = ddlUserName.SelectedValue;
                objbo.EMP_ID = Convert.ToString(ViewState["empCodeProxy"]);
                DataSet ds = objbal.GetUserDropDown(objbo);


                objcUserEntity.LoginID = objbo.EMP_ID;
                objcUserEntityRequest.UserEntity = objcUserEntity;

                DataSet ds1 = objcUserBAL.GetRole(objcUserEntityRequest);
                Session["Tab"] = ds1.Tables[2];

                Session["Role"] = Convert.ToString(ds1.Tables[2].Rows[0]["Role_ID"]);
                //Session["ECode"] = ddlUserName.SelectedValue.ToString();
                Session["ECode"] = Convert.ToString(ViewState["empCodeProxy"]);

                if (Convert.ToString(Session["Role"]) == "1")
                {
                    Response.Redirect("~/admin-dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "2")
                {
                    Response.Redirect("~/hr-dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "3")
                {
                    Response.Redirect("~/president-dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "4")
                {
                    Response.Redirect("~/employee-dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "5")
                {
                    Response.Redirect("~/Secretarial_Dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "6")
                {
                    Response.Redirect("~/Checker_Approvals.aspx", false);
                    //Response.Redirect("~/Checker_Approve_Reject.aspx", false);
                }
                //Session["MasterRole"] = ds1.Tables[2].Rows[0]["Role_ID"].ToString();
                Session["MasterRole"] = "";
                Session["Return"] = null;
                ShowTab_1();
                //ShowTab();
                Session["Return"] = null;
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }


        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //DivFilter.Style["display"] = "block";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //DivFilter.Style["display"] = "none";
            //FillUserName();
            //lbl_text.Text = "";
            //txtEmpCode.Text = "";
            //txtEmpName.Text = "";
            //ddlBand.SelectedIndex = 0;
            //ddlDept.SelectedIndex = 0;
            //ddlLocation.SelectedIndex = 0;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            FillUserName();
            lbl_text.Text = "";

            txtEmpCode.Text = "";
            txtEmpName.Text = "";
            ddlBand.SelectedIndex = 0;
            ddlDept.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            grdData.DataSource = null;
            grdData.DataBind();
        }

        protected void A5_ServerClick(object sender, EventArgs e)
        {

        }

        protected void lnksecretarial_Click(object sender, EventArgs e)
        {
            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary");
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");

            Session["MasterRole"] = "Secretrail";
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary active");
            SecretialLnk.Visible = true;
            Presidentlnk.Visible = false;
            Employeelnk.Visible = false;
            Adminlnk.Visible = false;

            Response.Redirect("~/Secretarial_Dashboard.aspx", false);

            Session["lnkDoc"] = "~/User Manual Docs/ESOP_Secretarial Flow.pdf";
        }
        private void GetSelectedRecord()
        {
            string ChkBox = "";
            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                RadioButton rb = (RadioButton)grdData.Rows[i].Cells[0].FindControl("rdbProxy");
                if (rb != null)
                {
                    if (rb.Checked)
                    {
                        HiddenField hf = (HiddenField)grdData.Rows[i].Cells[0].FindControl("HiddenField1");
                        Label grdEname = (Label)grdData.Rows[i].Cells[0].FindControl("lbl_emp_name");

                        if (hf != null)
                        {
                            ViewState["empCodeProxy"] = hf.Value;
                            ViewState["empNameProxy"] = grdEname.Text;
                            ChkBox = "Chked";
                        }
                        break;
                    }
                }
            }
            if (ChkBox == "")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select one option');", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clentscript", "alert('Please select one option');", true);
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
        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#myModal').modal('hide');", true);
        }

        protected void ShowTab()
        {
            if (Convert.ToString(Session["MasterRole"]) == "")
            {
                Session["MasterRole"] = role;
            }

            if (Convert.ToString(Session["MasterRole"]) == "Admin" || Convert.ToString(Session["MasterRole"]) == "1")
            {
                lnkAdmin.Attributes.Add("class", "btn btn-outline-primary active");

                Presidentlnk.Visible = false;
                Employeelnk.Visible = false;
                HRlnk.Visible = false;
                Chklnk.Visible = false;
                Adminlnk.Visible = true;
                SecretialLnk.Visible = false;
                Session["lnkDoc"] = "~/User Manual Docs/ESOP_AdminFlow.pdf";

            }
            else if (Convert.ToString(Session["MasterRole"]) == "HR Head" || Convert.ToString(Session["MasterRole"]) == "2")
            {
                lnkHrHead.Attributes.Add("class", "btn btn-outline-primary active");

                Presidentlnk.Visible = false;
                Employeelnk.Visible = false;
                HRlnk.Visible = true;
                Chklnk.Visible = false;
                Adminlnk.Visible = false;
                SecretialLnk.Visible = false;
                Session["lnkDoc"] = "~/User Manual Docs/ESOP_HRFlow.pdf";

            }
            else if (Convert.ToString(Session["MasterRole"]) == "President" || Convert.ToString(Session["MasterRole"]) == "3")
            {
                lnkPresident.Attributes.Add("class", "btn btn-outline-primary active");

                Presidentlnk.Visible = true;
                Employeelnk.Visible = false;
                HRlnk.Visible = false;
                Chklnk.Visible = false;
                Adminlnk.Visible = false;
                SecretialLnk.Visible = false;
                Session["lnkDoc"] = "~/User Manual Docs/ESOP_President Flow.pdf";

            }
            else if (Convert.ToString(Session["MasterRole"]) == "Secretrail" || Convert.ToString(Session["MasterRole"]) == "5")
            {
                lnksecretarial.Attributes.Add("class", "btn btn-outline-primary active");

                Presidentlnk.Visible = false;
                Employeelnk.Visible = false;
                HRlnk.Visible = false;
                Chklnk.Visible = false;
                Adminlnk.Visible = false;
                SecretialLnk.Visible = true;
                Session["lnkDoc"] = "~/User Manual Docs/ESOP_Secretarial Flow.pdf";

            }
            else if (Convert.ToString(Session["MasterRole"]) == "Employee" || Convert.ToString(Session["MasterRole"]) == "4")
            {
                lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");

                Presidentlnk.Visible = false;
                Employeelnk.Visible = true;
                HRlnk.Visible = false;
                Chklnk.Visible = false;
                Adminlnk.Visible = false;
                SecretialLnk.Visible = false;
                Session["lnkDoc"] = "~/User Manual Docs/ESOP_Employee Flow.pdf";

            }
            else if (Convert.ToString(Session["MasterRole"]) == "Checker" || Convert.ToString(Session["MasterRole"]) == "6")
            {
                lnkchecker.Attributes.Add("class", "btn btn-outline-primary active");

                Presidentlnk.Visible = false;
                Employeelnk.Visible = false;
                HRlnk.Visible = false;
                Chklnk.Visible = true;
                Adminlnk.Visible = false;
                SecretialLnk.Visible = false;
                Session["lnkDoc"] = "~/User Manual Docs/ESOP_Checker.pdf";

            }

            if (Convert.ToString(Session["MasterRole"]) == "")
            {
                if (role == "Admin" || role == "1")
                {
                    Session["lnkDoc"] = "~/User Manual Docs/ESOP_AdminFlow.pdf";
                }
                else if (role == "HR Head" || role == "2")
                {
                    Session["lnkDoc"] = "~/User Manual Docs/ESOP_HRFlow.pdf";
                }
                else if (role == "President" || role == "3")
                {
                    Session["lnkDoc"] = "~/User Manual Docs/ESOP_President Flow.pdf";
                }
                else if (role == "Employee" || role == "4")
                {
                    Session["lnkDoc"] = "~/User Manual Docs/ESOP_Employee Flow.pdf";
                }
                else if (role == "Secretrail" || role == "5")
                {
                    Session["lnkDoc"] = "~/User Manual Docs/ESOP_Secretarial Flow.pdf";
                }
                else if (role == "Checker" || role == "6")
                {
                    Session["lnkDoc"] = "~/User Manual Docs/ESOP_Checker.pdf";
                }
            }
        }

        protected void ShowTab_1()
        {
            Adminlnk.Visible = false;
            //lnkAdmin.Attributes.Add("class", "btn btn-outline-primary active");
            Presidentlnk.Visible = false;
            HRlnk.Visible = false;
            Chklnk.Visible = false;
            Employeelnk.Visible = false;
            SecretialLnk.Visible = false;
            lnkAdmin.Visible = false;
            lnkHrHead.Visible = false;
            lnkPresident.Visible = false;
            lnkEmployee.Visible = false;
            lnksecretarial.Visible = false;
            lnkchecker.Visible = false;


            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary");
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");

            DataTable dt = Session["Tab"] as DataTable;
            if (Session["Tab"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["Role_ID"]) == "1")
                    {
                        lnkAdmin.Visible = true;

                        if (i == 0 && Session["Return"] == null)
                        {
                            Adminlnk.Visible = true;
                            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary active");
                        }
                    }
                    else if (Convert.ToString(dt.Rows[i]["Role_ID"]) == "2")
                    {
                        lnkHrHead.Visible = true;

                        if (i == 0 && Session["Return"] == null)
                        {
                            HRlnk.Visible = true;
                            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary active");
                        }
                    }
                    else if (Convert.ToString(dt.Rows[i]["Role_ID"]) == "3")
                    {
                        lnkPresident.Visible = true;

                        if (i == 0 && Session["Return"] == null)
                        {
                            Presidentlnk.Visible = true;
                            lnkPresident.Attributes.Add("class", "btn btn-outline-primary active");
                        }
                    }
                    else if (Convert.ToString(dt.Rows[i]["Role_ID"]) == "4")
                    {
                        lnkEmployee.Visible = true;

                        if (i == 0 && Session["Return"] == null)
                        {
                            Employeelnk.Visible = true;
                            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary active");
                        }
                    }
                    else if (Convert.ToString(dt.Rows[i]["Role_ID"]) == "5")
                    {
                        lnksecretarial.Visible = true;
                        if (i == 0 && Session["Return"] == null)
                        {
                            SecretialLnk.Visible = true;
                            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary active");
                        }
                    }
                    else if (Convert.ToString(dt.Rows[i]["Role_ID"]) == "6")
                    {
                        lnkchecker.Visible = true;

                        if (i == 0 && Session["Return"] == null)
                        {
                            Chklnk.Visible = false;
                            lnkchecker.Attributes.Add("class", "btn btn-outline-primary active");
                        }
                    }
                }
                Session["Return"] = "Yes";
            }
        }

        protected void lnkDoc_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                string Role = Convert.ToString(Session["Role"]);
                string MasterRole = Convert.ToString(Session["MasterRole"]);

                filePath = Convert.ToString(Session["lnkDoc"]);
                //if (Role == "Admin" || MasterRole == "Admin")
                //{
                //    filePath = Server.MapPath("~/User Manual Docs/Admin.pdf");
                //}
                //else if (Role == "HR Head" || MasterRole == "HR Head")
                //{
                //    filePath = Server.MapPath("~/User Manual Docs/HR Head.pdf");
                //}
                //else if (Role == "President" || MasterRole == "President")
                //{
                //    filePath = Server.MapPath("~/User Manual Docs/President.pdf");
                //}
                //else if (Role == "Secretarial" || MasterRole == "Secretarial")
                //{
                //    filePath = Server.MapPath("~/User Manual Docs/Secretarial.pdf");
                //}
                //else if (Role == "Employee" || MasterRole == "Employee")
                //{
                //    filePath = Server.MapPath("~/User Manual Docs/Employee.pdf");
                //}

                Response.ContentType = Page.ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void lnkchecker_Click(object sender, EventArgs e)
        {
            lnkEmployee.Attributes.Add("class", "btn btn-outline-primary");
            lnkAdmin.Attributes.Add("class", "btn btn-outline-primary");
            lnkHrHead.Attributes.Add("class", "btn btn-outline-primary");
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary");
            lnkPresident.Attributes.Add("class", "btn btn-outline-primary");
            lnksecretarial.Attributes.Add("class", "btn btn-outline-primary");

            Session["MasterRole"] = "Checker";
            lnkchecker.Attributes.Add("class", "btn btn-outline-primary active");
            HRlnk.Visible = false;
            Chklnk.Visible = true;
            Presidentlnk.Visible = false;
            Employeelnk.Visible = false;
            Adminlnk.Visible = false;

            Response.Redirect("~/Checker_Approvals.aspx", false);
            //Response.Redirect("~/Checker_Approve_Reject.aspx", false);

            Session["lnkDoc"] = "~/User Manual Docs/ESOP_Checker.pdf";

        }
    }
}