using System.Net;

namespace ProductClientHub.Exceptions.exceptionsBase
{
    public class NotFoundException : ProductsClientsHubException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
