using Logistic.CrossCutting.Enums;
using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Dto.Dtos
{
    public class DeliveryDto : BaseProperties
    {
        public ConveyorDto Conveyor { get; set; }
        public RecipientDto Recipient { get; set; }
        public AddressDto Address { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
