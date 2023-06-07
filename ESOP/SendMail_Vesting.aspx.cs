using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace ESOP
{
    public partial class SendMail_Vesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter To Address:");
            string to = Console.ReadLine().Trim();

            Console.WriteLine("Enter Subject:");
            string subject = Console.ReadLine().Trim();

            Console.WriteLine("Enter Body:");
            string body = Console.ReadLine().Trim();

            using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], to))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                Console.WriteLine("Sending Email......");
                smtp.Send(mm);
                Console.WriteLine("Email Sent.");
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}