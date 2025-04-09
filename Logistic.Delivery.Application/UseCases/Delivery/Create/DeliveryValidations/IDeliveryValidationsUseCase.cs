using ErrorOr;
using Logistic.Delivery.Dto.Dtos;
using Logistic.Delivery.Dto.Responses.Delivery;

namespace Logistic.Delivery.Application.UseCases.Delivery.Create.DeliveryValidations
{
    public interface IDeliveryValidationsUseCase
    {
        Task<ErrorOr<DeliveryResponse>> Execute(DeliveryDto deliveryDto);
    }
}
