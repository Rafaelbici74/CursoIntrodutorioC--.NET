using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Products.Delete;
using ProductClientHub.API.UseCases.Products.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("{clientId}")]
        //Vai fazer o endpoint vai receber o status Created 201, que significa que o cadastro deu certo
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessage), StatusCodes.Status404NotFound)]

        public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
        {
            var UseCase = new RegisterProductUseCase();

            var response = UseCase.Execute(clientId, request);

            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessage), StatusCodes.Status404NotFound)]

        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteProductUseCase();

            useCase.Execute(id);

            return NoContent();
        }
    }
}
