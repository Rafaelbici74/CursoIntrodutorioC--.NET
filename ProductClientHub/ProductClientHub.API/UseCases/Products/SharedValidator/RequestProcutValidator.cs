using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProcutValidator : AbstractValidator<RequestProductJson>
    {

        public RequestProcutValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Nome do produto invalido.");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("Marca do produto invalido.");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Preço do produto invalido.");
        }            
    }
}
