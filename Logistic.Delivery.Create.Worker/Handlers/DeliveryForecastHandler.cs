using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Domain.Events.DeliveryEvents;
using MassTransit;

namespace Logistic.Delivery.Create.Worker.Handlers
{
    public class DeliveryForecastHandler(ILogger<DeliveryForecastHandler> logger) 
        : IConsumer<DeliveryValidated>
    {
        public async Task Consume(ConsumeContext<DeliveryValidated> context)
        {
            logger.LogInformation("Em execução DeliveryForecastHandler");

            var @event = new DeliveryModel()
            {
                Address = context.Message.Address,
                Conveyor = context.Message.Conveyor,
                CreatAt = DateTime.UtcNow,
                DeliveryId = context.Message.DeliveryId,
                Recipient = context.Message.Recipient,
                Status = DeliveryStatus.ForecastCreated,
                CorrelationId = context.Message.CorrelationId,
            };

            logger.LogInformation("DeliveryForecastHandler Executado");
        }
    }
}
