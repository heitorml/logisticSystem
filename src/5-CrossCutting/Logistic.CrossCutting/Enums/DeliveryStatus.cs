namespace Logistic.CrossCutting.Enums
{
    public enum DeliveryStatus
    {
        Requested = 1,
        Accepted,
        Validated,
        ForecastCreated,
        DocumentCreated,
        Created,
        Collected,
        InCarrier,
        InRoute,
        Realized,
        Reprogramed,
        Canceled
    }
}
