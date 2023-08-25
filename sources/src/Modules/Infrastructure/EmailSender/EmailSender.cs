using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            MailMessage m = new MailMessage(from, to, subject, body);
            m.IsBodyHtml = true;
            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("nikolai200290@gmail.com", "huqjnqzfqrisiwfo");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
