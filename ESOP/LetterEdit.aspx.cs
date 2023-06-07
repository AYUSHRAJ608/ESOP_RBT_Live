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

namespace ESOP
{
    public partial class LetterEdit : System.Web.UI.Page
    {
        LetterEditBO objbo = new LetterEditBO();
        LetterEditBAL objbal = new LetterEditBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FunGetLetterEditRcords();
            }

        }
        public void FunGetLetterEditRcords()
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = objbal.GetLetterEditDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        if (ds.Tables[0].Rows[i]["SECTION"].ToString() == "Header")
                        {

                            ImgHeader.ImageUrl = ds.Tables[0].Rows[i]["PATH"].ToString().Trim() + "?time=" + DateTime.Now.ToString();

                        }

                        if (ds.Tables[0].Rows[i]["SECTION"].ToString() == "Footer")
                        {

                            ImgFooter.ImageUrl = ds.Tables[0].Rows[i]["PATH"].ToString().Trim() + "?time=" + DateTime.Now.ToString();
                        }

                        if (ds.Tables[0].Rows[i]["SECTION"].ToString() == "Signature")
                        {

                            ImgSign.ImageUrl = ds.Tables[0].Rows[i]["PATH"].ToString().Trim() + "?time=" + DateTime.Now.ToString();
                        }

                        if (ds.Tables[0].Rows[i]["SECTION"].ToString() == "Designation")
                        {

                            ImgDesgn.ImageUrl = ds.Tables[0].Rows[i]["PATH"].ToString().Trim() + "?time=" + DateTime.Now.ToString();
                        }

                        if (ds.Tables[0].Rows[i]["SECTION"].ToString() == "Content")
                        {

                            TxtLetterDate.Text = ds.Tables[0].Rows[i]["PATH"].ToString().Trim();
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            bool val = false;
            string folderPath = Server.MapPath("~/ReportImg/");

            try
            {
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
                    FunDeleteIMGFile("~/ReportImg/Header.png");
                    System.Drawing.Image image1 = System.Drawing.Image.FromStream(ms1, true);
                    image1.Save(folderPath + "Header.png");
                    objbo.ImgPath = "~/ReportImg/Header.png";
                    objbo.CreatedBy = Session["ECode"].ToString();
                    objbo.ImageType = "Header";
                    val = objbal.InsertLetterDetails(objbo);
                    if (val == true)
                    { }
                }


                //Footer Img
                if (ImgFooter.ImageUrl.Contains(","))
                {
                    string base64_2 = ImgFooter.ImageUrl.Split(',')[1];
                    byte[] ImageBytes_2 = Convert.FromBase64String(base64_2);
                    MemoryStream ms2 = new MemoryStream(ImageBytes_2, 0, ImageBytes_2.Length);
                    ms2.Write(ImageBytes_2, 0, ImageBytes_2.Length);
                    FunDeleteIMGFile("~/ReportImg/Footer.png");
                    System.Drawing.Image image2 = System.Drawing.Image.FromStream(ms2, true);
                    image2.Save(folderPath + "Footer.png");
                    objbo.ImgPath = "~/ReportImg/Footer.png";
                    objbo.CreatedBy = Session["ECode"].ToString();
                    objbo.ImageType = "Footer";
                    val = objbal.InsertLetterDetails(objbo);
                    if (val == true)
                    { }
                }


                //Signature Img
                if (ImgSign.ImageUrl.Contains(","))
                {
                    string base64_3 = ImgSign.ImageUrl.Split(',')[1];
                    byte[] ImageBytes_3 = Convert.FromBase64String(base64_3);
                    MemoryStream ms3 = new MemoryStream(ImageBytes_3, 0, ImageBytes_3.Length);
                    ms3.Write(ImageBytes_3, 0, ImageBytes_3.Length);
                    FunDeleteIMGFile("~/ReportImg/Signature.png");

                    System.Drawing.Image image3 = System.Drawing.Image.FromStream(ms3, true);
                    image3.Save(folderPath + "Signature.png");

                    objbo.ImgPath = "~/ReportImg/Signature.png";
                    objbo.CreatedBy = Session["ECode"].ToString();
                    objbo.ImageType = "Signature";
                    val = objbal.InsertLetterDetails(objbo);
                    if (val == true)
                    { }
                }

                if (val == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File Uploaded Successfully');", true);
                    FunGetLetterEditRcords();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnUpdateBelow_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/ReportImg/");
            bool val = false;
            string Msg = "";
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Designation Img
                if (ImgDesgn.ImageUrl.Contains(","))
                {
                    string base64 = ImgDesgn.ImageUrl.Split(',')[1];
                    byte[] ImageBytes = Convert.FromBase64String(base64);
                    MemoryStream ms = new MemoryStream(ImageBytes, 0, ImageBytes.Length);
                    ms.Write(ImageBytes, 0, ImageBytes.Length);

                    FunDeleteIMGFile("~/ReportImg/Designation.png");

                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    image.Save(folderPath + "Designation.png");
                    objbo.ImgPath = "~/ReportImg/Designation.png";
                    objbo.CreatedBy = Session["ECode"].ToString();
                    objbo.ImageType = "Designation";
                    val = objbal.InsertLetterDetails(objbo);
                    if (val == true)
                    {
                        Msg = "Signature ";
                    }
                }

                objbo.ImgPath = TxtLetterDate.Text.ToString();
                objbo.CreatedBy = Session["ECode"].ToString();
                objbo.ImageType = "Content";
                val = objbal.InsertLetterDetails(objbo);
                if (val == true)
                {
                    if (Msg == "")
                    {
                        Msg = "Letter Date ";
                    }
                    else
                    {
                        Msg = Msg + "& Letter Date ";
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Msg + " Updated Successfully');", true);
                }
                FunGetLetterEditRcords();

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
        protected void LnkDesign_Click(object sender, EventArgs e)
        {
            if (FileUploadDesignation.HasFile)
            {
                System.IO.Stream fs = FileUploadDesignation.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                ImgDesgn.ImageUrl = "data:image/png;base64," + base64String;
            }
        }

        #endregion

        #region "---------------Delete Image----------------------------------------------------"


        protected void LnkHeaderDelete_Click(object sender, EventArgs e)
        {
            FunDeleteIMGFile("~/ReportImg/Header.png");
            //ImgHeader.ImageUrl = null;
            objbo.ImageType = "Header";
            bool val = objbal.DeleteLetterDetails(objbo);
            if (val == true)
            {
                ImgHeader.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                FunGetLetterEditRcords();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Header Image Deleted Successfully');", true);
            }
        }

        protected void LnkFooterDelete_Click(object sender, EventArgs e)
        {
            FunDeleteIMGFile("~/ReportImg/Footer.png");
            //ImgFooter.ImageUrl = null;
            objbo.ImageType = "Footer";
            bool val = objbal.DeleteLetterDetails(objbo);
            if (val == true)
            {
                ImgFooter.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                FunGetLetterEditRcords();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Footer Image Deleted Successfully');", true);
            }
        }

        protected void LnkSignDelete_Click(object sender, EventArgs e)
        {
            FunDeleteIMGFile("~/ReportImg/Signature.png");
            //ImgSign.ImageUrl = null;
            objbo.ImageType = "Signature";
            bool val = objbal.DeleteLetterDetails(objbo);
            if (val == true)
            {
                ImgSign.ImageUrl = null + "?time=" + DateTime.Now.ToString();
                FunGetLetterEditRcords();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Signature Image Deleted Successfully');", true);
            }
        }

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
            GenerateReport();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        public void GenerateReport()
        {
            DataSet ds = new DataSet();
            #region "--------------------Creating RDLC report--------------------------"
            ReportDataSource rds = new ReportDataSource();
            RptLetter.ProcessingMode = ProcessingMode.Local;
            RptLetter.LocalReport.ReportPath = Server.MapPath(@"~\ReportDesigns\rpt_Mail.rdlc");

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

            DataSet DS1 = new DataSet();
            DS1 = objbal.GetReportDesign(objbo);
            if (DS1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= DS1.Tables[0].Rows.Count - 1; i++)
                {
                    if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Header")
                    {
                        imageLogo = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                        rptLogo = new ReportParameter("rptLogo", imageLogo);
                    }

                    if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Footer")
                    {
                        imageFooter = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                        rptFooter = new ReportParameter("rptFooter", imageFooter);
                    }

                    if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Signature")
                    {
                        imageSign = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                        rptSign = new ReportParameter("rptScannedSignatureImg", imageSign);
                    }

                    if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Designation")
                    {
                        imageDesignation = new Uri(Server.MapPath(DS1.Tables[0].Rows[i]["PATH"].ToString())).AbsoluteUri;
                        rptDesignation = new ReportParameter("rptDesignation", imageDesignation);
                    }

                    if (DS1.Tables[0].Rows[i]["SECTION"].ToString() == "Content")
                    {
                        rp = new ReportParameter("rptLetterDate", DS1.Tables[0].Rows[i]["PATH"].ToString());
                    }
                }
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

                if (imageDesignation == "")
                {
                    imageDesignation = new Uri(Server.MapPath("~/img/ByDefault.png")).AbsoluteUri;
                    rptDesignation = new ReportParameter("rptDesignation", imageDesignation);
                }
            }

            //-----------------------Table Part----------------------
            objbo.EMPCODE = "CI4197";
            //objbo.GrantID = 17786;
            ds = objbal.report(objbo);
            if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
            {
                ReportParameter rp1 = new ReportParameter("rptTrancheCode", ds.Tables[0].Rows[0]["grant_name"].ToString());
                ReportParameter rp2 = new ReportParameter("rptSrNo", ds.Tables[0].Rows[0]["grant_id"].ToString());
                ReportParameter rp3 = new ReportParameter("rptEmployeeFullName", ds.Tables[0].Rows[0]["EMP_NAME"].ToString());
                ReportParameter rp4 = new ReportParameter("rptEmpCode", ds.Tables[0].Rows[0]["ECODE"].ToString());
                string[] Firstname = ds.Tables[0].Rows[0]["EMP_NAME"].ToString().Split(new char[] { ' ' });
                ReportParameter rp5 = new ReportParameter("rptEmplyeeFirstName", Firstname[0].ToString());
                ReportParameter rp6 = new ReportParameter("rptNoOptionsGranted", ds.Tables[0].Rows[0]["no_of_options"].ToString());
                ReportParameter rp7 = new ReportParameter("rptGrantPrice", ds.Tables[0].Rows[0]["Grant_Price"].ToString());
                ReportParameter rp8 = new ReportParameter("rptGrantDate", ds.Tables[0].Rows[0]["Grant_Date"].ToString());
                // ReportParameter rp9 = new ReportParameter("rptDesignation", ds.Tables[0].Rows[0]["rolename"].ToString());
                ReportParameter rp10 = null;
                ReportParameter rp11 = null;
                ReportParameter rp12 = null;

                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    string Type = (i + 1).ToString();
                    switch (Type)
                    {
                        case "1":
                            {
                                rp10 = new ReportParameter("rptGrantDate1", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                            }
                            break;
                        case "2":
                            {
                                rp11 = new ReportParameter("rptGrantDate2", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years and the balance");
                            }
                            break;
                        case "3":
                            {
                                rp12 = new ReportParameter("rptGrantDate3", ds.Tables[1].Rows[i]["PERCENTAGE"].ToString() + "% granted options would Vest on " + ds.Tables[1].Rows[i]["VESTING_DATE"].ToString() + " +" + ds.Tables[1].Rows[i]["duration"].ToString() + " Years");
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (rp10 == null)
                {
                    rp10 = new ReportParameter("rptGrantDate1", "");
                }
                if (rp11 == null)
                {
                    rp11 = new ReportParameter("rptGrantDate2", "");
                }

                if (rp12 == null)
                {
                    rp12 = new ReportParameter("rptGrantDate3", "");
                }

                RptLetter.LocalReport.DataSources.Clear();
                RptLetter.LocalReport.SetParameters(new ReportParameter[] { rptLogo, rptFooter, rptSign, rptDesignation, rp, rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp10, rp11, rp12 });
                rds = new ReportDataSource("DT_GRANT_DETAILS", ds.Tables[0]);
                RptLetter.LocalReport.DataSources.Add(rds);
                RptLetter.LocalReport.Refresh();
            }

            #endregion
        }
    }
}