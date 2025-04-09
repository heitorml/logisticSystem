using Logistic.Delivery.Domain.Entities;

namespace Logistic.Delivery.Infra.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<DeliveryModel> AddAsync(DeliveryModel entity);
        Task DeleteAsync(DeliveryModel entity);
        Task<DeliveryModel> GetByIdAsync(string id);
        Task<DeliveryModel> UpdateAsync(DeliveryModel entity);
    }
}
