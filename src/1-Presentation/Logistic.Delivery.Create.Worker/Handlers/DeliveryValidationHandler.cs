using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Domain.Events.DeliveryEvents;
using MassTransit;

namespace Logistic.Delivery.Create.Worker.Handlers
{
    public class DeliveryValidationHandler (ILogger<DeliveryValidationHandler> logger) 
        : IConsumer<DeliveryRequested>
    {
        public async Task Consume(ConsumeContext<DeliveryRequested> context)
        {
            logger.LogInformation("Em execução DeliveryValidationHandler");

            var @event = new DeliveryModel()
            {
                Address = context.Message.Address,
                Conveyor = context.Message.Conveyor,
                CreatAt = DateTime.UtcNow,
                DeliveryId = context.Message.DeliveryId,
                Recipient = context.Message.Recipient,
                Status = DeliveryStatus.Validated,
                CorrelationId = context.Message.CorrelationId,
            };


            logger.LogInformation("DeliveryValidationHandler Executado");
        }
    }
}
