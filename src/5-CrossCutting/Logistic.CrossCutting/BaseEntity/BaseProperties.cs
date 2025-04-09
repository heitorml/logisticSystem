namespace Logistic.Delivery.CrossCutting.BaseEntity
{
    public class BaseProperties : IModelBase
    {
        public DateTime CreatAt { get; set; }
        public Guid DeliveryId { get; set; }
        public Guid CorrelationId { get; set; }
        public string? Id { get ; set; }
    }
}
