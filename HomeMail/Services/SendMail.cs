using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HomeMail.Services
{
    class SendMail
    {
        public void Send(string to)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.yandex.ru");

            mail.From = new MailAddress("ivan.barabanov@simbirsoft.com");
            mail.To.Add(to);
            mail.Subject = "Работа из дома";
            mail.Body = "Работа из дома";

            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.yandex.ru";
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ivan.barabanov@simbirsoft.com", "h6E4KcT32!");

            SmtpServer.Send(mail);
        }
    }
}
