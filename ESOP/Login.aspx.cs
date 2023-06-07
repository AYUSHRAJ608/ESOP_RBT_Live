using ESOP_BAL;
using ESOP_BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Net;

namespace ESOP
{
    public partial class Login : System.Web.UI.Page
    {
        string strLDAPPath = System.Configuration.ConfigurationManager.AppSettings["ADConnection"];
        string domainName = ConfigurationManager.AppSettings.Get("DomainName").ToString();
        string LDAPPath = ConfigurationManager.AppSettings["ADSPath"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();

                string Username = txtUserid.Text;
                string Password = txtPassword.Text;

                //txtPassword.Text = CommonDAL.Encrypt(txtPassword.Text);
                UserBO objcUserEntity = new UserBO();
                cUserEntityRequest objcUserEntityRequest = new cUserEntityRequest();
                cUserEntityResponse objcUserEntityResponse = new cUserEntityResponse();
                UserBAL objcUserBAL = new UserBAL();

                objcUserEntity.LoginID = Username;
                objcUserEntity.Password = Password;
                objcUserEntityRequest.UserEntity = objcUserEntity;
                Session["UserName"] = Username;
                Session["LoginId"] = Username;
                Session["LoginPassword"] = Password;
                //if (true)
                //AuthenticateUser(strLDAPPath, objcUserEntity.LoginID, objcUserEntity.Password) ==
                if (IsNTAuthenticated(LDAPPath, domainName, objcUserEntity.LoginID, objcUserEntity.Password) == true)
                {
                    objcUserEntityResponse = objcUserBAL.chkLoginCredential(objcUserEntityRequest);
                    DataSet ds1 = objcUserBAL.GetRole(objcUserEntityRequest);
                    if (objcUserEntityResponse.lstcUserEntity.Count > 0)
                    {
                        Session["UserName"] = Convert.ToString(objcUserEntityResponse.lstcUserEntity.First().Emp_Name); //1;//
                        Session["Gender"] = objcUserEntityResponse.lstcUserEntity.First().gender;                                                                                         //  Session["UserID"] = Convert.ToString(objcUserEntityResponse.lstcUserEntity.First().UserID); //1;//
                                                                                                                                                                                          //Session["LastLogin"] = Convert.ToString(objcUserEntityResponse.lstcUserEntity.First().LastLoginTime);
                        Session["Role"] = Convert.ToString(objcUserEntityResponse.lstcUserEntity.First().RoleName);
                        //    Session["RoleID"] = Convert.ToString(objcUserEntityResponse.lstcUserEntity.First().RolePk);
                        //  Session["EmpId"] = Convert.ToString(objcUserEntityResponse.lstcUserEntity.First().EmpID);
                        Session["ECode"] = Convert.ToString(objcUserEntityResponse.lstcUserEntity.First().ECode); //1;//

                        InsertIPAddressDetails(objcUserEntity.LoginID);//29042021

                        Session["Tab"] = ds1.Tables[1];
                        Role(ds1);


                        //if (Convert.ToString(Session["Role"]) == "Admin")
                        //{
                        //    Response.Redirect("~/admin-dashboard.aspx", false);
                        //}
                        //if (Convert.ToString(Session["Role"]) == "HR Head")
                        //{
                        //    Response.Redirect("~/hr-dashboard.aspx", false);
                        //}
                        //if (Convert.ToString(Session["Role"]) == "President")
                        //{
                        //    Response.Redirect("~/president-dashboard.aspx", false);
                        //}
                        //if (Convert.ToString(Session["Role"]) == "Employee")
                        //{
                        //    Response.Redirect("~/employee-dashboard.aspx", false);
                        //}
                        //if (Convert.ToString(Session["Role"]) == "Secretarial")
                        //{
                        //    Response.Redirect("~/Employee-secretarial.aspx", false);
                        //}
                    }
                    else
                    {
                        string errmsg = "Please enter valid username and password";
                        Common.ShowJavascriptAlert(errmsg);
                        txtUserid.Text = "";
                    }
                    //Response.Redirect("~/grant-creation", false);
                }
                else
                {
                    string errmsg = "Please enter valid username and password";
                    Common.ShowJavascriptAlert(errmsg);
                    txtUserid.Text = "";
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Dashboard.aspx", false);
                LogException(ex);
                //Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        public static void LogException(Exception Ex)
        {
            string filePath = HttpContext.Current.Server.MapPath("~"); //Convert.ToString(ConfigurationManager.AppSettings["ErrorLogPath"]).Trim();

            var dir = filePath;  // folder location
            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);
            // use Path.Combine to combine 2 strings to a path
            string str;
            str = "Message :" + Ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + Ex.StackTrace + "" + Environment.NewLine + "Date :" + DateTime.Now.ToString();
            str += Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine;
            File.WriteAllText(Path.Combine(dir, "log.txt"), str);


        }
        public Boolean AuthenticateUser(String path, string username, string password)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["CheckLDAP"] == "true")
                {
                    DirectoryEntry de = new DirectoryEntry(path, username, password);
                    DirectorySearcher ds = new DirectorySearcher(de);
                    var entry = ds.FindOne().GetDirectoryEntry();
                    if (entry.Properties.Count > 0)
                    {
                        //    Common.ShowJavascriptAlert("Success in directory");

                        return true;
                    }
                    else
                    {
                        // Common.ShowJavascriptAlert("Failure username password");                    
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                //LblErr.Text = ex.Message.ToString();
                return false;
            }

        }
        public bool IsNTAuthenticated(string path, string domain, string userName, string password)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["CheckLDAP"] == "true")
                {

                    string domainAndUsername = domain + @"\" + userName;
                    DirectoryEntry entry = new DirectoryEntry(path, domainAndUsername, password);
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + userName + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();
                    if (result != null)
                    {
                        path = result.Path;
                        string filterAttribute = (string)result.Properties["cn"][0];
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        //Below method is created by YogeshT on 29042021 for capturing ip with login id
        public void InsertIPAddressDetails(string LoginID)
        {
            try
            {
                UserBO objcUserEntity = new UserBO();
                cUserEntityRequest objcUserEntityRequest = new cUserEntityRequest();
                cUserEntityResponse objcUserEntityResponse = new cUserEntityResponse();
                UserBAL objcUserBAL = new UserBAL();

                string strHostName = "";
                string IPAddress = "";
                strHostName = System.Net.Dns.GetHostName();
                IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                IPAddress[] addr = ipEntry.AddressList;

                IPAddress = addr[addr.Length - 1].ToString();

                objcUserEntity.LoginID = LoginID;
                objcUserEntity.IPAddress = IPAddress;
                objcUserEntityRequest.UserEntity = objcUserEntity;

                objcUserBAL.InsertIPAddressDetails(objcUserEntityRequest);

                //Session["SeverIP"] = Request.ServerVariables["LOCAL_ADDR"];

            }
            catch (Exception ex)
            { throw ex; }

        }

        private void Role(DataSet ds_1)
        {
            if (ds_1.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds_1.Tables[1];

                if (Convert.ToInt32(dt.Rows[0][2].ToString()) == 1)
                {
                    Response.Redirect("~/admin-dashboard.aspx", false);
                    Session["Role"] = "Admin";
                }
                if (Convert.ToInt32(dt.Rows[0][2].ToString()) == 2)
                {
                    Response.Redirect("~/hr-dashboard.aspx", false);
                    Session["Role"] = "HR Head";
                }
                if (Convert.ToInt32(dt.Rows[0][2].ToString()) == 3)
                {
                    Response.Redirect("~/president-dashboard.aspx", false);
                    Session["Role"] = "President";
                }
                if (Convert.ToInt32(dt.Rows[0][2].ToString()) == 4)
                {
                    Response.Redirect("~/employee-dashboard.aspx", false);
                    Session["Role"] = "Employee";
                }
                if (Convert.ToInt32(dt.Rows[0][2].ToString()) == 5)
                {
                    Response.Redirect("~/Secretarial_Approvals.aspx", false);
                    Session["Role"] = "Secretarial";
                }
                if (Convert.ToInt32(dt.Rows[0][2].ToString()) == 6)
                {
                    Response.Redirect("~/Checker_Approve_Reject.aspx", false);
                    Session["Role"] = "Checker";
                }

            }
        }
    }
}