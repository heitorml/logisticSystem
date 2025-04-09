using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Dto.Dtos
{
    public class ConveyorDto : BaseProperties
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string CarrierId { get; set; }
    }
}
