using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Xml;
using Xceed.Document.NET;
using Aspose.Words.Replacing;
using Aspose.Words;

namespace ESOP
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            string EmailTemPath = Server.MapPath("~/EmailTemplate/LetterOfGrant.html");
            string body = string.Empty;
            //using (StreamReader reader = new StreamReader(EmailTemPath))
            //{
            //    body = reader.ReadToEnd();
            //}
            //body = body.Replace("{UserName}", objEntity.userName); //replacing the required things           
            //body = body.Replace("{UsernameRole}", Convert.ToString(HttpContext.Current.Session["RoleName"].ToString() + "-" + HttpContext.Current.Session["LoginID"].ToString()));
            //body = body.Replace("{InsuredCompany}", Convert.ToString(objEntity.InsuredCompany));
            //body = body.Replace("{CaseType}", objEntity.CaseType);
            //body = body.Replace("{CaseID}", Convert.ToString(objEntity.CaseID));
            //body = body.Replace("{Remark}", Convert.ToString(objEntity.Remark));
            //body = body.Replace("{Role}", Convert.ToString(objEntity.Role));
            //body = body.Replace("{password}", Convert.ToString(objEntity.password));
            using (MailMessage mailMessage = new MailMessage())
            {
                LetterOfGrant("LetterDate", "09/09/2020");
                string CCMail = string.Empty;
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailMessage.Subject = "Test";
                mailMessage.Body = "Testing";
                mailMessage.IsBodyHtml = true;
                // mailMessage.To.Add(new MailAddress(objEntity.EmailID));
                if (ConfigurationManager.AppSettings["CCMail"] != "")
                    CCMail += ConfigurationManager.AppSettings["CCMail"];
                else
                    CCMail += "";
                //CCMail = ;
                string[] ToEmail = CCMail.Split(',');
                foreach (string ToEMailId in ToEmail)
                {
                    if (ToEMailId != "")
                    {
                        mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id
                    }
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                smtp.Send(mailMessage);
                //return body;//return true;
            }

        }
        //private void btnCreateDocument_Click(object sender, EventArgs e)
        //{
        //    string DirectoryPath = System.Text.RegularExpressions.Regex.Replace(Environment.CurrentDirectory, @"\\([^\\])+\\([^\\])+(\\)?$", "");
        //    // below is the HTML Template File Path.
        //    string DocumentTemplate = Utility.GetTemplateString(DirectoryPath + "\\CreateDocTemplate.htm");
        //    if (!string.IsNullOrEmpty(DocumentTemplate))
        //    {
        //        //if Template have Content than it replace the below text content with actual values.
        //        DocumentTemplate = DocumentTemplate.Replace("$NameOfApplicant$", "A.V.Mahesh Nair");
        //        DocumentTemplate = DocumentTemplate.Replace("$District$", "Malappuram");
        //        DocumentTemplate = DocumentTemplate.Replace("$DateOfBirth$", "7th Dec. 1980");
        //        // from here you can create any two type of file (doc / html).
        //        // first parameter is the Actual HTML Content with data and second parameter is the documnet file path.
        //        // This method automatically creats the doc file at the given location.
        //        string strTicks = DateTime.Now.Ticks.ToString();
        //        docFileNameWithPath = DirectoryPath + "\\" + strTicks + "CreateDoc.doc";
        //        Utility.CreateDataFile(DocumentTemplate, docFileNameWithPath);
        //        if (File.Exists(docFileNameWithPath))
        //            Process.Start(docFileNameWithPath);
        //    }
        //}

        //private DocX GetRejectionLetterTemplate()
        //{
        //    // Adjust the path so suit your machine:
        //    string fileName = @"E:\DocXExample.docx";

        //    // Set up our paragraph contents:
        //    string headerText = "STRICTLY PERSONAL AND CONFIDENTIAL";
        //    string letterBodyText = DateTime.Now.ToShortDateString();
        //    string paraTwo = ""
        //        + "Letter Date"
        //        + "Reference No. : ESOP-09-G-"
        //        + "Dear %APPLICANT%" + Environment.NewLine + Environment.NewLine
        //        + "I am writing to thank you for your resume. Unfortunately, your skills and "
        //        + "experience do not match our needs at the present time. We will keep your "
        //        + "resume in our circular file for future reference. Don't call us, we'll call you. "
        //        + Environment.NewLine + Environment.NewLine
        //        + "Sincerely, "
        //        + Environment.NewLine + Environment.NewLine
        //        + "Jim Smith, Corporate Hiring Manager";

        //    // Title Formatting:
        //    //var titleFormat = new Formatting();
        //    //titleFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
        //    //titleFormat.Size = 18D;
        //    //titleFormat.Position = 12;

        //    // Body Formatting
        //    //var paraFormat = new Formatting();
        //    //paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
        //    //paraFormat.Size = 10D;
        //    //titleFormat.Position = 12;

        //    // Create the document in memory:
        //    var doc = DocX.Create(fileName);

        //    // Insert each prargraph, with appropriate spacing and alignment:
        //    Paragraph title = doc.InsertParagraph(headerText);
        //    title.Alignment = Alignment.center;

        //    doc.InsertParagraph(Environment.NewLine);
        //    Paragraph letterBody = doc.InsertParagraph(letterBodyText);
        //    letterBody.Alignment = Alignment.both;

        //    doc.InsertParagraph(Environment.NewLine);
        //    doc.InsertParagraph(paraTwo);

        //    return doc;

        //}

        public void LetterOfGrant(string applicantField, string applicantName)
        {


            Aspose.Words.Document doc = new Aspose.Words.Document(@"E:\ESOP Process.docx");
            doc.Range.Replace("<<LetterDate>>", "09/09/2020", new FindReplaceOptions(FindReplaceDirection.Forward));
            // Save the Word document
            doc.Save(@"E:\Find-And-Replace-Text.docx");


            //// We will need a file name for our output file (change to suit your machine):
            //string fileNameTemplate = @"E:\DocXExample.docx";

            //// Let's save the file with a meaningful name, including the applicant name and the letter date:
            //string outputFileName = string.Format(fileNameTemplate, applicantName, DateTime.Now.ToString("MM-dd-yy"));

            //// Grab a reference to our document template:
            //DocX letter = this.GetRejectionLetterTemplate();

            //// Perform the replace:
            //letter.ReplaceText(applicantField, applicantName);

            //// Save as New filename:
            //letter.SaveAs(outputFileName);

            // Open in word:
            //Process.Start("WINWORD.EXE", "\"" + outputFileName + "\"");
        }
    }
}