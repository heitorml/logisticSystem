using ErrorOr;
using Logistic.Delivery.Dto.Dtos;
using Logistic.Delivery.Dto.Responses.Delivery;

namespace Logistic.Delivery.Application.UseCases.Delivery.Create.DeliveryForecastCreate
{
    public interface IDeliveryForecastCreateUseCase
    {
        Task<ErrorOr<DeliveryResponse>> Execute(DeliveryDto deliveryDto);
    }
}
