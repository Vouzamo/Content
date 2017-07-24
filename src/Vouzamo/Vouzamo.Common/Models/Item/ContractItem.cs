using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vouzamo.Common.Converters;
using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models.Item
{
    public class ContractItem : Item, IHasFields
    {
        [JsonIgnore]
        public string _fields
        {
            get
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                return JsonConvert.SerializeObject(Fields, serializerSettings);
            }
            set
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                serializerSettings.Converters.Add(new FieldJsonConverter());

                Fields = JsonConvert.DeserializeObject<Dictionary<string, IField>>(value, serializerSettings);
            }
        }

        [NotMapped]
        public Dictionary<string, IField> Fields { get; protected set; }

        public ContractItem() : base()
        {
            Type = ItemType.Contract;
            Fields = new Dictionary<string, IField>();
        }
    }
}
