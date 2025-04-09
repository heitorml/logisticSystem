using Logistic.Delivery.CrossCutting.BaseEntity;
using Logistic.Delivery.Domain.Entities;

namespace Logistic.Delivery.Domain.Events.OrderEvents
{
    public class OrderReceived : BaseProperties
    {
        public Conveyor Conveyor { get; set; }
        public Recipient Recipient { get; set; }
        public Address Address { get; set; }

    }
}
