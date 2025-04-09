using ErrorOr;
using Logistic.Delivery.Infra.Interfaces;
using Logistic.Delivery.Infra.Interfaces.Base;
using Logistic.Delivery.Infra.Repositories.MongoDb;
using Microsoft.Extensions.Logging;

namespace Logistic.Delivery.Application.UseCases.Delivery.GetById
{
    public class GetDeliveryByIdUseCase : IGetDeliveryByIdUseCase
    {
        private readonly IDeliverySagaRepository _repository;
        private readonly ILogger<GetDeliveryByIdUseCase> _logger;

        public GetDeliveryByIdUseCase(
            IDeliverySagaRepository repository,
            ILogger<GetDeliveryByIdUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ErrorOr<DeliveryCreateSagaData>> Execute(string id)
        {
            var delivery = await _repository.GetByIdAsync(id);

            if (delivery is null)
                return Error.Failure("Not Found");

            return delivery;
        }
    }
}
