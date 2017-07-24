using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Field;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Types;

namespace Vouzamo.Common.Converters
{
    public class ItemJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var equalsComparison = objectType.Equals(typeof(Item));

            return equalsComparison;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var fieldType = (ItemType)jObject["type"].Value<Int64>();

            switch (fieldType)
            {
                case ItemType.Contract:
                    return jObject.ToObject<ContractItem>(serializer);
                case ItemType.Component:
                    return jObject.ToObject<ComponentItem>(serializer);
                default:
                    return null;
            }
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
