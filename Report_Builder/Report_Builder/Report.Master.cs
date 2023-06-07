using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report_Builder
{
    public partial class Report : System.Web.UI.MasterPage
    {
        string rolename;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = (string)Session["UserName"];
            //lblUser.Text = Request.QueryString["LoginId"].ToString().Replace('.',' ').Replace('1',' ');
            //rolename = Session["LoginRole"].ToString().ToUpper();

            //if(rolename == "USER")
            //{
            //    li_createRpt.Visible = false;
            //    li_createRpt_mob.Visible = false;

            //    li_ShareRpt.Visible = false;
            //    li_ShareRpt_mob.Visible = false;
            //}
            //else
            //{
            //    li_createRpt.Visible = true;
            //    li_createRpt_mob.Visible = true;

            //    li_ShareRpt.Visible = true;
            //    li_ShareRpt_mob.Visible = true;

            //    li_dash.Visible = true;
            //    li_dash_mob.Visible = true;
            //}
        }

        #region Events Declarations 
        //NOT IN USE
        ////protected void navh1_Click(object sender, EventArgs e)
        ////{
        ////    Response.Redirect("~/Dashboard.aspx");
        ////}
        ////protected void navh2_Click(object sender, EventArgs e)
        ////{           
        ////    Response.Redirect("~/CreateReport.aspx");
        ////}
        ////protected void navh3_Click(object sender, EventArgs e)
        ////{
        ////    Response.Redirect("~/SharedRpt.aspx");
        ////}
        #endregion Events Declarations
    }
}