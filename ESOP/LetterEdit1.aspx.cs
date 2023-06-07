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
using System.Text.RegularExpressions;
//using Microsoft.Office.Interop.Word;


namespace ESOP
{
    public partial class LetterEdit1 : System.Web.UI.Page
    {
        LetterEditBO objbo = new LetterEditBO();
        LetterEditBAL objbal = new LetterEditBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ScriptManager.GetCurrent(Page).IsInAsyncPostBack)
            {
                ScriptManager.RegisterOnSubmitStatement(this, this.GetType(), "SaveTextBoxBeforePostBack", "BeforePostback();");
            }

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["LetterID"] != null && Request.QueryString["LetterID"] != "")
                {
                    ViewState["LetterID"] = Convert.ToInt32(Request.QueryString["LetterID"].ToString());
                    FunGetLetterEditRcords();
                }

                if (Request.QueryString["LetterName"] != null && Request.QueryString["LetterName"] != "")
                {
                    ViewState["LetterName"] = Request.QueryString["LetterName"].ToString();
                    LnkHeaderDelete.Visible = false;
                    LnkFooterDelete.Visible = false;
                    LnkSignDelete.Visible = false;
                }
            }

        }



        public void FunGetLetterEditRcords()
        {
            try
            {
                DataSet ds = new DataSet();
                objbo.LetterID = Convert.ToInt32(ViewState["LetterID"]);
                ds = objbal.GetLetterEditDetails(objbo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ImgHeader.ImageUrl = ds.Tables[0].Rows[0]["Header"].ToString().Trim() + "?time=" + DateTime.Now.ToString();
                    ImgFooter.ImageUrl = ds.Tables[0].Rows[0]["Footer"].ToString().Trim() + "?time=" + DateTime.Now.ToString();
                    ImgSign.ImageUrl = ds.Tables[0].Rows[0]["Signature"].ToString().Trim() + "?time=" + DateTime.Now.ToString();
                    //ImgDesgn.ImageUrl = ds.Tables[0].Rows[0]["Designation"].ToString().Trim() + "?time=" + DateTime.Now.ToString();
                    TxtSignatory.Text = ds.Tables[0].Rows[0]["Designation"].ToString().Trim();
                    TextBox1.Text = ds.Tables[0].Rows[0]["Content"].ToString().Trim();


                    if (string.IsNullOrEmpty(ImgHeader.ImageUrl))
                    {
                        LnkHeaderDelete.Visible = false;
                    }
                    else
                    {
                        LnkHeaderDelete.Visible = true;
                    }

                    if (string.IsNullOrEmpty(ImgFooter.ImageUrl))
                    {
                        LnkFooterDelete.Visible = false;
                    }
                    else
                    {
                        LnkFooterDelete.Visible = true;
                    }

                    if (string.IsNullOrEmpty(ImgSign.ImageUrl))
                    {
                        LnkSignDelete.Visible = false;
                    }
                    else
                    {
                        LnkSignDelete.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region "--------------Fileuplod Button Event------------------------------"

        protected void LnkHeaderEdit_Click(object sender, EventArgs e)
        {
            if (FileUploadHeader.HasFile)
            {
                System.IO.Stream fs = FileUploadHeader.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                ImgHeader.ImageUrl = "data:image/png;base64," + base64String;
            }
        }
        protected void LnkSignEdit_Click(object sender, EventArgs e)
        {
            if (FileUploadSign.HasFile)
            {
                System.IO.Stream fs = FileUploadSign.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                ImgSign.ImageUrl = "data:image/png;base64," + base64String;
            }
        }

        protected void LnkFooterEdit_Click(object sender, EventArgs e)
        {
            if (FileUploadFooter.HasFile)
            {
                System.IO.Stream fs = FileUploadFooter.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                ImgFooter.ImageUrl = "data:image/png;base64," + base64String;
            }
        }
        ////protected void LnkDesign_Click(object sender, EventArgs e)
        ////{
        ////    if (FileUploadDesignation.HasFile)
        ////    {
        ////        System.IO.Stream fs = FileUploadDesignation.PostedFile.InputStream;
        ////        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
        ////        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        ////        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        ////        ImgDesgn.ImageUrl = "data:image/png;base64," + base64String;
        ////    }
        ////}

        #endregion

        #region "---------------Delete Image----------------------------------------------------"


        protected void LnkHeaderDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ViewState["LetterID"])))
                {
                    FunDeleteIMGFile("~/ReportImg/Header_" + ViewState["LetterID"].ToString() + ".png");
                    //ImgHeader.ImageUrl = null;
                    objbo.ImageType = "Header";
                    objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                    bool val = objbal.DeleteLetterDetails(objbo);
                    if (val == true)
                    {
                        ImgHeader.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                        FunGetLetterEditRcords();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Header Image Deleted Successfully');", true);
                    }
                }
                else
                {
                    ImgHeader.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Header Image Deleted Successfully');", true);
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void LnkFooterDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ViewState["LetterID"])))
                {
                    FunDeleteIMGFile("~/ReportImg/Footer_" + ViewState["LetterID"].ToString() + ".png");
                    //ImgFooter.ImageUrl = null;
                    objbo.ImageType = "Footer";
                    objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                    bool val = objbal.DeleteLetterDetails(objbo);
                    if (val == true)
                    {
                        ImgFooter.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                        FunGetLetterEditRcords();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Footer Image Deleted Successfully');", true);
                    }
                }
                else
                {
                    ImgFooter.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Footer Image Deleted Successfully');", true);
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void LnkSignDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ViewState["LetterID"])))
                {
                    FunDeleteIMGFile("~/ReportImg/Signature_" + ViewState["LetterID"].ToString() + ".png");
                    //ImgSign.ImageUrl = null;
                    objbo.ImageType = "Signature";
                    objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                    bool val = objbal.DeleteLetterDetails(objbo);
                    if (val == true)
                    {
                        ImgSign.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                        FunGetLetterEditRcords();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Signature Image Deleted Successfully');", true);
                    }
                }
                else
                {
                    ImgSign.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Signature Image Deleted Successfully');", true);
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        //protected void LinkDesigDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["LetterID"])))
        //        {
        //            FunDeleteIMGFile("~/ReportImg/Designation_" + ViewState["LetterID"].ToString() + ".png");
        //            //ImgSign.ImageUrl = null;
        //            objbo.ImageType = "Designation";
        //            objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
        //            bool val = objbal.DeleteLetterDetails(objbo);
        //            if (val == true)
        //            {
        //                ImgDesgn.ImageUrl = null + "?time=" + DateTime.Now.ToString();
        //                FunGetLetterEditRcords();
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Designation Image Deleted Successfully');", true);
        //            }
        //        }
        //        else
        //        {
        //            ImgDesgn.ImageUrl = null + "?time=" + DateTime.Now.ToString();
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Designation Image Deleted Successfully');", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
        //    }
        //}
        #endregion

        public void FunDeleteIMGFile(String Path)
        {
            FileInfo file = new FileInfo(Server.MapPath(Path));
            if (file.Exists)//check file exsit or not
            {

                file.Delete();
            }
        }

        protected void BtnPreviewBelow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ImgHeader.ImageUrl))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Upload Header Image');", true);
                return;
            }

            if (string.IsNullOrEmpty(ImgFooter.ImageUrl))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Upload Footer Image');", true);
                return;
            }

            if (string.IsNullOrEmpty(ImgSign.ImageUrl))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Upload Singnature Image');", true);
                return;
            }

            bool val = GenerateReport();
            if (val == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Submit report data first!!!');", true);
            }

        }

        public bool GenerateReport()
        {
            DataSet ds = new DataSet();
            bool Flag;
            #region "--------------------Creating RDLC report--------------------------"
            //ReportDataSource rds = new ReportDataSource();
            RptLetter.ProcessingMode = ProcessingMode.Local;
            RptLetter.LocalReport.ReportPath = Server.MapPath(@"~\ReportDesigns\RptFinal.rdlc");
            //RptLetter.LocalReport.ReportPath = Server.MapPath(@"~/RptUpdated.rdlc");

            //-----------------------------Image Part---------------------------
            string imageLogo = "";
            string imageFooter = "";
            string imageSign = "";
            string imageDesignation = "";
            ReportParameter rptLogo = null;
            ReportParameter rptFooter = null;
            ReportParameter rptSign = null;
            ReportParameter rptDesignation = null;
            ReportParameter rp = null;
            RptLetter.LocalReport.EnableExternalImages = true;
            ReportDataSource rds = null;
            DataSet DS1 = new DataSet();
            objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
            DS1 = objbal.GetReportDesign(objbo);
            if (DS1.Tables[0].Rows.Count > 0)
            {
                imageLogo = new Uri(Server.MapPath(DS1.Tables[0].Rows[0]["Header"].ToString())).AbsoluteUri;
                rptLogo = new ReportParameter("rptLogo", imageLogo);
                imageFooter = new Uri(Server.MapPath(DS1.Tables[0].Rows[0]["Footer"].ToString())).AbsoluteUri;
                rptFooter = new ReportParameter("rptFooter", imageFooter);
                imageSign = new Uri(Server.MapPath(DS1.Tables[0].Rows[0]["Signature"].ToString())).AbsoluteUri;
                rptSign = new ReportParameter("rptSign", imageSign);
              

                rds = new ReportDataSource("DataSet1", DS1.Tables[0]);
                if (imageLogo == "")
                {
                    imageLogo = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                    rptLogo = new ReportParameter("rptLogo", imageLogo);
                }

                if (imageFooter == "")
                {
                    imageFooter = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                    rptFooter = new ReportParameter("rptFooter", imageFooter);
                }

                if (imageSign == "")
                {
                    imageSign = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                    rptSign = new ReportParameter("rptScannedSignatureImg", imageSign);
                }

             
                RptLetter.LocalReport.DataSources.Clear();
                RptLetter.LocalReport.EnableExternalImages = true;
                RptLetter.LocalReport.SetParameters(new ReportParameter[] { rptLogo, rptFooter, rptSign });
                RptLetter.LocalReport.DataSources.Add(rds);
                RptLetter.LocalReport.Refresh();
                Flag = true;
            }
            else
            {

                Flag = false;
            }
            #endregion
            return Flag;
        }

        public void generatew()
        {
            DataSet DS1 = new DataSet();
            ReportDataSource rds = null;
            objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
            DS1 = objbal.GetReportDesign(objbo);
            if (DS1.Tables[0].Rows.Count > 0)
            {
                rds = new ReportDataSource("DataSet1", DS1.Tables[0]);
            }
            //ReportViewer1.LocalReport.DataSources.Add(rds);
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/Report1.rdlc");
            //ReportViewer1.LocalReport.Refresh();

            //ReportViewer1.LocalReport.EnableExternalImages = true;
            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = new ReportParameter("ImgPath", FilePath);
            //ReportViewer1.LocalReport.SetParameters(param);
            #region "--------Report download to Application route----------------"

            string FilePath = Server.MapPath("~/LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx");
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string contentType;
            string encoding;
            string extension;

            if (RptLetter.LocalReport.ReportPath != null)
            {
                byte[] bytes = RptLetter.LocalReport.Render("WORDOPENXML", null, out contentType, out encoding, out extension, out streamIds, out warnings);
                FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);
                byte[] data = new byte[fs.Length];
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                ///////////////////////////////////

                LetterConfigBO objbon = new LetterConfigBO();
                LetterConfigBAL objbaln = new LetterConfigBAL();

                objbon.LetterConfig_ID = Convert.ToInt32(ViewState["LetterID"]);
                objbon.Modified_BY = Convert.ToString(Session["ECode"]);
                objbon.Mode = "EditLetterPath";
                objbon.FilePath = "LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx";
                objbaln.Update_Status(objbon);


                using (Process pdfprocess = new Process())
                {
                    pdfprocess.StartInfo.UseShellExecute = true;
                    pdfprocess.StartInfo.LoadUserProfile = true;
                    pdfprocess.StartInfo.FileName = "soffice.exe";
                    pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + Server.MapPath("LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx");
                    pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("LetterConfig/");
                    pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pdfprocess.Start();
                    if (!pdfprocess.WaitForExit(1000 * 60 * 1))
                    {
                        pdfprocess.Kill();
                    }
                    pdfprocess.Close();
                }
                ///////////////////////
            }
            #endregion  
        }

        public void GenerateWordFile()
        {
            DataSet ds = new DataSet();
            #region "--------------------Creating RDLC report--------------------------"
            //ReportDataSource rds = new ReportDataSource();
            try
            {
                RptLetter.ProcessingMode = ProcessingMode.Local;
                RptLetter.LocalReport.ReportPath = Server.MapPath(@"~/ReportDesigns/RptFinal.rdlc");
                //-----------------------------Image Part---------------------------
                string imageLogo = "";
                string imageFooter = "";
                string imageSign = "";
                string imageDesignation = "";
                ReportParameter rptLogo = null;
                ReportParameter rptFooter = null;
                ReportParameter rptSign = null;
                ReportParameter rptDesignation = null;
                ReportParameter rp = null;
                ReportDataSource rds = null;
                DataSet DS1 = new DataSet();
                objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                DS1 = objbal.GetReportDesign(objbo);
                if (DS1.Tables[0].Rows.Count > 0)
                {
                    imageLogo = new Uri(Server.MapPath(DS1.Tables[0].Rows[0]["Header"].ToString())).AbsoluteUri;
                    rptLogo = new ReportParameter("rptLogo", imageLogo);
                    imageSign = new Uri(Server.MapPath(DS1.Tables[0].Rows[0]["Signature"].ToString())).AbsoluteUri;
                    rptSign = new ReportParameter("rptSign", imageSign);
                    imageFooter = new Uri(Server.MapPath(DS1.Tables[0].Rows[0]["Footer"].ToString())).AbsoluteUri;
                    rptFooter = new ReportParameter("rptFooter", imageFooter);
                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Letter edit line 439", DateTime.Now));

                    rds = new ReportDataSource("DataSet1", DS1.Tables[0]);
                 
                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Letter edit line 442", DateTime.Now));
                   
                    if (imageLogo == "")
                    {
                        imageLogo = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                        rptLogo = new ReportParameter("rptLogo", imageLogo);
                    }

                    if (imageFooter == "")
                    {
                        imageFooter = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                        rptFooter = new ReportParameter("rptFooter", imageFooter);
                    }

                    if (imageSign == "")
                    {
                        imageSign = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                        rptSign = new ReportParameter("rptSign", imageSign);
                    }                   
                }


                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 500", DateTime.Now));
                RptLetter.LocalReport.DataSources.Clear();
                RptLetter.LocalReport.EnableExternalImages = true;
                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Letter edit line 503", DateTime.Now));
                RptLetter.LocalReport.SetParameters(new ReportParameter[] { rptLogo, rptFooter, rptSign });
                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "Letter edit line 505", DateTime.Now));
                RptLetter.LocalReport.DataSources.Add(rds);
                RptLetter.LocalReport.Refresh();
                #endregion

                #region "--------Report download to Application route----------------"
                FunDeleteIMGFile("~/LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx");
                string FilePath = Server.MapPath("~/LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx");
                Microsoft.Reporting.WebForms.Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                if (RptLetter.LocalReport.ReportPath != null)
                {
                    byte[] bytes = RptLetter.LocalReport.Render("WORDOPENXML", null, out contentType, out encoding, out extension, out streamIds, out warnings);
                    FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);
                    byte[] data = new byte[fs.Length];
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                    fs.Dispose();

                    ///////////////////////////////////

                    LetterConfigBO objbon = new LetterConfigBO();
                    LetterConfigBAL objbaln = new LetterConfigBAL();

                    objbon.LetterConfig_ID = Convert.ToInt32(ViewState["LetterID"]);
                    objbon.Modified_BY = Convert.ToString(Session["ECode"]);
                    objbon.Mode = "EditLetterPath";
                    objbon.FilePath = "LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx";
                    objbaln.Update_Status(objbon);

                    //------------------------------commented due to network issue --------------------------
                    //string F_Path = Server.MapPath("~/LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx");
                    //Common.UploadFtpFile("LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx", F_Path);
                    //------------------------------commented due to network issue --------------------------

                    FunDeleteIMGFile("~/LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".pdf");

                    /////////////////////S office///////////////////////////////////

                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 601", DateTime.Now));
                    #region pdf generate using docx file. comment on hdfc argo server"
                    using (Process pdfprocess = new Process())
                    {
                        pdfprocess.StartInfo.UseShellExecute = true;
                        pdfprocess.StartInfo.LoadUserProfile = true;
                        pdfprocess.StartInfo.FileName = "soffice.exe";
                        pdfprocess.StartInfo.Arguments = "soffice  --headless --convert-to pdf " + Server.MapPath("~/LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx");
                        pdfprocess.StartInfo.WorkingDirectory = Server.MapPath("~/LetterConfig/");
                        pdfprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pdfprocess.Start();
                        if (!pdfprocess.WaitForExit(1000 * 60 * 1))
                        {
                            pdfprocess.Kill();
                        }
                        pdfprocess.Close();
                    }
                    #endregion
                    //////////////////////////////////Ms office///////////////////////////
                    WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", "line 625", DateTime.Now));
                    #region "Generate PDF using Interop.Word--comment on clover server"

                    //string PdfPathInput = Server.MapPath("LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".pdf");
                    //var appWord = new Application();

                    //if (appWord.Documents != null)
                    //{
                    //    //yourDoc is your word document
                    //    var wordDocument = appWord.Documents.Open(Server.MapPath("LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".docx"));
                    //    string pdfDocName = PdfPathInput;
                    //    if (wordDocument != null)
                    //    {
                    //        wordDocument.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                    //        wordDocument.Close();
                    //    }
                    //    appWord.Quit();
                    //}

                    #endregion
                    ///////////////////////

                    //string F_Path1 = Server.MapPath("~/LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".pdf");
                    //Common.UploadFtpFile("LetterConfig/Letter_" + ViewState["LetterID"].ToString() + ".pdf", F_Path1);

                }
                #endregion
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile("ConsoleLog.txt", String.Format("{0} @ {1}", ex.Message.ToString(), ex.Message.ToString() + " Date :" + DateTime.Now));
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            TextBox1.Text += DrpType.SelectedValue;
            DrpType.SelectedIndex = -1;
        }

        protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBox1.Text += DrpType.SelectedValue;
            DrpType.SelectedIndex = -1;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTextToCurrentPos();", true);
        }

        protected void BtnUpdateBelow_Click2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ImgHeader.ImageUrl))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Upload Header Image');", true);
                return;
            }

            if (string.IsNullOrEmpty(ImgFooter.ImageUrl))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Upload Footer Image');", true);
                return;
            }

            if (string.IsNullOrEmpty(ImgSign.ImageUrl))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Upload Singnature Image');", true);
                return;
            }

            string folderPath = Server.MapPath("~/ReportImg/");
            bool val = false;
            string Msg = "";
            try
            {
                if (ViewState["LetterName"] != null && ViewState["LetterID"] == null)
                {
                    //objbo.ImgPath = null;
                    objbo.CreatedBy = Session["ECode"].ToString();
                    objbo.LetterName = ViewState["LetterName"].ToString();
                    objbo.UPLOADType = "CREATE";
                    int LID = objbal.InsertLetterConfig(objbo);
                    if (LID != 0)
                    {
                        ViewState["LetterID"] = LID;
                    }
                }

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                
                //Header Img
                if (ImgHeader.ImageUrl.Contains(","))
                {
                    string base64_1 = ImgHeader.ImageUrl.Split(',')[1];
                    byte[] ImageBytes_1 = Convert.FromBase64String(base64_1);
                    MemoryStream ms1 = new MemoryStream(ImageBytes_1, 0, ImageBytes_1.Length);
                    ms1.Write(ImageBytes_1, 0, ImageBytes_1.Length);
                    FunDeleteIMGFile("~/ReportImg/Header_" + ViewState["LetterID"].ToString() + ".png");
                    System.Drawing.Image image1 = System.Drawing.Image.FromStream(ms1, true);
                    image1.Save(folderPath + "Header_" + ViewState["LetterID"].ToString() + ".png");
                    objbo.Header = "~/ReportImg/Header_" + ViewState["LetterID"].ToString() + ".png";


                    //------------------------------commented due to network issue --------------------------

                    //string F_Path = Server.MapPath("~/ReportImg/Header_" + ViewState["LetterID"].ToString() + ".png");
                    //Common.UploadFtpFile("ReportImg/Header_" + ViewState["LetterID"].ToString() + ".png", F_Path);

                    //------------------------------commented due to network issue --------------------------



                    //objbo.CreatedBy = Session["ECode"].ToString();
                    //objbo.ImageType = "Header";
                    //objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                    //val = objbal.InsertLetterDetails(objbo);
                    //if (val == true)
                    //{
                    //    if (Msg == "")
                    //    {
                    //        Msg = "Header ";
                    //    }
                    //    else
                    //    {
                    //        Msg = Msg + "& Header ";
                    //    }
                    //}
                }


                //Footer Img
                if (ImgFooter.ImageUrl.Contains(","))
                {
                    string base64_2 = ImgFooter.ImageUrl.Split(',')[1];
                    byte[] ImageBytes_2 = Convert.FromBase64String(base64_2);
                    MemoryStream ms2 = new MemoryStream(ImageBytes_2, 0, ImageBytes_2.Length);
                    ms2.Write(ImageBytes_2, 0, ImageBytes_2.Length);
                    FunDeleteIMGFile("~/ReportImg/Footer_" + ViewState["LetterID"].ToString() + ".png");
                    System.Drawing.Image image2 = System.Drawing.Image.FromStream(ms2, true);
                    image2.Save(folderPath + "Footer_" + ViewState["LetterID"].ToString() + ".png");
                    objbo.Footer = "~/ReportImg/Footer_" + ViewState["LetterID"].ToString() + ".png";

                    //------------------------------commented due to network issue --------------------------
                    //string F_Path = Server.MapPath("~/ReportImg/Footer_" + ViewState["LetterID"].ToString() + ".png");
                    //Common.UploadFtpFile("ReportImg/Footer_" + ViewState["LetterID"].ToString() + ".png", F_Path);
                    //------------------------------commented due to network issue --------------------------

                    //objbo.CreatedBy = Session["ECode"].ToString();
                    //objbo.ImageType = "Footer";
                    //objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                    //val = objbal.InsertLetterDetails(objbo);
                    //if (val == true)
                    //{
                    //    if (Msg == "")
                    //    {
                    //        Msg = "Footer ";
                    //    }
                    //    else
                    //    {
                    //        Msg = Msg + "& Footer ";
                    //    }
                    //}
                }

                //Signature Img
                if (ImgSign.ImageUrl.Contains(","))
                {
                    string base64_3 = ImgSign.ImageUrl.Split(',')[1];
                    byte[] ImageBytes_3 = Convert.FromBase64String(base64_3);
                    MemoryStream ms3 = new MemoryStream(ImageBytes_3, 0, ImageBytes_3.Length);
                    ms3.Write(ImageBytes_3, 0, ImageBytes_3.Length);
                    FunDeleteIMGFile("~/ReportImg/Signature_" + ViewState["LetterID"].ToString() + ".png");

                    System.Drawing.Image image3 = System.Drawing.Image.FromStream(ms3, true);
                    image3.Save(folderPath + "Signature_" + ViewState["LetterID"].ToString() + ".png");

                    objbo.Signature = "~/ReportImg/Signature_" + ViewState["LetterID"].ToString() + ".png";

                    //------------------------------commented due to network issue --------------------------
                    //string F_Path = Server.MapPath("~/ReportImg/Signature_" + ViewState["LetterID"].ToString() + ".png");
                    //Common.UploadFtpFile("ReportImg/Signature_" + ViewState["LetterID"].ToString() + ".png", F_Path);
                    //------------------------------commented due to network issue --------------------------

                    //objbo.CreatedBy = Session["ECode"].ToString();
                    //objbo.ImageType = "Signature";
                    //objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                    //val = objbal.InsertLetterDetails(objbo);
                    //if (val == true)
                    //{
                    //    if (Msg == "")
                    //    {
                    //        Msg = "Signature ";
                    //    }
                    //    else
                    //    {
                    //        Msg = Msg + "& Signature ";
                    //    }
                    //}
                }

                // Designation Img
                //if (ImgDesgn.ImageUrl.Contains(","))
                //{
                //    string base64 = ImgDesgn.ImageUrl.Split(',')[1];
                //    byte[] ImageBytes = Convert.FromBase64String(base64);
                //    MemoryStream ms = new MemoryStream(ImageBytes, 0, ImageBytes.Length);
                //    ms.Write(ImageBytes, 0, ImageBytes.Length);

                //    FunDeleteIMGFile("~/ReportImg/Designation_" + ViewState["LetterID"].ToString() + ".png");

                //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //    image.Save(folderPath + "Designation_" + ViewState["LetterID"].ToString() + ".png");
                //    objbo.Designation = "~/ReportImg/Designation_" + ViewState["LetterID"].ToString() + ".png";                    
                //}
                objbo.Designation = TxtSignatory.Text;
                objbo.Content = TextBox1.Text;
                //  objbo.ImgPath = TextArea1.InnerText.ToString();
                objbo.CreatedBy = Session["ECode"].ToString();
                //  objbo.ImageType = "Content";
                objbo.LetterID = Convert.ToInt16(ViewState["LetterID"]);
                val = objbal.InsertLetterDetails(objbo);
                if (val == true)
                {
                    if (Msg == "")
                    {
                        Msg = "Content ";
                    }
                    else
                    {
                        Msg = Msg + "& Content ";
                    }
                }
               
                if (Msg != "")
                {
                    //  generatew();
                    GenerateWordFile();
                    FunGetLetterEditRcords();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Letter Updated Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please update the letter!!');", true);
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLogging(this.Page.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message, ex.StackTrace);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error while generating report');", true);
            }
        }
    }
}