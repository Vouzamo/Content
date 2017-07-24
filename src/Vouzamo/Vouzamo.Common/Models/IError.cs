using Vouzamo.Common.Models.Types;

namespace Vouzamo.Common.Models
{
    public interface IError
    {
        ErrorType Code { get; }
        string Message { get; }
    }
}
