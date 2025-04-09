using Logistic.Delivery.CrossCutting.BaseEntity;

namespace Logistic.Delivery.Infra.Interfaces.Base
{
    public interface IGenericRepository<T> where T : IModelBase
    {
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
