using Logistic.CrossCutting.Enums;
using Logistic.Delivery.CrossCutting.BaseEntity;
using Logistic.Delivery.Domain.Entities;

namespace Logistic.Delivery.Infra.Interfaces.Base
{
    public class DeliveryCreateSagaData : IModelBase
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
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int Version { get; set; } = 1;
        public string? Id { get; set; }
    }
}