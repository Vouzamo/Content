using System;
using Vouzamo.Common.Models.Types;

namespace Vouzamo.Common.Models.Errors
{
    public class ErrorException : Exception, IError
    {
        public ErrorType Code { get; }

        public ErrorException(ErrorType code, string message = null) : base(message)
        {
            Code = code;
        }

        public ErrorException(Exception innerException, ErrorType code, string message = null) : base(message, innerException)
        {
            Code = code;
        }
    }
}
