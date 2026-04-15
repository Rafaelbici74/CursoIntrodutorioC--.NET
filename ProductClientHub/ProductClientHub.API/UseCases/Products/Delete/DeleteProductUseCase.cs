using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.exceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductsClientHubDbContext();

            var entity = dbContext.Products.FirstOrDefault(product => product.Id == id);
            if (entity is null)
                throw new NotFoundException("Produto não encontrado.");


            dbContext.Products.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
