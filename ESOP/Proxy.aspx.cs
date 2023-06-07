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
using System.Data.SqlClient;
using System.IO;
using ExcelDataReader;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ESOP
{
    public partial class Proxy : System.Web.UI.Page
    {
        string role;
        string gender;
        GrandCreationBO objbo = new GrandCreationBO();
        GrandCreationBAL objbal = new GrandCreationBAL();
        EmployeeBO objEmpBo = new EmployeeBO();
        EmployeeBAL objEmpBal = new EmployeeBAL();
        string PreviousPage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.ServerVariables["HTTP_REFERER"] != null && Request.ServerVariables["HTTP_REFERER"] != "http://localhost:20546/proxy")
            //{
            //    PreviousPage = Request.ServerVariables["HTTP_REFERER"];
            //}
            if (!IsPostBack)
            {
                DivFilter.Style["display"] = "none";
                FillUserName();
            }
        }

        protected void FillUserName()
        {
            //objbo.Role_ID = Convert.ToInt32(ddlUser.SelectedItem.Value);
            //DataSet ds = objbal.GetUserDropDown(objbo);
            //ddlUserName.DataSource = ds.Tables[0];
            //if (ds.Tables.Count > 0)
            //{
            //    ddlUserName.DataTextField = "USERNAME";
            //    ddlUserName.DataValueField = "USERID";
            //    ddlUserName.DataBind();
            //    //ddlUserName.Items.Insert(0, new ListItem("Select ROLE", "0"));
            //}

            //objbo.Role_ID = Convert.ToInt32(ddlUser.SelectedItem.Value);
            DataSet ds = objbal.GetUserDropDown(objbo);
            ddlUserName.DataSource = ds.Tables[0];
            if (ds.Tables.Count > 0)
            {
                ddlUserName.DataTextField = "USERNAME";
                ddlUserName.DataValueField = "USERID";
                ddlUserName.DataBind();
                ddlUserName.Items.Insert(0, new ListItem("", "0"));
            }

            if (ds.Tables.Count > 1)
            {
                ddlDept.DataSource = ds.Tables[1];
                ddlDept.DataTextField = "department";
                ddlDept.DataValueField = "ID";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, new ListItem("", "0"));
            }

            if (ds.Tables.Count > 1)
            {
                ddlBand.DataSource = ds.Tables[2];
                ddlBand.DataTextField = "bands";
                ddlBand.DataValueField = "ID";
                ddlBand.DataBind();
                ddlBand.Items.Insert(0, new ListItem("", "0"));
            }
            if (ds.Tables.Count > 1)
            {
                ddlDesignation.DataSource = ds.Tables[3];
                ddlDesignation.DataTextField = "designation";
                ddlDesignation.DataValueField = "ID";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("", "0"));
            }

        }

        protected void btnProxyLogin_Click(object sender, EventArgs e)
        {
            if (ddlUserName.SelectedValue != "0")
            {
                string NameRole = ddlUserName.SelectedItem.Text;
                if (Session["Proxy"] is string)
                {

                }
                else
                {
                    Session["Proxy"] = Session["ECode"].ToString();
                    Session["ProxyName"] = Session["UserName"].ToString();
                }
                Session["UserName"] = ddlUserName.SelectedItem.Text;

                int i = 0;
                string[] Role_Name = NameRole.Split('-');
                foreach (var word in Role_Name)
                {
                    if (i == 2)
                    {
                        Session["Role"] = word;
                    }
                    i++;
                }
                //Session["Role"] = ddlUser.SelectedItem.Text;

                Session["ECode"] = ddlUserName.SelectedValue.ToString();

                if (Convert.ToString(Session["Role"]) == "Admin")
                {
                    Response.Redirect("~/admin-dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "HR Head")
                {
                    Response.Redirect("~/hr-dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "President")
                {
                    Response.Redirect("~/president-dashboard.aspx", false);
                }
                if (Convert.ToString(Session["Role"]) == "Employee")
                {
                    Response.Redirect("~/employee-dashboard.aspx", false);
                }

                //Label lblUserVal = (Label)Page.Master.FindControl("lblProxy");
                //lblUserVal.Text = Session["Proxy"].ToString();

                //    ((Label)Master.FindControl("lblProxy")).Text = "Proxy";
            }
            else
            {
                lbl_text.Text = "Please select User Name";
            }

        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillUserName();
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            DivFilter.Style["display"] = "block";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DivFilter.Style["display"] = "none";
            btnClear_Click(new object(), new EventArgs());
            lbl_text.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmpCode.Text = "";
            txtEmpName.Text = "";
            ddlBand.SelectedIndex = 0;
            ddlDept.SelectedIndex = 0;
            ddlDesignation.SelectedIndex = 0;
            btnFilter_Click_1(new object(), new EventArgs());
            lbl_text.Text = "";
        }
        protected void btnFilter_Click_1(object sender, EventArgs e)
        {
            objEmpBo.ECode = txtEmpCode.Text;
            objEmpBo.Emp_Name = txtEmpName.Text;
            objEmpBo.Dept = ddlDept.SelectedItem.Text;
            objEmpBo.Band = ddlBand.SelectedItem.Text;
            objEmpBo.Designation = ddlDesignation.SelectedItem.Text;
            DataSet ds = objbal.UserFilter(objEmpBo);
            if (ds.Tables.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                lbl_text.Text = "Filtered " + count + " Names";
                ddlUserName.DataSource = ds.Tables[0];
                ddlUserName.DataTextField = "USERNAME";
                ddlUserName.DataValueField = "USERID";
                ddlUserName.DataBind();
                ddlUserName.Items.Insert(0, new ListItem("Select an Option", "0"));
            }

        }

        protected void btnPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(PreviousPage);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            
        }
    }
}