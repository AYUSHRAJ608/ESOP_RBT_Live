using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using System.Data;
using System.Text;

namespace ESOP
{
    public partial class EncryptDecrypt : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string EncryptCaseID(string UserName, string EmpID, string Constring)
        {
            BEncyptionDecrption objEncrypt = new BEncyptionDecrption();
            string result = string.Empty;
            try
            {
                result = "UserName=" + HttpUtility.UrlEncode(objEncrypt.Encrypt(Convert.ToString(UserName)))+ "&EmpID=" + HttpUtility.UrlEncode(objEncrypt.Encrypt(Convert.ToString(EmpID)))+ "&Constring=" + HttpUtility.UrlEncode(objEncrypt.Encrypt(Convert.ToString(Constring)));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}