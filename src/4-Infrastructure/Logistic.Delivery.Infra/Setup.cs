using Logistic.Delivery.Infra.Interfaces;
using Logistic.Delivery.Infra.Repositories.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Logistic.Delivery.Infra
{
    public static class Setup
    {
        public static void AddInfra(
            this IServiceCollection services,
            IConfiguration configuration)
        {
 

            //Factories

            //Services

            //Infra

            //services.AddRabbimq(configuration);
            services.AddSingleton<IMongoClient>(sp =>
            {
                return new MongoClient(configuration.GetConnectionString("MongoDb"));
            });

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase("deliverydb");

            });

            //Repositories
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDeliverySagaRepository, DeliverySagaRepository>();

        }
    }
}
