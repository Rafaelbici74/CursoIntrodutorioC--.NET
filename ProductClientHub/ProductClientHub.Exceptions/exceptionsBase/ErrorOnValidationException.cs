using System.Net;

namespace ProductClientHub.Exceptions.exceptionsBase
{
    public class ErrorOnValidationException : ProductsClientsHubException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> errorsMessages) : base(string.Empty)
        {
            _errors = errorsMessages;
        }

        public override List<string> GetErrors() => _errors;

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}