namespace EITBackend.Common.Services.IServices
{
    public interface IEmailService
    {
        public void sendEmail(string reciver, string subject, string body);
    }
}
