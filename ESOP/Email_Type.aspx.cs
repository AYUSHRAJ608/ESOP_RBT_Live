using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESOP_BAL;
using ESOP_BO;
using System.Data;

namespace ESOP
{
    public partial class Email_Type : System.Web.UI.Page
    {
        cEmailEntityRequest req = new cEmailEntityRequest();
        EMailBO em = new EMailBO();
        EMailBAL ebal = new EMailBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TypeID"] = null;
            Session["EMID"] = null;
            if (!IsPostBack)
            {
                bindGrid("SelectType",null,  grdEmailType);
                bindDropdown();
            }
            Session["Left"] = "Upload";
            Session["Header"] = "Admin";
        }
         public void bindGrid(string Em_Action, string TypeID,GridView grdEmail)
        {
            try
            {
                em.Em_Action = Em_Action;
                em.Em_Type_ID = TypeID;
                req.EmailEntity = em;
                DataSet ds = ebal.insertEmail(req);
                grdEmail.DataSource = ds.Tables[0];
                grdEmail.DataBind();       //setHyperLink();
            }
            catch (Exception ex)
            {
                //Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void grdEmailType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                Label typeID = (Label)e.Row.FindControl("lblCode");
                GridView gv = (GridView)e.Row.FindControl("grdEmail");
               
                bindGrid("SelectEmail", typeID.Text, gv);
            }
        }

        protected void grdEmail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hyplDocView = (HyperLink)e.Row.FindControl("hypLnkSM");
                Label typeID = (Label)e.Row.FindControl("lblCodeID");
                Label EmID = (Label)e.Row.FindControl("lblEMID");
                //Session["TypeID"] = typeID.Text;
                //Session["EmID"] = EmID.Text;
                hyplDocView.NavigateUrl = String.Format("./Email_Notification.aspx?TypeID=" + typeID.Text+"&EMID="+ EmID.Text);
                Context.ApplicationInstance.CompleteRequest();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }

        }

        protected void btnAddGoalNew_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string typeID = btn.CommandArgument;
            Session["TypeID"] = typeID;
            Session["EMID"] = null;
            Response.Redirect("Email_Notification.aspx?TypeID=" + typeID);

        }

        protected void btnAddScore_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalSub();", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            em.Em_Action = "InsertType";
            em.Em_Type = txtType.Text;            
            em.EM_CretaedBy = Convert.ToString(Session["EmpId"]);
            req.EmailEntity = em;
            DataSet ds = ebal.insertEmail(req);
            bindDropdown();
            bindGrid("SelectType", null, grdEmailType);

        }
        public void bindDropdown()
        {
            em.Em_Action = "SelectType";
            req.EmailEntity = em;
            DataSet ds = ebal.insertEmail(req);
            ddlType.DataSource = ds.Tables[0];
            ddlType.DataTextField = "EMAIL_TYPE_NAME";
            ddlType.DataValueField = "EMAIL_TYPE_ID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("Select", "0"));
            
        }

        protected void btnSubSave_Click(object sender, EventArgs e)
        {
            em.Em_Action = "InsertSubType";
            em.Em_Type_ID = ddlType.SelectedValue;
            em.Em_Sub_Type = txtSubType.Text;
            em.EM_CretaedBy = Convert.ToString(Session["EmpId"]);
            req.EmailEntity = em;
            DataSet ds = ebal.insertEmail(req);

        }
        protected void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)sender;
                GridViewRow row = (GridViewRow)cb.NamingContainer;
                if (row != null)
                {
                    int rowindex = row.RowIndex;
                    em.Em_Type_ID = grdEmailType.DataKeys[rowindex].Values[0].ToString();
                    em.Em_Action = "UpdateStatusType";
                    //LetterConfigBO.Modified_BY = Convert.ToString(Session["ECode"]);
                    //LetterConfigBO.Mode = "IsActive";
                    if (cb.Checked)
                    {
                        em.Em_Status = "Y";
                    }
                    else
                    {
                        em.Em_Status = "N";
                    }
                    em.EM_CretaedBy = Convert.ToString(Session["EmpId"]);
                    req.EmailEntity = em;
                    DataSet ds = ebal.insertEmail(req);
                    grdEmailType.DataSource = ds.Tables[0];
                    grdEmailType.DataBind();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }


        }

    }
}