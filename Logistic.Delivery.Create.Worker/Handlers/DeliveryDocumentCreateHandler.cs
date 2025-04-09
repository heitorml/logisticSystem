using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Domain.Events.DeliveryEvents;
using MassTransit;

namespace Logistic.Delivery.Create.Worker.Handlers
{
    public class DeliveryDocumentCreateHandler(ILogger<DeliveryDocumentCreateHandler> logger) 
        : IConsumer<DeliveryForecastCreated>
    {
        public async Task Consume(ConsumeContext<DeliveryForecastCreated> context)
        {
            logger.LogInformation("Em execução DeliveryDocumentCreateHandler");

            var @event = new DeliveryModel()
            {
                Address = context.Message.Address,
                Conveyor = context.Message.Conveyor,
                CreatAt = DateTime.UtcNow,
                DeliveryId = context.Message.DeliveryId,
                Recipient = context.Message.Recipient,
                Status = DeliveryStatus.DocumentCreated,
                CorrelationId = context.Message.CorrelationId
            };

            //Processamento das Regras de Negócio 

            //Integrações

            //Ações

            logger.LogInformation("DeliveryDocumentCreateHandler Executado");
        }
    }
}
