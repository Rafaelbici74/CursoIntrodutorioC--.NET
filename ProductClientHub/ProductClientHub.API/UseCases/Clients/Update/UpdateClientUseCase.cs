using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.exceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {

        public void Execute(Guid clientId, RequestClientJson request)
        {
            Validate(request);

            var dbcontext = new ProductsClientHubDbContext();

            var entity = dbcontext.Clients.FirstOrDefault(client => client.Id == clientId);
            if (entity is null)
                throw new NotFoundException("Cliente não encontrado.");

            entity.Name = request.Name;
            entity.Email = request.Email;

            dbcontext.Clients.Update(entity);
            dbcontext.SaveChanges();
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }


    }
}
