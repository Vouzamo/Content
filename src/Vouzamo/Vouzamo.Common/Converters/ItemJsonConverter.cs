using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Field;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Types;
using Vouzamo.Common.Models.Errors;
using Vouzamo.Common.Models.Types;

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
                case ItemType.Space:
                    return jObject.ToObject<SpaceItem>(serializer);
                case ItemType.Repo:
                    return jObject.ToObject<RepoItem>(serializer);
                case ItemType.RootFolder:
                    return jObject.ToObject<RootFolderItem>(serializer);
                case ItemType.Folder:
                    return jObject.ToObject<FolderItem>(serializer);
                case ItemType.Contract:
                    return jObject.ToObject<ContractItem>(serializer);
                case ItemType.Component:
                    return jObject.ToObject<ComponentItem>(serializer);
                default:
                    throw new ErrorException(ErrorType.General, "I have no idea what type of item that is!");
            }
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
