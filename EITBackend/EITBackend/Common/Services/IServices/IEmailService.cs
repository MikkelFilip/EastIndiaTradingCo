using EITBackend.Common.DTOs;

namespace EITBackend.Common.Services.IServices
{
    public interface IEmailService
    {
        public void sendEmil(string reciver, string subject, string body);
    }
}
