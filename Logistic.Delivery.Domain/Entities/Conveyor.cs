using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Domain.Entities
{
    public class Conveyor 
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string CarrierId { get; set; }
    }
}
