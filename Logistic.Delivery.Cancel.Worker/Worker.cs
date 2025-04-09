namespace Logistic.Delivery.Cancel.Worker
{
    public class Worker(IMyservice _service, ILogger<Worker> _logger)
        : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    await _service.Execute();
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
