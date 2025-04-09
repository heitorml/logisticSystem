using ErrorOr;
using Logistic.Delivery.Application.Mappers.Delivery;
using Logistic.Delivery.Dto.Requests.Delivery;
using Logistic.Delivery.Dto.Responses.Delivery;
using Logistic.Delivery.Infra.Interfaces;
using Microsoft.Extensions.Logging;

namespace Logistic.Delivery.Application.UseCases.Delivery.SetDeliveryStatus
{
    public class SetDeliveryStatusUseCase : ISetDeliveryStatusUseCase
    {
        private readonly IDeliveryRepository _repository;
        private readonly ILogger<SetDeliveryStatusUseCase> _logger;

        public SetDeliveryStatusUseCase(
            IDeliveryRepository repository,
            ILogger<SetDeliveryStatusUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ErrorOr<DeliveryResponse>> Execute(DeliveryRequest request)
        {
            var delivery = await _repository.GetByIdAsync(request.DeliveryId);

            if (delivery == null)
                return Error.Failure(request.DeliveryId, "Not Found.");

            delivery.Status = request.Status;
            var result = await _repository.UpdateAsync(delivery);
            return result.ToResponse();
        }
    }
}
