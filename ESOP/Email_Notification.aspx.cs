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
    public partial class Email_Notification : System.Web.UI.Page
    {
        cEmailEntityRequest req = new cEmailEntityRequest();
        EMailBO em = new EMailBO();
        EMailBAL ebal = new EMailBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //String TypeID = Convert.ToString(Request.QueryString["TypeID"]);
                //String EMID = Convert.ToString(Request.QueryString["EMID"]);

                string TypeID = Convert.ToString(Session["TypeID"]);
                if (TypeID == "")
                {
                    TypeID = Convert.ToString(Request.QueryString["TypeID"]);
                }
                string EMID = Convert.ToString(Session["EMID"]);
                if (EMID == "")
                {
                    EMID = Convert.ToString(Request.QueryString["EMID"]);
                }
                if (!String.IsNullOrEmpty(EMID))
                {
                    bindData(TypeID, EMID);
                }
                bindDropdown(TypeID);
                ViewState["typeID"] = TypeID;
                ViewState["EMID"] = EMID;
                GetEmailID();
                LoadAddCCDdl();
            }
        }
        public void bindData(String TypeID, String EMID)
        {
            try
            {
                em.Em_Action = "SelectEmailByID";
                em.Em_Type_ID = TypeID;
                em.Em_ID = EMID;
                req.EmailEntity = em;
                DataSet ds = ebal.insertEmail(req);
                txtCC.Text = ds.Tables[0].Rows[0]["EM_CC_ID"].ToString();
                txtSubject.Text = ds.Tables[0].Rows[0]["EM_SUB"].ToString();
                txtBCC.Text = ds.Tables[0].Rows[0]["EM_BCC_ID"].ToString();
                myArea3.Text = ds.Tables[0].Rows[0]["EM_Body"].ToString();
                txtFrom.Text = ds.Tables[0].Rows[0]["EM_FROM_ID"].ToString();
                string strType = ds.Tables[0].Rows[0]["EM_SUB_TYPE"].ToString();
                ddlType.SelectedValue = strType;
                ddlType.SelectedValue = strType;
                String strchk = ds.Tables[0].Rows[0]["ISACTIVE"].ToString();
                if (strchk == "true")
                {
                    chkOnOff1.Checked = true;
                }
                else
                {
                    chkOnOff1.Checked = false;
                }

                txtEmailType.Text = ds.Tables[0].Rows[0]["EMAIL_TYPE_NAME"].ToString();
                ddlType.Enabled = false;
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
        public void bindDropdown(String TypeID)
        {
            em.Em_Action = "getSubType";
            em.Em_Type_ID = TypeID;
            req.EmailEntity = em;
            DataSet ds = ebal.insertEmail(req);
            ddlType.DataSource = ds.Tables[0];
            ddlType.DataTextField = "EMAIL_SUB_TYPE_NAME";
            ddlType.DataValueField = "EMAIL_SUB_TYPE_ID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("Select", "0"));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtEmailType.Text = ds.Tables[0].Rows[0]["EMAIL_TYPE_NAME"].ToString();
            }
            DataSet ds1 = ebal.getDropDown();
            em.Em_Action = "getfieldType";
            em.Em_Type = txtEmailType.Text;
            req.EmailEntity = em;
            DataSet ds2 = ebal.insertEmail(req);
            ddlfieldType.DataSource = ds2.Tables[0];
            ddlfieldType.DataTextField = "FIELD";
            ddlfieldType.DataValueField = "FIELD";
            ddlfieldType.DataBind();

        }

        [System.Web.Services.WebMethod]
        public static List<string> SearchEmployeeHOD(string prefixText, int count)
        {
            EmployeeBAL objEmpBAL = new EmployeeBAL();
            cEmployeeEntityRequest objEmprequest = new cEmployeeEntityRequest();

            List<string> empResult = new List<string>();
            DataTable EmpDT = new DataTable();

            DataSet ds = objEmpBAL.getEmp(prefixText, "HOD");

            EmpDT = ds.Tables[0];
            DataRow[] dr = EmpDT.Select("");
            if (dr.Length != 0)
            {
                for (int i = 0; i <= dr.Length - 1; i++)
                {
                    //empResult.Add(String.Format("{0}-{1}", dr[i]["CPC_USER_NAME"].ToString(), dr[i]["CPC_USER_ID"].ToString()));
                    string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[i]["EMP_NAME"].ToString(), dr[i]["EMAIL_ID"].ToString());
                    empResult.Add(item);
                }
            }
            return empResult;
        }

        [System.Web.Services.WebMethod]
        public static List<string> SearchEmployeeRev(string prefixText, int count)
        {
            EmployeeBAL objEmpBAL = new EmployeeBAL();
            cEmployeeEntityRequest objEmprequest = new cEmployeeEntityRequest();

            List<string> empResult = new List<string>();
            DataTable EmpDT = new DataTable();
            DataSet ds = objEmpBAL.getEmp(prefixText, "REV");

            EmpDT = ds.Tables[0];
            DataRow[] dr = EmpDT.Select("");
            if (dr.Length != 0)
            {
                for (int i = 0; i <= dr.Length - 1; i++)
                {
                    //empResult.Add(String.Format("{0}-{1}", dr[i]["CPC_USER_NAME"].ToString(), dr[i]["CPC_USER_ID"].ToString()));
                    string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[i]["EMP_NAME"].ToString(), dr[i]["EMAIL_ID"].ToString());
                    empResult.Add(item);
                }
            }
            return empResult;
        }

        [System.Web.Services.WebMethod]
        public static List<string> SearchEmployeeMx(string prefixText, int count)
        {
            EmployeeBAL objEmpBAL = new EmployeeBAL();
            cEmployeeEntityRequest objEmprequest = new cEmployeeEntityRequest();

            List<string> empResult = new List<string>();
            DataTable EmpDT = new DataTable();
            DataSet ds = objEmpBAL.getEmp(prefixText, "MAT");

            EmpDT = ds.Tables[0];
            DataRow[] dr = EmpDT.Select("");
            if (dr.Length != 0)
            {
                for (int i = 0; i <= dr.Length - 1; i++)
                {
                    //empResult.Add(String.Format("{0}-{1}", dr[i]["CPC_USER_NAME"].ToString(), dr[i]["CPC_USER_ID"].ToString()));
                    string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[i]["EMP_NAME"].ToString(), dr[i]["EMAIL_ID"].ToString());
                    empResult.Add(item);
                }
            }
            return empResult;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String msg = "";
            em.Em_Type = Convert.ToString(ViewState["typeID"]);
            em.Em_Sub_Type = ddlType.SelectedValue;
            em.Em_Sub = txtSubject.Text;
            em.Em_CC_ID = txtCC.Text;
            em.Em_BCC_ID = txtBCC.Text;
            em.Em_Body = myArea3.Text;
            em.EM_From_ID = txtFrom.Text;
            string EMID = Convert.ToString(ViewState["EMID"]);
            em.Em_Status = (chkOnOff1.Checked == true ? "Y" : "N");
            if (String.IsNullOrEmpty(EMID))
            {
                em.Em_Action = "Insert";
                msg = "Email Saved Successfully";
            }
            else
            {
                em.Em_Action = "Update";
                em.Em_ID = Convert.ToString(ViewState["EMID"]);
                msg = "Email Updated Successfully";
            }
            em.EM_CretaedBy = Convert.ToString(Session["EmpId"]);
            req.EmailEntity = em;
            DataSet ds = ebal.insertEmail(req);
            ClearInputs(Page.Controls);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('" + msg + "');window.location='Email_Type.aspx'", true);
            //Response.Redirect("Email_Type.aspx");

        }

        protected void LoadAddCCDdl()
        {
            DataSet ds = ebal.GetAddCC();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAddCC.DataSource = ds.Tables[0];
                ddlAddCC.DataTextField = "Text";
                ddlAddCC.DataValueField = "Value";
                ddlAddCC.DataBind();
                ddlAddCC.Items.Insert(0, new ListItem("Select", "0"));
            }

        }

        protected void ddlAddCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsEmailId = ebal.GetEmailID();
            String txtCCValue = txtCC.Text.Trim();
            int i = 9;
            if (ddlAddCC.SelectedValue.ToString().Trim().Equals("1") && dsEmailId.Tables[0]?.Rows.Count > 0)
            {
                 i = 0;
            }
            if (ddlAddCC.SelectedValue.ToString().Trim().Equals("2") && dsEmailId.Tables[1]?.Rows.Count > 0)
            {
                i = 1;
            }
            else if (ddlAddCC.SelectedValue.ToString().Trim().Equals("3") && dsEmailId.Tables[2]?.Rows.Count > 0)
            {
                i = 2;
            }
            else if (ddlAddCC.SelectedValue.ToString().Trim().Equals("6") && dsEmailId.Tables[3]?.Rows.Count > 0)
            {
                i = 3;
            }

            if (i!=9)
            {
                foreach (DataRow dr in dsEmailId.Tables[i]?.Rows)
                {
                    string item = dr["Emailid"]?.ToString();
                    if (txtCC.Text.ToString() != "")
                    {
                        if (!txtCCValue.Contains(item))
                        {
                            if (txtCC.Text.Substring(txtCC.Text.Length - 1) == ";")
                            {
                                txtCC.Text = txtCC.Text + item + ";";
                            }
                            else
                            {
                                txtCC.Text = txtCC.Text + ";" + item + ";";
                            }
                        }
                    }
                    else
                    {
                        txtCC.Text = item + ";";
                    }
                }
            }
            ddlAddCC.SelectedIndex = 0;
        }

        protected void GetEmailID()
        {
            //dsEmailId = ebal.GetEmailID();
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    ddlHRHead.DataSource = ds.Tables[1];
            //    ddlHRHead.DataTextField = "UserName";
            //    ddlHRHead.DataValueField = "Emailid";
            //    ddlHRHead.DataBind();
            //    ddlHRHead.Items.Insert(0, new ListItem("Select Email", "0"));
            //}
            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    ddlPresident.DataSource = ds.Tables[2];
            //    ddlPresident.DataTextField = "UserName";
            //    ddlPresident.DataValueField = "Emailid";
            //    ddlPresident.DataBind();
            //    ddlPresident.Items.Insert(0, new ListItem("Select Email", "0"));
            //}

            //if (ds.Tables[3].Rows.Count > 0)
            //{
            //    ddlEmployee.DataSource = ds.Tables[3];
            //    ddlEmployee.DataTextField = "UserName";
            //    ddlEmployee.DataValueField = "Emailid";
            //    ddlEmployee.DataBind();
            //    ddlEmployee.Items.Insert(0, new ListItem("Select Email", "0"));
            //}
        }

        protected void ddlHRHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtCC.Text.ToString() != "")
            //{
            //    if (txtCC.Text.Substring(txtCC.Text.Length - 1) == ";")
            //    {
            //        txtCC.Text = txtCC.Text + ddlHRHead.SelectedValue.ToString() + ";";
            //    }
            //    else
            //    {
            //        txtCC.Text = txtCC.Text + ";" + ddlHRHead.SelectedValue.ToString() + ";";
            //    }
            //}
            //else
            //{
            //    txtCC.Text = ddlHRHead.SelectedValue.ToString() + ";";
            //}

            //ddlHRHead.SelectedIndex = 0;
        }

        protected void ddlPresident_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtCC.Text.ToString() != "")
            //{
            //    if (txtCC.Text.Substring(txtCC.Text.Length - 1) == ";")
            //    {
            //        txtCC.Text = txtCC.Text + ddlPresident.SelectedValue.ToString() + ";";
            //    }
            //    else
            //    {
            //        txtCC.Text = txtCC.Text + ";" + ddlPresident.SelectedValue.ToString() + ";";
            //    }
            //}
            //else
            //{
            //    txtCC.Text = ddlPresident.SelectedValue.ToString() + ";";
            //}
           // ddlPresident.SelectedIndex = 0;
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtCC.Text.ToString() != "")
            //{
            //    if (txtCC.Text.Substring(txtCC.Text.Length - 1) == ";")
            //    {
            //        txtCC.Text = txtCC.Text + ddlEmployee.SelectedValue.ToString() + ";";
            //    }
            //    else
            //    {
            //        txtCC.Text = txtCC.Text + ";" + ddlEmployee.SelectedValue.ToString() + ";";
            //    }
            //}
            //else
            //{
            //    txtCC.Text = ddlEmployee.SelectedValue.ToString() + ";";
            //}

            //ddlEmployee.SelectedIndex = 0;
        }
        protected void ClearInputs(ControlCollection ctrls)
        {

            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else
                if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);
            }

        }
        protected void ddlfieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            myArea3.Text += ddlfieldType.SelectedValue;
        }
    }
}