using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Entities;
using MassTransit;

namespace Logistic.Delivery.Create.Worker.Sagas
{
    public class DeliveryCreateSagaData : SagaStateMachineInstance, ISagaVersion
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public Guid DeliveryId { get; set; }
        public bool Validate { get; set; }
        public bool Forecast { get; set; }
        public bool DocumentCreated { get; set; }
        public Conveyor Conveyor { get; set; }
        public Recipient Recipient { get; set; }
        public Address Address { get; set; }
        public DeliveryStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public int Version { get; set; } = 1;
    }
}
