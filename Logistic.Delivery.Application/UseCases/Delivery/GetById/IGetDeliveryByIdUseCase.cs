using ErrorOr;
using Logistic.Delivery.Infra.Interfaces.Base;

namespace Logistic.Delivery.Application.UseCases.Delivery.GetById
{
    public interface IGetDeliveryByIdUseCase
    {
        Task<ErrorOr<DeliveryCreateSagaData>> Execute(string id);
    }
}
