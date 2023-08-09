using Payment.API.Models.Requests.Payment;

namespace Payment.API.Services.Abstract
{
    public interface IPaymentService
    {
        bool Pay(CreatePaymentRequest request);
    }
}
