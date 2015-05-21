using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFR.Helper
{
    public class SendMail
    {
        public string smtpServer { get; set; }
        public int smtpPort { get; set; }
        public string smtpAccount { get; set; }
        public string smtpPassword { get; set; }
        public string smtpFrom { get; set; }

        public void Send(string to, string subject, string body)
        {
            var smtp = new System.Net.Mail.SmtpClient(smtpServer, smtpPort);
            smtp.Credentials = new System.Net.NetworkCredential(smtpAccount, smtpPassword);
            var mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new System.Net.Mail.MailAddress(smtpFrom);
            mail.Priority = System.Net.Mail.MailPriority.Normal;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Subject = subject;
            mail.Body = body;
            smtp.Send(mail);
        }
    }
}
