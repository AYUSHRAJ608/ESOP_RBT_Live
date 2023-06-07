using ESOP_BAL;
using ESOP_BO;
using it = iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace ESOP
{
    public partial class FMVCreation_Master : System.Web.UI.Page
    {
        FMVCreationBO objbo = new FMVCreationBO();
        FMVCreationBAL objbal = new FMVCreationBAL();
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtvaldate.Attributes.Add("readonly", "readonly");
            txtvalidupto.Attributes.Add("readonly", "readonly");
            showmsg.InnerText = "";
            // (TextBox)GrvPendingforApproval.Rows[Convert.ToInt32(gvrow.RowIndex)].FindControl("TxtRemarkPend_Approval");
            if (!IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();


                bindfmvGrid();
                bindvaluationddl();

                // txtvaldate.Attributes["min"] = DateTime.Now.ToString("dd-mm-yyyy");
            }
            else
            {

                if (Convert.ToString(ViewState["ViewStateId"]) != Convert.ToString(Session["SessionId"]))
                {
                    IsPageRefresh = true;
                }
                Session["SessionId"] = System.Guid.NewGuid().ToString();
                ViewState["ViewStateId"] = Session["SessionId"].ToString();
            }
        }

        private void bindvaluationddl()
        {
            try
            {
                DataTable ds = objbal.getvaluedbyddl(objbo);
                if (ds.Rows.Count > 0)
                {
                    ddlvaluedby.DataSource = ds;
                    ddlvaluedby.DataTextField = "Valued_By";
                    ddlvaluedby.DataValueField = "AGENCY_ID";
                    ddlvaluedby.DataBind();
                    ddlvaluedby.Items.Insert(0, new ListItem("Select", "0"));


                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        private void bindfmvGrid()
        {
            try
            {
                DataSet ds = objbal.getfmv(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdfmv.DataSource = ds.Tables[0];
                    grdfmv.DataBind();
                    // Session["Getfmv"] = ds.Tables[0];

                    grdfmv.UseAccessibleHeader = true;
                    grdfmv.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                else
                {
                    grdfmv.DataSource = ds.Tables[0];
                    grdfmv.DataBind();
                    // Session["Getfmv"] = null;
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        private void clearcontrol()
        {
            txtfmvprice.Text = txtvaldate.Text = txtvalidupto.Text = string.Empty;

            ddlvaluedby.SelectedIndex = -1;
        }

        protected void btncreatefmv_Click(object sender, EventArgs e)
        {
            try
            {

                if (IsPageRefresh)
                {
                    return;
                }
                if (FileUpload1.FileName != "")
                {
                    FileUpload1.SaveAs(System.IO.Path.Combine(Server.MapPath("Fmv_excel"), FileUpload1.FileName));
                }
                else { }
                // string FullFilename = hiddenControl.Value;
                //  ViewState["file"] = FullFilename;
                objbo.VALUATION_DATE = Convert.ToDateTime(txtvaldate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objbo.VALID_UPTO_DATE = Convert.ToDateTime(txtvalidupto.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                objbo.FMV_PRICE = txtfmvprice.Text;
                objbo.VALUED_BY = ddlvaluedby.SelectedValue.ToString();
                if (FileUpload1.FileName != "")
                {
                    objbo.UPLOAD_FILE = "Fmv_excel/" + FileUpload1.FileName.ToString();
                }
                else { }
                objbo.CREATED_BY = Convert.ToString(Session["ECode"]);
                objbo.UPDATED_BY = "";
                objbo.btntext = "CREATE";//btncreatefmv.Text;
                string strmsg = objbal.Insert_Fmv(objbo);
                if (strmsg == "exi")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV already exist.'); ", true);
                }
                //else if (strmsg == "use")
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV already in used'); ", true);
                //}
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV created successfully.'); ", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV created successfully";
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "displayimg('" + showmsg.InnerText + "');", true);
                bindfmvGrid();
                clearcontrol();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;

            }

        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {


            string filename = (sender as LinkButton).CommandArgument;
            string filePath = Server.MapPath(filename);
            if (System.IO.File.Exists(filePath) && Path.HasExtension(filePath))
            {
                ScriptManager.RegisterStartupScript(this, typeof(LinkButton), "scr", "DownloadFile('" + filePath + "');", true);
                ViewState["filepath"] = filename.Replace("~/", "");
            }
            else
            {

                Common.ShowJavascriptAlert("File is not uploded for selected FMV.");
            }

        }

        protected void grdfmv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdfmv.PageIndex = e.NewPageIndex;
            this.bindfmvGrid();
        }

        protected void grdfmv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdfmv.EditIndex = e.NewEditIndex;
                this.bindfmvGrid();


            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdfmv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objbo.FMV_CREATION_ID = Convert.ToInt32(grdfmv.DataKeys[e.RowIndex].Values[0]);
            objbo.btntext = "Update";
            string result = objbal.FmvDelete(objbo);
            try
            {
                
                if (result == "Cannot")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV cannot be edited, FMV price is already assigned to grant.');", true);
                    grdfmv.EditIndex = -1;
                    bindfmvGrid();
                }
                
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
            if (result != "Cannot")
            {
                try
                {
                    DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    GridViewRow row = grdfmv.Rows[e.RowIndex];
                    objbo.FMV_CREATION_ID = Convert.ToInt32(grdfmv.DataKeys[e.RowIndex].Values[0]);
                    objbo.VALUATION_DATE = Convert.ToDateTime((row.FindControl("txtvaldate_Grid") as TextBox).Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);//Convert.ToDateTime(row.FindControl("txtvaldate_Grid") as TextBox); 
                    objbo.VALID_UPTO_DATE = Convert.ToDateTime((row.FindControl("txtvaliduptodate") as TextBox).Text,
    System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat); //(row.FindControl("txtvaliduptodate") as TextBox).Text;

                    objbo.FMV_PRICE = (row.FindControl("txtfmvprice") as TextBox).Text;
                    objbo.VALUED_BY = (row.FindControl("DropDownList1") as DropDownList).SelectedValue;

                    objbo.CREATED_BY = "";
                    objbo.UPDATED_BY = Convert.ToString(Session["ECode"]);
                    objbo.btntext = "UPDATE";
                    //objbal.Insert_Fmv(objbo);
                    string strmsg = objbal.Insert_Fmv(objbo);
                    if (strmsg == "exi")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV date already exist'); ", true);
                    }
                    //else if (strmsg == "cannot")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV price cannot be updated, FMV price is already assigned to grant.'); ", true);



                    //}


                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV updated successfully'); ", true);
                        showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                        showmsg.InnerText = "FMV updated successfully";
                    }
                    grdfmv.EditIndex = -1;
                    this.bindfmvGrid();
                }
                catch (Exception ex)
                {
                    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                    throw ex;
                }
            }
        }

        protected void grdfmv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdfmv.EditIndex = -1;
                bindfmvGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void grdfmv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objbo.FMV_CREATION_ID = Convert.ToInt32(grdfmv.DataKeys[e.RowIndex].Values[0]);
                objbo.btntext = "Detele";
                string result = objbal.FmvDelete(objbo);
                if (result.Contains("Grant"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV cannot be deleted, FMV price is already used in Grant.');", true);
                }
                else if (result.Contains("Exercise"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV cannot be deleted, FMV price is already used in Exercise.');", true);
                }
                else if (result.Contains("Sale"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV cannot be deleted, FMV price is already used in Sale.');", true);
                }
                else
                {

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('FMV deleted successfully.');", true);
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;text-align: center;";
                    showmsg.InnerText = "FMV deleted successfully";

                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "displayimg('" + showmsg.InnerText + "');", true);


                bindfmvGrid();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        //protected void txtvaluedby_TextChanged(object sender, EventArgs e)
        //{
        //    DataSet ds = objbal.getvaluedbyddl(objbo);
        //    if (ds.Tables.Count > 0)
        //    {
        //        grdfmv.DataSource = ds;
        //        grdfmv.DataBind();
        //         txtvaldate. = "AGENCY_NAME";
        //        ddltxtvaluedby.DataValueField = "AGENCY_ID";
        //    }}



        protected void grdfmv_RowDataBound(object sender, GridViewRowEventArgs e)

        {

            if (e.Row.RowType == DataControlRowType.DataRow && grdfmv.EditIndex == e.Row.RowIndex)
            {

                DropDownList DropDownList1 = (e.Row.FindControl("DropDownList1") as DropDownList);
                DataTable dt = objbal.getvaluedbyddl(objbo);

                DropDownList1.DataSource = dt;

                DropDownList1.DataTextField = "Valued_By";
                DropDownList1.DataValueField = "AGENCY_ID";
                DropDownList1.DataBind();

                DropDownList1.Items.Insert(0, new ListItem("Select", "0"));
                string Valued_By = DataBinder.Eval(e.Row.DataItem, "Valued_By").ToString();
                if (Valued_By != "")
                {
                    DropDownList1.Items.FindByText(Valued_By).Selected = true;
                }
                else
                {
                    DropDownList1.Items.FindByValue("0").Selected = true;
                }

                // int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
                //TextBox txtvaldate_Grid = (TextBox)grdfmv.Rows[Convert.ToInt32(rowIndex)].FindControl("txtvaldate_Grid");
                //txtvaldate_Grid.Attributes.Add("readonly", "readonly");
                TextBox txtvaldate_Grid = e.Row.FindControl("txtvaldate_Grid") as TextBox;
                txtvaldate_Grid.Attributes.Add("readonly", "readonly");

                TextBox txtvaliduptodate = e.Row.FindControl("txtvaliduptodate") as TextBox;
                txtvaliduptodate.Attributes.Add("readonly", "readonly");


            }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lbl_Code = (Label)e.Row.FindControl("lbl_Status");
            //    if (lbl_Code.Text.Contains("APP"))
            //    {
            //        e.Row.BackColor = System.Drawing.Color.LightPink;
            //    }
            //    else if (lbl_Code.Text.Contains("REJ"))
            //    {
            //        e.Row.BackColor = System.Drawing.Color.BurlyWood;
            //    }
            //}
        }

        protected void grdfmv_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                grdfmv.DataSource = dtrslt;
                grdfmv.DataBind();
            }
        }

        protected void grdfmv_PreRender(object sender, EventArgs e)
        {
            DataSet ds = objbal.getfmv(objbo);
            if (ds.Tables[0].Rows.Count > 0)
            {


                grdfmv.UseAccessibleHeader = true;
                grdfmv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdfmv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Audit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdfmv.Rows[index];
                objbo.FMV_CREATION_ID = Convert.ToInt32(grdfmv.DataKeys[index].Values[0]);

                //ViewState["fmvid"] = objbo.FMV_CREATION_ID;
                DataSet ds = objbal.GET_FMV_AUDIT(objbo);
                ViewState["Emp_filterRec"] = null;
                ViewState["Emp_filterRec"] = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdfmv_audit.DataSource = ds.Tables[0];
                    grdfmv_audit.DataBind();
                }
                else
                {
                    grdfmv_audit.DataSource = ds.Tables[0];
                    grdfmv_audit.DataBind();

                }
                //ViewState["Emp_filterRec"] = ds;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalShowAudit();", true);
            }




        }

        protected void grdfmv_audit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_Code = (Label)e.Row.FindControl("lbl_Status");
                if (lbl_Code.Text.Contains("Insert"))
                {
                    e.Row.BackColor = System.Drawing.Color.LightPink;
                }
                else if (lbl_Code.Text.Contains("Update"))
                {
                    e.Row.BackColor = System.Drawing.Color.BurlyWood;
                }
            }
        }

        protected void grdfmv_audit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdfmv_audit.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Emp_filterRec"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdfmv_audit.DataSource = ds.Tables[0];
                grdfmv_audit.DataBind();
            }
        }

        protected void btnexcelExport_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "FMVL_REPORT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            //grdfmv_audit.GridLines = GridLines.Both;
            //grdfmv_audit.HeaderStyle.Font.Bold = true;

            grdfmv_audit.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnpdfexport_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";

            string filename = "FMV_REPORT" + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            // Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");


            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdfmv_audit.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            it.Document pdfDoc = new it.Document(it.PageSize.A2, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            grdfmv_audit.AllowPaging = true;
            grdfmv_audit.DataBind();

        }

        protected void grdfmv_audit_PreRender(object sender, EventArgs e)
        {

            DataTable ds = (DataTable)ViewState["Emp_filterRec"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {
                    grdfmv_audit.UseAccessibleHeader = true;
                    grdfmv_audit.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }



        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                //var  filePath = Request.Form["__EVENTARGUMENT"];
                string filePath = ViewState["filepath"].ToString();
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }
    }
}
