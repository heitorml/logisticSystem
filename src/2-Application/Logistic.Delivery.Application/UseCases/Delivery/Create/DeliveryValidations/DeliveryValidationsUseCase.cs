using ErrorOr;
using Logistic.Delivery.Application.Mappers.Delivery;
using Logistic.Delivery.Domain.Entities;
using Logistic.Delivery.Dto.Dtos;
using Logistic.Delivery.Dto.Responses.Delivery;

namespace Logistic.Delivery.Application.UseCases.Delivery.Create.DeliveryValidations
{
    public class DeliveryValidationsUseCase : IDeliveryValidationsUseCase
    {
        public async Task<ErrorOr<DeliveryResponse>> Execute(DeliveryDto deliveryDto)
        {
            //Salvar no banco
            var model = new DeliveryModel();

            //Executar regras de negócio

            //retorno 
            return model.ToResponse();
        }
    }
}
