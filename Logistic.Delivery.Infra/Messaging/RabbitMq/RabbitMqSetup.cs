
using Logistic.Delivery.Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logistic.Delivery.Infra.Messaging.RabbitMq
{
    //public static class RabbitMqSetup
    //{
    //    public static void AddRabbimq(this IServiceCollection services, IConfiguration configuration)
    //    {
    //        services.AddMassTransit(x =>
    //        {

    //            x.SetKebabCaseEndpointNameFormatter();

    //            //x.AddSagaStateMachine<DeliveryCreateSaga ,DeliveryCreateSagaData>()



    //            x.UsingRabbitMq((context, cfg) =>
    //            {
    //                cfg.Host("localhost", "/", h => {
    //                    h.Username("guest");
    //                    h.Password("guest");
    //                });

    //                cfg.ConfigureEndpoints(context);
    //            });
    //        });
    //    }
    //}
}
