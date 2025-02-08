
using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class PaymentInfoInputModel
    {
        public PaymentInfoInputModel(int idProject, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
        {
            IdProject = idProject;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Amount = amount;
        }

        public int IdProject { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }

        public static PaymentInfo FromEntity(PaymentInfoInputModel inputModel)
           => new PaymentInfo(inputModel.IdProject,inputModel.CreditCardNumber,inputModel.Cvv,inputModel.ExpiresAt,inputModel.FullName,inputModel.Amount);
    }
}
