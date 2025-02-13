using DevFreela.Core.Entities;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentlService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentsBaseUrl;
        private readonly IMessageBusService _messageBusService;
        private const string QUERE_NAME = "Payments";

        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMessageBusService messageBusService)
        {
            _httpClientFactory = httpClientFactory;
            _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
            _messageBusService = messageBusService;
        }

        public void ProcessPayment(PaymentInfo paymentInfoInputModel)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoInputModel);
            var  paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUERE_NAME, paymentInfoBytes);
            
        }

        //public async Task<bool> ProcessPayment(PaymentInfo paymentInfoInputModel)
        //{
        //    var url = $"{_paymentsBaseUrl}/api/payments";

        //    var paymentInfoJson = JsonSerializer.Serialize(paymentInfoInputModel);

        //    using var paymentInfoContent = new StringContent(
        //        paymentInfoJson,
        //        Encoding.UTF8,
        //        "application/json"
        //        );

        //    var httpClient = _httpClientFactory.CreateClient("Payments");

        //    var response = await httpClient.PostAsync(url, paymentInfoContent);

        //    return response.IsSuccessStatusCode;
        //}
    }
}
