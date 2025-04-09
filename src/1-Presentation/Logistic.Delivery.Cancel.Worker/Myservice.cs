namespace Logistic.Delivery.Cancel.Worker
{
    public class Myservice : IMyservice
    {
        public Task Execute()
        {
            return Task.CompletedTask;
        }
    }
}
