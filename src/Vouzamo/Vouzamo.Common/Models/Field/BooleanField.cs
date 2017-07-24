using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models.Field
{
    public class BooleanField : Field<bool>
    {
        public BooleanField() : base()
        {
            Type = FieldType.Bool;
        }

        public override bool Validate(Value value)
        {
            return bool.TryParse(value.Raw, out bool result);
        }
    }
}
