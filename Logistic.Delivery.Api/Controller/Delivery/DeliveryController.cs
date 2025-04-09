using Logistic.Delivery.Application.UseCases.Delivery.GetById;
using Logistic.Delivery.Dto.Responses.Delivery;
using Microsoft.AspNetCore.Mvc;

namespace Logistic.Delivery.Api.Controller.Delivery
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;

        public DeliveryController(ILogger<DeliveryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryResponse>> GetById(
            [FromServices] IGetDeliveryByIdUseCase _getDeliveryByIdUseCase,
            string id,
            CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("field Empty");

                var result = await _getDeliveryByIdUseCase.Execute(id);

                if (result.IsError)
                    return BadRequest("error");

                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}", ex);
                throw ex;
            }
        }
    }
}
