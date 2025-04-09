using Logistic.Delivery.Cancel.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<IMyservice, Myservice>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
