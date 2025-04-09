using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Entities;

namespace Logistic.Delivery.Dto.Requests.Delivery
{
    public class DeliveryRequest
    {
        public string? DeliveryId { get; set; }
        public Conveyor Conveyor { get; set; }
        public Recipient Recipient { get; set; }
        public Address Address { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
