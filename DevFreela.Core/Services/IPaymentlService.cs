﻿using DevFreela.Core.Entities;

namespace DevFreela.Core.Services
{
    public interface IPaymentlService
    {
        //Task<bool> ProcessPayment(PaymentInfo paymentInfoInputModel);
        void ProcessPayment(PaymentInfo paymentInfoInputModel);
    }
}
