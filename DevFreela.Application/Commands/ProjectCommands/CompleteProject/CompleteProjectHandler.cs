using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.ProjectCommands.CompleteProject
{
    public class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        private readonly IPaymentlService _paymentService;

        public CompleteProjectHandler(IProjectRepository repository, IPaymentlService paymentlService)
        {
            _repository = repository;
            _paymentService = paymentlService;
        }
        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            if (project is null)
                return ResultViewModel.Error("Projeto não existe!");

            project.Completed();

            var paymentInfoDto = new PaymentInfoInputModel(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, project.TotalCost);
            var paymentInfo = PaymentInfoInputModel.FromEntity(paymentInfoDto);
            await _paymentService.ProcessPayment(paymentInfo);

            project.SetPaymentPending();

            await _repository.Update(project);

            return ResultViewModel.Sucess();
        }
    }
}
