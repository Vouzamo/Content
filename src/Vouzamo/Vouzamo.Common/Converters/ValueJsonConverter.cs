using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vouzamo.Common.Models;

namespace Vouzamo.Common.Converters
{
    public class ValueJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var equalsComparison = objectType.Equals(typeof(Value));

            return equalsComparison;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jValue = JToken.Load(reader);

            var json = jValue.ToString(Formatting.Indented);
            
            return new Value { Raw = json };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var token = JToken.Parse((value as Value).Raw);

            writer.WriteToken(token.CreateReader());
        }
    }
}
