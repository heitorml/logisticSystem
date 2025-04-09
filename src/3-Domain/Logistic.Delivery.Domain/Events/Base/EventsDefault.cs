using Logistic.CrossCutting.Enums;
using Logistic.Delivery.CrossCutting.BaseEntity;
using Logistic.Delivery.Domain.Entities;

namespace Logistic.Delivery.Domain.Events.Base
{
    public class EventsDefault : BaseProperties
    {
        public Conveyor Conveyor { get; set; }
        public Recipient Recipient { get; set; }
        public Address Address { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
