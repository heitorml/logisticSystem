using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Infra.Interfaces;
using Logistic.Delivery.Infra.Repositories.MongoDb.Base;
using MongoDB.Driver;

namespace Logistic.Delivery.Infra.Repositories.MongoDb
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly GenericRepository<DeliveryModel> _database;

        public DeliveryRepository(IMongoDatabase MongoDatabase)
        {
            _database = new GenericRepository<DeliveryModel>(MongoDatabase, "Delivery");
        }

        public async Task<DeliveryModel> AddAsync(DeliveryModel entity)
          => await _database.AddAsync(entity);

        public async Task DeleteAsync(DeliveryModel entity)
          => await _database.DeleteAsync(entity);

        public async Task<DeliveryModel> GetByIdAsync(string id)
          => await _database.GetByIdAsync(id);

        public async Task<DeliveryModel> UpdateAsync(DeliveryModel entity)
          => await _database.UpdateAsync(entity);
    }
}
