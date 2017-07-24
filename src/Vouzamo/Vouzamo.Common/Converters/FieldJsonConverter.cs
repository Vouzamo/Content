using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Field;
using Vouzamo.Common.Types;

namespace Vouzamo.Common.Converters
{
    public class FieldJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var equalsComparison = objectType.Equals(typeof(IField));

            return equalsComparison;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var fieldType = (FieldType)jObject["type"].Value<Int64>();

            switch (fieldType)
            {
                case FieldType.Text:
                    return jObject.ToObject<TextField>(serializer);
                case FieldType.Bool:
                    return jObject.ToObject<BooleanField>(serializer);
                default:
                    return jObject.ToObject<TextField>(serializer);
            }
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
