using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Entities;

namespace Logistic.Delivery.Domain.Events.DeliveryEvents
{
    public class DeliveryCreated
    {
        public DateTime CreatAt { get; set; }
        public Guid DeliveryId { get; set; }
        public Guid CorrelationId { get; set; }
        public Conveyor Conveyor { get; set; }
        public Recipient Recipient { get; set; }
        public Address Address { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
