using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Domain.Entities
{
    public class Carrier : BaseProperties
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
