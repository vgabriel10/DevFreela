using DevFreela.Core.Entities;

namespace DevFreela.Core.Services
{
    public interface IPaymentlService
    {
        Task<bool> ProcessPayament(PaymentInfo paymentInfoInputModel);
    }
}
