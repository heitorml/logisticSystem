using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Events.DeliveryEvents;
using MassTransit;

namespace Logistic.Delivery.Create.Worker.Sagas
{
    public class DeliveryCreateSaga : MassTransitStateMachine<DeliveryCreateSagaData>
    {
        //Initial Event
        public Event<DeliveryRequested> DeliveryRequested { get; private set; } = null!;
        
        public State DeliveryValidation { get; private set; } = null!;
        public Event<DeliveryValidated> DeliveryValidated { get; private set; } = null!;

        public State DeliveryForecast { get; private set; } = null!;
        public Event<DeliveryForecastCreated> DeliveryForecastCreated { get; private set; } = null!;
       
        public State DeliveryCreateDocument { get; private set; } = null!;
        public Event<DeliveryDocumentCreated> DeliveryDocumentCreated { get; private set; } = null!;
        
        //Final State
        public State DeliveryCreated { get; private set; } = null!;

        public DeliveryCreateSaga()
        {
            SetCompletedWhenFinalized();
            InstanceState(x => x.CurrentState);

            Event(() => DeliveryRequested, e => e.CorrelateById(m => m.Message.CorrelationId));
            Event(() => DeliveryValidated, e => e.CorrelateById(m => m.Message.CorrelationId));
            Event(() => DeliveryForecastCreated, e => e.CorrelateById(m => m.Message.CorrelationId));
            Event(() => DeliveryDocumentCreated, e => e.CorrelateById(m => m.Message.CorrelationId));

            Initially(
                When(DeliveryRequested)
                .Then(context =>
                {
                    context.Saga.DeliveryId = context.Message.DeliveryId;
                    context.Saga.Address = context.Message.Address;
                    context.Saga.Conveyor = context.Message.Conveyor;
                    context.Saga.Recipient = context.Message.Recipient;
                    context.Saga.CorrelationId = context.Message.CorrelationId;
                    context.Saga.Status = context.Message.Status;
                })
                .TransitionTo(DeliveryValidation)
                .Publish(context => new DeliveryValidated()
                {
                    DeliveryId = context.Message.DeliveryId,
                    Address = context.Message.Address,
                    Conveyor = context.Message.Conveyor,
                    CreatAt = context.Message.CreatAt,
                    Recipient = context.Message.Recipient,
                    CorrelationId = context.Message.CorrelationId,
                    Status = DeliveryStatus.Validated
                }));

            During(DeliveryValidation,
                   When(DeliveryValidated)
                   .Then(context =>
                   {
                       context.Saga.DeliveryId = context.Message.DeliveryId;
                       context.Saga.Address = context.Message.Address;
                       context.Saga.Conveyor = context.Message.Conveyor;
                       context.Saga.Recipient = context.Message.Recipient;
                       context.Saga.CorrelationId = context.Message.CorrelationId;
                       context.Saga.Status = context.Message.Status;
                       context.Saga.Validate = true;
                   })
                   .TransitionTo(DeliveryForecast)
                   .Publish(
                       context => new DeliveryForecastCreated()
                       {
                           DeliveryId = context.Message.DeliveryId,
                           Address = context.Message.Address,
                           Conveyor = context.Message.Conveyor,
                           CreatAt = context.Message.CreatAt,
                           Recipient = context.Message.Recipient,
                           CorrelationId = context.Message.CorrelationId,
                           Status = DeliveryStatus.ForecastCreated,
                       })
                   );

            During(DeliveryForecast,
                   When(DeliveryForecastCreated)
                   .Then(context =>
                   {
                       context.Saga.Status = context.Message.Status;
                       context.Saga.DeliveryId = context.Message.DeliveryId;
                       context.Saga.Address = context.Message.Address;
                       context.Saga.Conveyor = context.Message.Conveyor;
                       context.Saga.Recipient = context.Message.Recipient;
                       context.Saga.Status = context.Message.Status;
                       context.Saga.Forecast = true;
                       context.Saga.CorrelationId = context.Message.CorrelationId;
                   })
                   .TransitionTo(DeliveryCreateDocument)
                      .Publish(
                           context => new DeliveryDocumentCreated()
                           {
                               DeliveryId = context.Message.DeliveryId,
                               Address = context.Message.Address,
                               Conveyor = context.Message.Conveyor,
                               CreatAt = context.Message.CreatAt,
                               Recipient = context.Message.Recipient,
                               CorrelationId = context.Message.CorrelationId,
                               Status = DeliveryStatus.DocumentCreated,
                           })
                      );

            During(DeliveryCreateDocument,
               When(DeliveryDocumentCreated)
               .Then(context =>
               {
                   context.Saga.DeliveryId = context.Message.DeliveryId;
                   context.Saga.Address = context.Message.Address;
                   context.Saga.Conveyor = context.Message.Conveyor;
                   context.Saga.Recipient = context.Message.Recipient;
                   context.Saga.CorrelationId = context.Message.CorrelationId;
                   context.Saga.Status = context.Message.Status;
                   context.Saga.DocumentCreated = true;
               })
               .TransitionTo(DeliveryCreated)
               .Publish(context => new DeliveryCreated()
                     {
                         DeliveryId = context.Message.DeliveryId,
                         Address = context.Message.Address,
                         Conveyor = context.Message.Conveyor,
                         CreatAt = context.Message.CreatAt,
                         Recipient = context.Message.Recipient,
                         CorrelationId = context.Message.CorrelationId,
                         Status = DeliveryStatus.Created,
               }));
        }
    }
}
