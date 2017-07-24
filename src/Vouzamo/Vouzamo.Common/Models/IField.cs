using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models
{
    public interface IField
    {
        FieldType Type { get; }
        bool IsGlobal { get; }

        bool Validate(Value value);
    }
}
