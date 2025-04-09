using ErrorOr;
using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Application.Mappers.Delivery;
using Logistic.Delivery.Application.UseCases.Delivery.Create;
using Logistic.Delivery.Domain.Events.DeliveryEvents;
using Logistic.Delivery.Dto.Requests.Delivery;
using Logistic.Delivery.Dto.Responses.Delivery;
using Logistic.Delivery.Infra.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Logistic.Delivery.Application.UseCases.Delivery.Canceled
{
    public class DeliveryCanceledUseCase : IDeliveryCanceledUseCase
    {
        private readonly IDeliveryRepository _repository;
        private readonly ILogger<DeliveryCanceledUseCase> _logger;
        private readonly IBus _sendEventService;

        public DeliveryCanceledUseCase(
            IDeliveryRepository repository, 
            ILogger<DeliveryCanceledUseCase> logger, 
            IBus sendEventService)
        {
            _repository = repository;
            _logger = logger;
            _sendEventService = sendEventService;
        }

        public async Task<ErrorOr<DeliveryResponse>> Execute(DeliveryRequest request)
        {
            var cancelDelivery = request.ToModel(DeliveryStatus.Created);
            var result = await _repository.AddAsync(cancelDelivery);

            var @event = cancelDelivery.ToEvent(request.Status);

            await _sendEventService.Publish((DeliveryCreated)@event);

            return result.ToResponse();
        }
    }
}
