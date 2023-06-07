using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESOP
{
    public partial class WriteLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static bool WriteLogFile(string strFileName, string strMessage)
        {
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/");
                //FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", Path.GetTempPath(), strFileName), FileMode.Append, FileAccess.Write);
                FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", System.Web.HttpContext.Current.Server.MapPath("~/"), strFileName), FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(strMessage);
                objStreamWriter.Close();
                objFilestream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}