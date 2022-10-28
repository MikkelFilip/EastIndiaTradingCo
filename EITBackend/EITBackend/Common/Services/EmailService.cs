using System.Net.Mail;
using System.Net;
using EITBackend.Common.Services.IServices;

namespace EITBackend.Common.Services
{
    public class EmailService: IEmailService
    {
        public void sendEmail(string reciver, string subject, string body)
        {

        var fromAddress = new MailAddress("eit4thewin@gmail.com");
        var toAddress = new MailAddress(reciver);
        const string fromPassword = "clclzgjoukjcpvpe";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
        }
        }
}
