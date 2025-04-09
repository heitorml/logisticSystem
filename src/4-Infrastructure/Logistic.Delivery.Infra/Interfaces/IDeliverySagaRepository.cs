using Logistic.Delivery.Infra.Interfaces.Base;

namespace Logistic.Delivery.Infra.Interfaces
{
    public interface IDeliverySagaRepository
    {
        //Task<DeliveryModel> AddAsync(DeliveryModel entity);
        //Task DeleteAsync(DeliveryModel entity);
        Task<DeliveryCreateSagaData> GetByIdAsync(string id);
        // Task<DeliveryModel> UpdateAsync(DeliveryModel entity);
    }
}
