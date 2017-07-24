using Vouzamo.Common.Models.Types;

namespace Vouzamo.Common.Models.Errors
{
    public class Error : IError
    {
        public ErrorType Code { get; }
        public string Message { get; }

        public Error(ErrorType code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
