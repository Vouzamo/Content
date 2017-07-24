using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models.Field
{
    public class TextField : Field<string>
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public TextField() : base()
        {
            Type = FieldType.Text;
        }

        public override bool Validate(Value value)
        {
            return (value.Raw.Length >= MinLength && value.Raw.Length <= MaxLength);
        }
    }
}
