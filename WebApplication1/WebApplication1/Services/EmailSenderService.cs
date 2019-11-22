using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class EmailSenderService : IEmailSenderServices
    {
        public Task SendEmail(EmailMessageDTO emailMessage)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("azatmkushman@yandex.kz");
            mail.To.Add(new MailAddress(emailMessage.To));
            mail.Subject = emailMessage.Title;
            mail.Body = emailMessage.Text;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.yandex.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("azatmkushman@yandex.kz", "AzatMukushman123");
            return client.SendMailAsync(mail);
        }
    }
}
