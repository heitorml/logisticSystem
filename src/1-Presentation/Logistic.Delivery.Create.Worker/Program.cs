using Logistic.Delivery.Application;
using Logistic.Delivery.Create.Worker;
using Logistic.Delivery.Create.Worker.Database.Maps;
using Logistic.Delivery.Create.Worker.Sagas;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//   options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
//});



builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.AddConsumers(typeof(Program).Assembly);

    x.AddSagaStateMachine<DeliveryCreateSaga, DeliveryCreateSagaData>()
      .MongoDbRepository(r =>
      {
          r.Connection = "mongodb://root:example@localhost:27017";
          r.DatabaseName = "deliverydb";
          r.CollectionName = "delivery";
      });
    //.EntityFrameworkRepository(r =>
    //{
    //    r.ExistingDbContext<AppDbContext>();

    //    r.UsePostgres();
    //});

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMq:Url"], "/", h =>
        {
            h.Username(builder.Configuration["RabbitMq:Username"]!);
            h.Password(builder.Configuration["RabbitMq:Pass"]!);
        });

        cfg.UseInMemoryOutbox(context);

        cfg.ConfigureEndpoints(context);
    });
}); ;

builder.Services.AddApplication(builder.Configuration);

builder.Services.AddSingleton<BsonClassMap<DeliveryCreateSagaData>, DeliverySagaMap>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
