using ErrorOr;
using Logistic.Delivery.Dto.Requests.Delivery;
using Logistic.Delivery.Dto.Responses.Delivery;

namespace Logistic.Delivery.Application.UseCases.Delivery.Canceled
{
    public interface IDeliveryCanceledUseCase
    {
        Task<ErrorOr<DeliveryResponse>> Execute(DeliveryRequest deliveryStatus);
    }
}
