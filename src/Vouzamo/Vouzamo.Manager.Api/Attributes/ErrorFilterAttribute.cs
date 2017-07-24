using Microsoft.AspNetCore.Mvc.Filters;
using Vouzamo.Common.Models.Errors;
using Vouzamo.Common.Models.Types;
using Vouzamo.Manager.Api.Extensions;

namespace Vouzamo.Manager.Api.Filters
{
    public class ErrorFilterAttribute : ExceptionFilterAttribute
    {
        public ErrorFilterAttribute()
        {
            
        }

        public override void OnException(ExceptionContext context)
        {
            // Log.Error(context.Exception.Message);

            if(context.Exception is ErrorException)
            {
                var error = context.Exception as ErrorException;

                context.Result = error.ToErrorResult();
            }
            else
            {
                var message = context.Exception.Message;

                context.Result = new Error(ErrorType.General, message).ToErrorResult();
            }
        }
    }
}
