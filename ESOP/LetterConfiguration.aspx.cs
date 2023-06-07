
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
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Diagnostics;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
//using Microsoft.Office.Interop.Word;

namespace ESOP
{
    public partial class LetterConfiguration : System.Web.UI.Page
    {
        LetterConfigBO objbo = new LetterConfigBO();
        LetterConfigBAL objbal = new LetterConfigBAL();
        bool IsPageRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            showmsg.InnerHtml = "";
            if (!Page.IsPostBack)
            {
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();


                FunGetLetterConfig();
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

        protected void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LetterConfigBO LetterConfigBO = new LetterConfigBO();
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)sender;
                GridViewRow row = (GridViewRow)cb.NamingContainer;
                if (row != null)
                {
                    int rowindex = row.RowIndex;
                    LetterConfigBO.LetterConfig_ID = Convert.ToInt32(GrvLetter_Config.DataKeys[rowindex].Values[0]);
                    LetterConfigBO.Modified_BY = Convert.ToString(Session["ECode"]);
                    LetterConfigBO.Mode = "IsActive";
                    HiddenField Hdf = GrvLetter_Config.Rows[rowindex].FindControl("HdnLtrname") as HiddenField;
                    LetterConfigBO.Letter_NAME = Hdf.Value.ToString();
                    if (cb.Checked)
                    {
                        LetterConfigBO.ISACTIVE = "1";
                    }
                    else
                    {
                        LetterConfigBO.ISACTIVE = "0";
                    }
                    objbal.Update_Status(LetterConfigBO);
                    FunGetLetterConfig();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }

        }

        public void FunGetLetterConfig()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objbal.FunGetLetterConfig();
                ViewState["GrvLetter_Config"] = null;
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    GrvLetter_Config.DataSource = ds.Tables[0];
                    GrvLetter_Config.DataBind();
                    ViewState["GrvLetter_Config"] = ds.Tables[0];

                    //GrvLetter_Config.UseAccessibleHeader = true;
                    //GrvLetter_Config.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    GrvLetter_Config.DataSource = null;
                    GrvLetter_Config.DataBind();
                    ViewState["GrvLetter_Config"] = null;
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);

                throw ex;
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            LetterConfigBO LetterConfigBO = new LetterConfigBO();
            try
            {

                if (IsPageRefresh)
                {
                    return;
                }



                if (FileUploadFooter.HasFile)
                {
                    //WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 6", DateTime.Now));
                    if (Convert.ToInt16(DrpLetterTyp.SelectedValue) == 2 || Convert.ToInt16(DrpLetterTyp.SelectedValue) == 3)
                    {
                        FileUploadFooter.SaveAs(System.IO.Path.Combine(Server.MapPath("Sale_Doc_Template"), FileUploadFooter.FileName));
                        LetterConfigBO = new LetterConfigBO();
                        LetterConfigBO.LetterConfig_ID = Convert.ToInt32(DrpLetterTyp.SelectedValue.ToString());
                        LetterConfigBO.Letter_NAME = DrpLetterTyp.SelectedItem.Text.ToString();
                        LetterConfigBO.Modified_BY = Convert.ToString(Session["ECode"]);
                        LetterConfigBO.Mode = "FilePath";
                        LetterConfigBO.UPLOADType = "UPLOAD";
                        LetterConfigBO.FilePath = "Sale_Doc_Template/" + FileUploadFooter.FileName.ToString();
                        objbal.Update_Status(LetterConfigBO);
                        FunGetLetterConfig();


                        //string F_Path = Server.MapPath("~/Sale_Doc_Template/" + FileUploadFooter.FileName.ToString());
                        //Common.UploadFtpFile("Sale_Doc_Template/" + FileUploadFooter.FileName.ToString(), F_Path);


                        ///////////////////////////////////Soffice//////////////////////////////////////////////////
                        #region pdf generate using docx file. comment on hdfc argo server"
                        using (Process pdfprocess = new Process())
                        {
                            pdfprocess.StartInfo.UseShellExecute = true;
                            pdfprocess.StartInfo.LoadUserProfile = true;
                            pdfprocess.StartInfo.FileName = "soffice.exe";
                            pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + Server.MapPath("Sale_Doc_Template/" + FileUploadFooter.FileName.ToString());
                            pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("Sale_Doc_Template/");
                            pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            pdfprocess.Start();
                            if (!pdfprocess.WaitForExit(1000 * 60 * 1))
                            {
                                pdfprocess.Kill();
                            }
                            pdfprocess.Close();
                        }
                        #endregion
                        //////////////////////////////////////////////////////////////////////////////////////////////


                        //////////Ms office//////////////////////
                        #region "Generate PDF using Interop.Word--comment on clover server"                     
                        //string PdfPathInput = "";
                        //if (System.IO.Path.GetExtension(FileUploadFooter.FileName).ToString() == ".docx")
                        //{
                        //    PdfPathInput = Server.MapPath("Sale_Doc_Template/" + FileUploadFooter.FileName.ToString().Replace(".docx", ".pdf"));
                        //}
                        //var appWord = new Application();
                        //try
                        //{
                        //    if (appWord.Documents != null)
                        //    {
                        //        var wordDocument = appWord.Documents.Open(Server.MapPath("Sale_Doc_Template/" + FileUploadFooter.FileName.ToString()));
                        //        string pdfDocName = PdfPathInput;
                        //        if (wordDocument != null)
                        //        {
                        //            wordDocument.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                        //            wordDocument.Close();
                        //        }
                        //        appWord.Quit();
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                        //    appWord.Quit();
                        //}
                        #endregion
                        //////////////////////////////////////////////////////

                        //string F_Path1 = Server.MapPath("~/Sale_Doc_Template/" + FileUploadFooter.FileName.ToString().Replace(".docx", ".pdf"));
                        //Common.UploadFtpFile("Sale_Doc_Template/" + FileUploadFooter.FileName.ToString().Replace(".docx", ".pdf"), F_Path1);
                    }
                    else
                    {
                        FileUploadFooter.SaveAs(System.IO.Path.Combine(Server.MapPath("LetterConfig"), FileUploadFooter.FileName));
                        LetterConfigBO = new LetterConfigBO();
                        LetterConfigBO.LetterConfig_ID = Convert.ToInt32(DrpLetterTyp.SelectedValue.ToString());
                        LetterConfigBO.Letter_NAME = DrpLetterTyp.SelectedItem.Text.ToString();
                        LetterConfigBO.Modified_BY = Convert.ToString(Session["ECode"]);
                        LetterConfigBO.Mode = "FilePath";
                        LetterConfigBO.FilePath = "LetterConfig/" + FileUploadFooter.FileName.ToString();
                        LetterConfigBO.UPLOADType = "UPLOAD";
                        objbal.Update_Status(LetterConfigBO);
                        FunGetLetterConfig();

                        //string F_Path = Server.MapPath("~/LetterConfig/" + FileUploadFooter.FileName.ToString());
                        //Common.UploadFtpFile("LetterConfig/" + FileUploadFooter.FileName.ToString(), F_Path);


                        #region pdf generate using docx file. comment on hdfc argo server"
                        using (Process pdfprocess = new Process())
                        {
                            pdfprocess.StartInfo.UseShellExecute = true;
                            pdfprocess.StartInfo.LoadUserProfile = true;
                            pdfprocess.StartInfo.FileName = "soffice.exe";
                            pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + Server.MapPath("LetterConfig/" + FileUploadFooter.FileName.ToString());
                            pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("LetterConfig/");
                            pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            pdfprocess.Start();
                            if (!pdfprocess.WaitForExit(1000 * 60 * 1))
                            {
                                pdfprocess.Kill();
                            }
                            pdfprocess.Close();
                        }
                        #endregion


                        ///////////////////////////////////////////////////////////////////////////////////////////////                   

                        #region "Generate PDF using Interop.Word--comment on clover server"
                        //string PdfPathInput = "";

                        //if (System.IO.Path.GetExtension(FileUploadFooter.FileName).ToString() == ".docx")
                        //{
                        //    PdfPathInput = Server.MapPath("LetterConfig/" + FileUploadFooter.FileName.ToString().Replace(".docx", ".pdf"));
                        //}
                        //var appWord = new Application();
                        //try
                        //{
                        //    if (appWord.Documents != null)
                        //    {
                        //        //yourDoc is your word document
                        //        var wordDocument = appWord.Documents.Open(Server.MapPath("LetterConfig/" + FileUploadFooter.FileName.ToString()));
                        //        string pdfDocName = PdfPathInput;
                        //        if (wordDocument != null)
                        //        {
                        //            wordDocument.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                        //            wordDocument.Close();
                        //        }
                        //        appWord.Quit();
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                        //    appWord.Quit();
                        //}
                        #endregion

                        //string F_Path1 = Server.MapPath("~/LetterConfig/" + FileUploadFooter.FileName.ToString().Replace(".docx", ".pdf"));
                        //Common.UploadFtpFile("LetterConfig/" + FileUploadFooter.FileName.ToString().Replace(".docx", ".pdf"), F_Path1);
                    }

                  
                    ///////////////////////                 
                    showmsg.Attributes["style"] = "color:green; font-weight:bold;padding-left: 45px;text-align:center";
                    showmsg.InnerText = "File Uploaded Successfully";
                    DrpLetterTyp.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }

        }

        // public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            LetterConfigBO LetterConfigBO = new LetterConfigBO();
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            if (row != null)
            {
                int rowindex = row.RowIndex;
                LetterConfigBO = new LetterConfigBO();
                LetterConfigBO.LetterConfig_ID = Convert.ToInt32(GrvLetter_Config.DataKeys[rowindex].Values[0]);
                LetterConfigBO.Modified_BY = Convert.ToString(Session["ECode"]);
                LetterConfigBO.Mode = "ISDelete";
                LetterConfigBO.IsDelete = "Y";
                objbal.Update_Status(LetterConfigBO);
                FunGetLetterConfig();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Deleted Successfully');", true);
                showmsg.Attributes["style"] = "color:green; font-weight:bold;padding-left: 45px;text-align:center";
                showmsg.InnerText = "Record Deleted Successfully";
            }

        }
        protected void btn_Preview_Click(object sender, EventArgs e)
        {
            LetterConfigBO LetterConfigBO = new LetterConfigBO();
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            if (row != null)
            {
                int rowindex = row.RowIndex;
                HiddenField Hdf = GrvLetter_Config.Rows[rowindex].FindControl("HiddenField1") as HiddenField;
                string Path1 = "";
                if (System.IO.Path.GetExtension(Hdf.Value.ToString()).ToString() == ".docx")
                {
                    Path1 = Hdf.Value.ToString().Replace(".docx", ".pdf");
                }
                if (System.IO.Path.GetExtension(Hdf.Value.ToString()).ToString() == ".doc")
                {
                    Path1 = Hdf.Value.ToString().Replace(".doc", ".pdf");
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('" + Path1 + "');", true);
            }
        }
        protected void BtnCreateLetter_Click(object sender, EventArgs e)
        {
            if (DrpLetterTyp.SelectedItem.Text == "Grant Letter")
            {
                Response.Redirect("LetterEdit1.aspx?LetterName=" + DrpLetterTyp.SelectedItem.Text.ToString());
            }
        }

        protected void GrvLetter_Config_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = ((LinkButton)e.Row.FindControl("Btn_Edit"));
                if (e.Row.Cells[2].Text == "UPLOAD")
                {
                    lnk.Visible = false;
                }
                else
                {
                    lnk.Visible = true;
                }
            }
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            string LetterID = (sender as LinkButton).CommandArgument;
            Response.Redirect("LetterEdit1.aspx?LetterID=" + LetterID);
        }

        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                if (DrpLetterTyp.SelectedValue == "1")
                {
                    filePath = Server.MapPath("~/LetterFileFormat/Grant_Letter.docx");

                }
                else
                {
                    if (DrpLetterTyp.SelectedValue == "2")
                    {
                        filePath = Server.MapPath("~/Sale_Doc_Template/ESOP-Sale-Offer.docx");
                    }
                    else
                    {
                        filePath = Server.MapPath("~/Sale_Doc_Template/ESOP-Sale-Declaration.docx");
                    }
                }
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void GrvLetter_Config_PreRender(object sender, EventArgs e)
        {
            System.Data.DataTable ds = (System.Data.DataTable)ViewState["GrvLetter_Config"];
            if (ds == null) { }
            else
            {
                if (ds.Rows.Count > 0)
                {

                    GrvLetter_Config.UseAccessibleHeader = true;
                    GrvLetter_Config.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
        }


        protected void btn_Words_Click(object sender, EventArgs e)
        {
            LetterConfigBO LetterConfigBO = new LetterConfigBO();
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            if (row != null)
            {
                int rowindex = row.RowIndex;
                HiddenField Hdf = GrvLetter_Config.Rows[rowindex].FindControl("HiddenField1") as HiddenField;
                string strpath = Server.MapPath(Hdf.Value.ToString());
                string pattern = @"(?<!\w)@\w+";
                int SrNo = 0;
                using (WordprocessingDocument doc =
                          WordprocessingDocument.Open(strpath, true))
                {
                    ///////////////////////////////Edit/////////////////////////////
                    string docText = null;
                    string docP = null;
                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }
                    //MatchCollection matches = Regex.Matches(docText, pattern, RegexOptions.Singleline);
                    //foreach (Match match in matches)
                    //{
                    //    docP += match.Groups["@"];
                    //}

                    foreach (Match match in Regex.Matches(docText, pattern))
                    {
                        SrNo++;
                        docP += SrNo.ToString() + ") " + match.Value + " \r\n";
                    }

                    //Response.Write(docP);
                    MemoryStream ms = new MemoryStream();
                    TextWriter tw = new StreamWriter(ms);
                    tw.WriteLine(docP);
                    tw.Flush();
                    byte[] bytes = ms.ToArray();
                    ms.Close();

                    Response.Clear();
                    Response.ContentType = "application/force-download";
                    Response.AddHeader("content-disposition", "attachment;filename=KeywordsFile.txt");
                    Response.BinaryWrite(bytes);
                    Response.End();
                }
            }
        }

        //protected void GrvLetter_Config_PreRender(object sender, EventArgs e)
        //{
        //    DataSet ds = objbal.FunGetLetterConfig();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        GrvLetter_Config.UseAccessibleHeader = true;
        //        GrvLetter_Config.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}

        //protected void LnkDownload_Click(object sender, EventArgs e)
        //{
        //    string filePath = Server.MapPath("~/LetterFileFormat/Grant_Letter.docx");
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.WriteFile(filePath);
        //    Response.End();
        //}

        protected void btn_PDF_Click(object sender, EventArgs e)
        {
            LetterConfigBO LetterConfigBO = new LetterConfigBO();
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            if (row != null)
            {
                int rowindex = row.RowIndex;
                HiddenField Hdf = GrvLetter_Config.Rows[rowindex].FindControl("HiddenField1") as HiddenField;
                string sourceFile = Server.MapPath(Hdf.Value.ToString());
                string destinationFile = System.IO.Path.Combine(Server.MapPath("LetterConfig/DemoReport.docx"));
                File.Copy(sourceFile, destinationFile, true);

                //Editing Docx file with Dynamic data from database.
                using (WordprocessingDocument doc =
                    WordprocessingDocument.Open(destinationFile, true))
                {
                    ///////////////////////////////Edit/////////////////////////////
                    string docText = null;
                    string docP = null;
                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                    {
                        docText = sr.ReadToEnd();
                    }

                    //////////////////////////////-Letter Edit Keywords///////////////////////////////
                    if (docText.Contains("@Emp_Code"))
                    {
                        Regex regexText = new Regex("@Emp_Code");
                        docText = regexText.Replace(docText, "Emp_Code_Test");
                    }

                    if (docText.Contains("@TodayDate"))
                    {
                        Regex regexText = new Regex("@TodayDate");
                        docText = regexText.Replace(docText, "TodayDate_Test");
                    }

                    if (docText.Contains("@Emp_Name"))
                    {
                        Regex regexText = new Regex("@Emp_Name");
                        docText = regexText.Replace(docText, "Emp_Name_Test");
                    }

                    if (docText.Contains("@Grant_Date"))
                    {
                        Regex regexText = new Regex("@Grant_Date");
                        docText = regexText.Replace(docText, "Grant_Date_Test");
                    }
                    if (docText.Contains("@Tranch_Name"))
                    {
                        Regex regexText = new Regex("@Tranch_Name");
                        docText = regexText.Replace(docText, "Tranch_Name_Test");
                    }
                    if (docText.Contains("@No_Of_Options"))
                    {
                        Regex regexText = new Regex("@No_Of_Options");
                        docText = regexText.Replace(docText, "No_Of_Options_Test");
                    }
                    if (docText.Contains("@Share_Price"))
                    {
                        Regex regexText = new Regex("@Share_Price");
                        docText = regexText.Replace(docText, "Share_Price_Test");
                    }

                    if (docText.Contains("@FMV_Price"))
                    {
                        Regex regexText = new Regex("@FMV_Price");
                        docText = regexText.Replace(docText, "FMV_Price_Test");
                    }

                    if (docText.Contains("@Reference_No"))
                    {
                        Regex regexText = new Regex("@Reference_No");
                        docText = regexText.Replace(docText, "Reference_No_Test");
                    }

                    if (docText.Contains("@SrNo"))
                    {
                        Regex regexText = new Regex("@SrNo");
                        docText = regexText.Replace(docText, "SrNo_Test");
                    }

                    if (docText.Contains("@Title"))
                    {
                        Regex regexText = new Regex("@Title");
                        docText = regexText.Replace(docText, "Title_Test");
                    }

                    if (docText.Contains("@Band"))
                    {
                        Regex regexText = new Regex("@Band");
                        docText = regexText.Replace(docText, "Band_Test");
                    }

                    if (docText.Contains("@Designation"))
                    {
                        Regex regexText = new Regex("@Designation");
                        docText = regexText.Replace(docText, "Designation_Test");
                    }

                    if (docText.Contains("@Location"))
                    {
                        Regex regexText = new Regex("@Location");
                        docText = regexText.Replace(docText, "Location_Test");
                    }

                    if (docText.Contains("@Department"))
                    {
                        Regex regexText = new Regex("@Department");
                        docText = regexText.Replace(docText, "Department_Test");
                    }

                    if (docText.Contains("@Function"))
                    {
                        Regex regexText = new Regex("@Function");
                        docText = regexText.Replace(docText, "Function_Test");
                    }

                    if (docText.Contains("@CostCenter"))
                    {
                        Regex regexText = new Regex("@CostCenter");
                        docText = regexText.Replace(docText, "CostCenter_Test");
                    }


                    if (docText.Contains("@Vest_Date1"))
                    {
                        Regex regexText = new Regex("@Vest_Date1");
                        docText = regexText.Replace(docText, "Vestdate1_Test");
                    }


                    if (docText.Contains("@Vest_Date2"))
                    {
                        Regex regexText = new Regex("@Vest_Date2");
                        docText = regexText.Replace(docText, "Vestdate2_Test");
                    }


                    if (docText.Contains("@Vest_Date3"))
                    {
                        Regex regexText = new Regex("@Vest_Date3");
                        docText = regexText.Replace(docText, "Vestdate3_Test");
                    }


                    if (docText.Contains("@Vest_Date4"))
                    {
                        Regex regexText = new Regex("@Vest_Date4");
                        docText = regexText.Replace(docText, "Vestdate4_Test");
                    }


                    if (docText.Contains("@Vest_Date5"))
                    {
                        Regex regexText = new Regex("@Vest_Date5");
                        docText = regexText.Replace(docText, "Vestdate5_Test");
                    }


                    if (docText.Contains("@Vest_Date6"))
                    {
                        Regex regexText = new Regex("@Vest_Date6");
                        docText = regexText.Replace(docText, "Vestdate6_Test");
                    }

                    if (docText.Contains("@In_Words"))
                    {
                        Regex regexText = new Regex("@In_Words");
                        docText = regexText.Replace(docText, "In_Words_Test");
                    }

                    if (docText.Contains("@FMV"))
                    {
                        Regex regexText = new Regex("@FMV");
                        docText = regexText.Replace(docText, "FMV_Test");
                    }

                    if (docText.Contains("@FMV_Price"))
                    {
                        Regex regexText = new Regex("@FMV_Price");
                        docText = regexText.Replace(docText, "FMV_Price_Test");
                    }

                    if (docText.Contains("@Date"))
                    {
                        Regex regexText = new Regex("@Date");
                        docText = regexText.Replace(docText, "Date_Test");
                    }

                    if (docText.Contains("@Emp_Full_Name"))
                    {
                        Regex regexText = new Regex("@Emp_Full_Name");
                        docText = regexText.Replace(docText, "Emp_Full_Name_Test");
                    }

                    if (docText.Contains("@Address1"))
                    {
                        Regex regexText = new Regex("@Address1");
                        docText = regexText.Replace(docText, "Address1_Test");
                    }

                    if (docText.Contains("@Address2"))
                    {
                        Regex regexText = new Regex("@Address2");
                        docText = regexText.Replace(docText, "Address2_Test");
                    }

                    if (docText.Contains("@Email_ID"))
                    {
                        Regex regexText = new Regex("@Email_ID");
                        docText = regexText.Replace(docText, "Email_ID_Test");
                    }

                    if (docText.Contains("@DPID"))
                    {
                        Regex regexText = new Regex("@DPID");
                        docText = regexText.Replace(docText, "DPID_Test");
                    }

                    if (docText.Contains("@Client_ID"))
                    {
                        Regex regexText = new Regex("@Client_ID");
                        docText = regexText.Replace(docText, "Client_ID_Test");
                    }

                    if (docText.Contains("@Acc_No"))
                    {
                        Regex regexText = new Regex("@Acc_No");
                        docText = regexText.Replace(docText, "Acc_No_Test");
                    }

                    if (docText.Contains("@Bank_Name"))
                    {
                        Regex regexText = new Regex("@Bank_Name");
                        docText = regexText.Replace(docText, "Bank_Name_Test");
                    }

                    if (docText.Contains("@MICR_Code"))
                    {
                        Regex regexText = new Regex("@MICR_Code");
                        docText = regexText.Replace(docText, "MICR_Code_Test");
                    }

                    if (docText.Contains("@IFSC_Code"))
                    {
                        Regex regexText = new Regex("@IFSC_Code");
                        docText = regexText.Replace(docText, "IFSC_Code_Test");
                    }

                    using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                        sw.Close();
                    }
                }

                #region pdf generate using docx file. comment on hdfc argo server"

                using (Process pdfprocess = new Process())
                {
                    pdfprocess.StartInfo.UseShellExecute = true;
                    pdfprocess.StartInfo.LoadUserProfile = true;
                    pdfprocess.StartInfo.FileName = "soffice.exe";
                    pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + destinationFile;
                    pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("outputreport/");
                    pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pdfprocess.Start();
                    if (!pdfprocess.WaitForExit(1000 * 60 * 1))
                    {
                        pdfprocess.Kill();
                    }
                    pdfprocess.Close();
                }
                #endregion

                #region "Generate PDF using Interop.Word--comment on clover server"
                //string PdfPathInput = destinationFile.Replace(".docx", ".pdf");
                //var appWord = new Application();
                //if (appWord.Documents != null)
                //{
                //    var wordDocument = appWord.Documents.Open(destinationFile);
                //    string pdfDocName = PdfPathInput;
                //    if (wordDocument != null)
                //    {
                //        wordDocument.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                //        wordDocument.Close();
                //    }
                //    appWord.Quit();
                //}
                #endregion

                string Path = "LetterConfig/DemoReport.pdf";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('" + Path + "');", true);
            }
        }
    }
}