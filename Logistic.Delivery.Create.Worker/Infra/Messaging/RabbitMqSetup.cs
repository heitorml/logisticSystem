using Logistic.Delivery.Create.Worker.Database;
using Logistic.Delivery.Create.Worker.Sagas;
using MassTransit;

namespace Logistic.Delivery.Create.Worker.Infra.Messaging
{
    public static class RabbitMqSetup
    {
        public static void AddRabbimq(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {

                x.SetKebabCaseEndpointNameFormatter();

                x.AddSagaStateMachine<DeliveryCreateSaga, DeliveryCreateSagaData>()
                .EntityFrameworkRepository(r =>
                {
                    r.ExistingDbContext<AppDbContext>();

                    r.UsePostgres();
                });



                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.UseInMemoryOutbox(context);

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
