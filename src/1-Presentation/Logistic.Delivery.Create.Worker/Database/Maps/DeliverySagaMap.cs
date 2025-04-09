using Logistic.Delivery.Create.Worker.Sagas;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Logistic.Delivery.Create.Worker.Database.Maps
{
    public class DeliverySagaMap : BsonClassMap<DeliveryCreateSagaData>
    {
        public DeliverySagaMap()
        {
            MapProperty(x => x.OrderDate)
                .SetSerializer(new DateTimeSerializer(DateTimeKind.Utc));

            MapProperty(x => x.Recipient);
            MapProperty(x => x.Address);
            MapProperty(x => x.Conveyor);
            MapProperty(x => x.CurrentState);
            MapProperty(x => x.Status);
            MapProperty(x => x.DocumentCreated);
            MapProperty(x => x.Forecast);
            MapProperty(x => x.Validate);
            MapProperty(x => x.Version);

            MapProperty(x => x.DeliveryId)
                .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));

            MapProperty(x => x.CorrelationId)
                .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
        }
    }
}
