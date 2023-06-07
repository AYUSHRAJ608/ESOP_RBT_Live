using ESOP_BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;

namespace ESOP
{
    public class Common
    {
        public static void ShowJavascriptAlert(string sMessage)
        {
            sMessage = "alert('" + sMessage.Replace("'", @"\'").Replace("\n", @"\n") + "');";

            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                //page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", sMessage, true);
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alert", sMessage, true);
            }
            //ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", sMessage, true);
        }

        public static bool ErrorLogging(string PageName, string MethodName, string exMsg, string exstack)
        {
            CommonBAL  objMasterBAL = new CommonBAL();
            return objMasterBAL.LogExceptionDB(PageName, MethodName, exMsg, exstack);
        }
        public static void UploadFtpFile(string fileName, string F_Path)
        {
            string UserName = System.Configuration.ConfigurationManager.AppSettings["LinK_UserName"];
            string UserPassword = System.Configuration.ConfigurationManager.AppSettings["Link_UserPassword"];
            string Link = System.Configuration.ConfigurationManager.AppSettings["Link"];

            WebClient client = new WebClient();
            //NetworkCredential nc = new NetworkCredential("adms.dotnet2", "Clover@1234");
            //Uri addy = new Uri(@"\\192.168.7.199\" + fileName);
            NetworkCredential nc = new NetworkCredential(UserName, UserPassword);
            Uri addy = new Uri(Link + fileName);
            client.Credentials = nc;
            byte[] arrReturn = client.UploadFile(addy, F_Path);
        }
        public static DataSet Execute_Query(string Query)
        {
            CommonBAL objMasterBAL = new CommonBAL();
            return objMasterBAL.Execute_Query(Query);
        }
    }
}