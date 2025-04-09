using Logistic.CrossCutting.Enums;
using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Dto.Dtos;
using Logistic.Delivery.Dto.Requests.Delivery;
using Logistic.Delivery.Dto.Responses.Delivery;

namespace Logistic.Delivery.Application.Mappers.Delivery
{
    public static class DeliveryMapper
    {
        public static DeliveryResponse ToResponse(this DeliveryModel model)
            => new DeliveryResponse
            {
                Address = new AddressDto()
                {
                    City = model.Address.City,
                    Country = model.Address.Country,
                    Latitude = model.Address.Latitude,
                    Logradouro = model.Address.Logradouro,
                    Longitude = model.Address.Longitude,
                    Number = model.Address.Number,
                    State = model.Address.State,
                    ZipCode = model.Address.ZipCode
                },
                Conveyor = new ConveyorDto()
                {
                    CarrierId = Guid.NewGuid().ToString(),
                    Document = model.Conveyor.Document,
                    Name = model.Conveyor.Name
                },
                CreatAt = model.CreatAt,
                Recipient = new RecipientDto()
                {
                    Document = model.Recipient.Document,
                    Name = model.Recipient.Name
                },
                Status = model.Status
            };

        public static DeliveryModel ToModel(
            this DeliveryRequest request, 
            DeliveryStatus status)
         => new DeliveryModel
         {
             Address = request.Address,
             Conveyor = request.Conveyor,
             CreatAt = DateTime.UtcNow,
             Recipient = request.Recipient,
             Status = status
         };


        //public static EventsDefault ToEvent(this DeliveryModel model, DeliveryStatus status)
        //{
        //    switch (status)
        //    {
        //        case DeliveryStatus.Requested: return new DeliveryCreated(model);
        //        case DeliveryStatus.Validated: return new DeliveryValidated(model);
        //        case DeliveryStatus.Created: return new DeliveryCreated(model);
        //        case DeliveryStatus.ForecastCreated: return new DeliveryForecastCreated(model);
        //        default: throw new ArgumentException("Event Not Implemented");
        //    };
        //}


    }
}
