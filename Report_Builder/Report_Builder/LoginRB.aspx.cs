using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity_REPORT;
using BAL_REPORT;
using System.Configuration;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Report_Builder
{
    public partial class LoginRB : System.Web.UI.Page
    {
        ReportBAL objRpt_BAL = new ReportBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            BtnSubmit_Click(sender, e);
        }

        #region Events Declarations
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Session["AppConnectionstring"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["ConString"]));
                LoginBO ObjBo = new LoginBO();
                LoginBAL ObjBAL = new LoginBAL();
                objRpt_BAL.GetConnString(Session["AppConnectionstring"].ToString());

                ObjBo.EMP_ID = Decrypt(HttpUtility.UrlDecode(Request.QueryString["UserName"]));
                ObjBo.EMP_Password = Decrypt(HttpUtility.UrlDecode(Request.QueryString["Pass"]));
                DataSet DsLogin = ObjBAL.Validuser(ObjBo);
                if (DsLogin.Tables[0].Rows.Count > 0)
                {
                    Session["UserName"] = removeSalutation(DsLogin.Tables[0].Rows[0]["USERNAME"].ToString());
                    Session["EMPID"] = DsLogin.Tables[0].Rows[0]["USERID"].ToString();

                    Response.Redirect("Dashboard.aspx");
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('Invalid Login Credentials!!');", true);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Events Declarations

        #region Method Declarations
        //Added by Bhushan on 07-06-2021 to remove salutation from Employee Name
        public string removeSalutation(string s)
        {
            string str = string.Empty;
            if (s.Contains("Mrs."))
            {
                str = s.Replace("Mrs.", "");
            }
            else if (s.Contains("Mrs"))
            {
                str = s.Replace("Mrs", "");
            }
            else if (s.Contains("Mr."))
            {
                str = s.Replace("Mr.", "");
            }
            else if (s.Contains("Mr"))
            {
                str = s.Replace("Mr", "");
            }
            else if (s.Contains("Dr."))
            {
                str = s.Replace("Dr.", "");
            }
            else if (s.Contains("Dr"))
            {
                str = s.Replace("Dr", "");
            }
            else if (s.Contains("Ms."))
            {
                str = s.Replace("Ms.", "");
            }
            else if (s.Contains("Ms"))
            {
                str = s.Replace("Ms", "");
            }
            else if (s.Contains("Miss."))
            {
                str = s.Replace("Miss.", "");
            }
            else if (s.Contains("Miss"))
            {
                str = s.Replace("Miss", "");
            }
            else if (s.Contains("MRS."))
            {
                str = s.Replace("MRS.", "");
            }
            else if (s.Contains("MRS"))
            {
                str = s.Replace("MRS", "");
            }
            else if (s.Contains("MR."))
            {
                str = s.Replace("MR.", "");
            }
            else if (s.Contains("MR"))
            {
                str = s.Replace("MR", "");
            }
            else if (s.Contains("DR."))
            {
                str = s.Replace("DR.", "");
            }
            else if (s.Contains("DR"))
            {
                str = s.Replace("DR", "");
            }
            else if (s.Contains("MS."))
            {
                str = s.Replace("MS.", "");
            }
            else if (s.Contains("MS"))
            {
                str = s.Replace("MS", "");
            }
            else if (s.Contains("MISS."))
            {
                str = s.Replace("MISS.", "");
            }
            else if (s.Contains("MISS"))
            {
                str = s.Replace("MISS", "");
            }
            else
            {
                str = s;
            }
            return str;
        }
        //End
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
        #endregion Method Declarations
    }
}