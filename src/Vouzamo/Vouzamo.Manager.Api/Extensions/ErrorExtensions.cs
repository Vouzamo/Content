using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Errors;

namespace Vouzamo.Manager.Api.Extensions
{
    public static class ErrorExtensions
    {
        public static IActionResult ToErrorResult(this ErrorException exception)
        {
            var error = new Error(exception.Code, exception.Message);

            return error.ToErrorResult();
        }

        public static IActionResult ToErrorResult(this IError error)
        {
            switch (error.Code)
            {
                default:
                    return new BadRequestObjectResult(error);
            }
        }
    }
}
