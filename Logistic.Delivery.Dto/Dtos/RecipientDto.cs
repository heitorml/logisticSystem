using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Dto.Dtos
{
    public class RecipientDto : BaseProperties
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
