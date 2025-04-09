using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Dto.Dtos;

namespace Logistic.Delivery.Dto.Responses.Delivery
{
    public class DeliveryResponse
    {
        public DateTime CreatAt { get; set; }
        public string? Id { get; set; }
        public ConveyorDto Conveyor { get; set; }
        public RecipientDto Recipient { get; set; }
        public AddressDto Address { get; set; }
        public DeliveryStatus Status { get; set; }

    }
}
