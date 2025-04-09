using Logistic.CrossCutting.Enums;
using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Domain.Entities
{
    public class DeliveryModel : BaseProperties
    {
        public Conveyor Conveyor { get; set; }
        public Recipient Recipient { get; set; }
        public Address Address { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
