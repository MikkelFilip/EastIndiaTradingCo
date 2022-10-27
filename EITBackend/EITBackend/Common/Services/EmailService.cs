using System.Net.Mail;
using System.Net;

namespace EITBackend.Common.Services
{
    public class Class
    {
        public void sendEmil(string reciver, string subject, string body)
        {

        var fromAddress = new MailAddress("eastindiatrading4thewin@gmail.com");
        var toAddress = new MailAddress(reciver);
        const string fromPassword = "opbzxyhutstrpylg";

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
