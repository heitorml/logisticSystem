using Logistic.Delivery.CrossCutting.BaseEntity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Logistic.Delivery.Infra.Repositories.MongoDb.Base
{
    public class GenericRepository<T> where T : IModelBase
    {
        public IMongoCollection<T> MongoCollection { get; }
        public FilterDefinitionBuilder<T> FilterDefinitionBuilder { get; set; }
        public GenericRepository(
            IMongoDatabase mongoDatabase,
            string entityName)
        {
            MongoCollection = mongoDatabase.GetCollection<T>(entityName);
            FilterDefinitionBuilder = new FilterDefinitionBuilder<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity.Id == null)
            {

                entity.Id = ObjectId.GenerateNewId().ToString();
            }

            await MongoCollection.InsertOneAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            FilterDefinition<T> findByIdFilter = FilterDefinitionBuilder.Where(x => x.Id == entity.Id);
            await MongoCollection.FindOneAndReplaceAsync<T>(findByIdFilter, entity);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var result = await MongoCollection.FindAsync<T>(filter: FilterDefinitionBuilder.Where(x => x.Id == id));
            return result.FirstOrDefault();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            FilterDefinition<T> findByIdFilter = FilterDefinitionBuilder.Where(x => x.Id == entity.Id);
            await MongoCollection.FindOneAndReplaceAsync<T>(findByIdFilter, entity);
            return entity;
        }
    }
}
