using System.Net;

namespace ProductClientHub.Exceptions.exceptionsBase
{
    public abstract class ProductsClientsHubException : SystemException
    {
        public ProductsClientsHubException(string errorMessage) : base(errorMessage)
        {
            
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();

    }
}
