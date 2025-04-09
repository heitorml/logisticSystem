using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Domain.Events.DeliveryEvents;
using MassTransit;

namespace Logistic.Delivery.Create.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBus _messageBroker;

        public Worker(ILogger<Worker> logger, IBus messageBroker)
        {
            _logger = logger;
            _messageBroker = messageBroker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    await _messageBroker.Publish(new DeliveryRequested
                    {
                        DeliveryId = Guid.NewGuid(),
                        CorrelationId = Guid.NewGuid(),
                        CreatAt = DateTime.UtcNow,
                        Address = new Address
                        {
                            City = "Vila Velha",
                            Country = "ES",
                            Number = "3250",
                        },
                        Conveyor = new Conveyor
                        {
                            Document = "00000000001",
                            Name = "Entregador/Transportadora",
                            CarrierId = Guid.NewGuid().ToString()
                        },
                        Recipient = new Recipient
                        {
                            Document = "431241234124",
                            Name = "Recebedor/Usuario/Cliente"
                        }
                    });

                }
                await Task.Delay(100000, stoppingToken);
            }
        }
    }
}
