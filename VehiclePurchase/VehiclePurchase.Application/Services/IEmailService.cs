using VehiclePurchase.Application.DTOs;

namespace VehiclePurchase.Application.Services
{
    public interface IEmailService
    {
        void Send(EmailRequest request);
    }
}
