using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Infra.Interfaces;
using Logistic.Delivery.Infra.Interfaces.Base;
using Logistic.Delivery.Infra.Repositories.MongoDb.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic.Delivery.Infra.Repositories.MongoDb
{
    public class DeliverySagaRepository : IDeliverySagaRepository
    {
        private readonly GenericRepository<DeliveryCreateSagaData> _database;

        public DeliverySagaRepository(IMongoDatabase MongoDatabase)
        {
            _database = new GenericRepository<DeliveryCreateSagaData>(MongoDatabase, "Delivery");
        }

        public async Task<DeliveryCreateSagaData> GetByIdAsync(string id)
          => await _database.GetByIdAsync(id);
    }
}
