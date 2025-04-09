using Logistic.Delivery.Application.UseCases.Delivery.Create;
using Logistic.Delivery.Application.UseCases.Delivery.GetById;
using Logistic.Delivery.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logistic.Delivery.Application
{
    public static class Setup
    {
        public static void AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //UseCases
            services.AddTransient<IGetDeliveryByIdUseCase, GetDeliveryByIdUseCase>();
            // services.AddTransient<IDeliveryCanceledUseCase, DeliveryCanceledUseCase>();
            // services.AddTransient<ISetDeliveryStatusUseCase, SetDeliveryStatusUseCase>();

            //Factories

            //Services

            //Infra
            services.AddInfra(configuration);

        }
    }
}
