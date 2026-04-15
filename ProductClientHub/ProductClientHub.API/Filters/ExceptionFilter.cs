using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.exceptionsBase;

namespace ProductClientHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProductsClientsHubException productsClientsHubException)
            {
                context.HttpContext.Response.StatusCode = (int)productsClientsHubException.GetHttpStatusCode();

                context.Result = new ObjectResult(new ResponseErrorMessage(productsClientsHubException.GetErrors()));
            }

            else
            {
                ThrowUnknowError(context);
            }
        }
    


    private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessage("ERRO DESCONHECIDO"));
        }
    } 
}
