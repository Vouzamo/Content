using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models.Field
{
    public abstract class Field<T> : IField
    {
        public FieldType Type { get; protected set; }
        public bool IsGlobal { get; set; }

        protected Field()
        {
            
        }

        public abstract bool Validate(Value value);
    }
}
