using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XFAppiumPOC.EmailNotifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().SendEmail();
        }

        private void SendEmail()
        {
            // Email configuration
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "wft.alamgeer.ashraf@gmail.com";
            string smtpPassword = "nfwo emkh exlx ybtb";
            string senderEmail = "wft.alamgeer.ashraf@gmail.com";
            string recipientEmail = "wft.alamgeer.ashraf@gmail.com";

            // Create an email message
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);
            mail.Subject = "Mobile UI Automation Report";
            mail.Body = "Please find the attached HTML report.";

            // Attach the HTML report file
            string androidFilePath = "/Users/alamgeer/buildAgentFull (1)/work/9ec880e1a311ca6d/TestResults/Android-TestResults.html";
            string iOSFilePath = "/Users/alamgeer/buildAgentFull (1)/work/9ec880e1a311ca6d/TestResults/iOS-TestResults.html";
            mail.Attachments.Add(new Attachment(androidFilePath, MediaTypeNames.Text.Html));
            mail.Attachments.Add(new Attachment(iOSFilePath, MediaTypeNames.Text.Html));

            // Create an SMTP client and send the email
            SmtpClient smtpClient = new SmtpClient(smtpServer);
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true; // Use SSL if your SMTP server supports it

            try
            {
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                mail.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
