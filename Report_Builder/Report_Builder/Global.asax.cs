using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Report_Builder
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{
        //    if (Session["AppConnectionstring"] != null)
        //    {
        //        if (Session["AppConnectionstring"].ToString() == "PMS")
        //        {
        //            Application["VariableName"] = ConfigurationManager.ConnectionStrings["SQLConStringPMS"].ConnectionString;
        //        }
        //        if (Session["AppConnectionstring"].ToString() == "ESOP")
        //        {
        //            Application["VariableName"] = ConfigurationManager.ConnectionStrings["SQLConStringESOP"].ConnectionString;
        //        }
        //    }
        //}   

    }
}