using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vouzamo.Common.Converters;
using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class ContractItem : Item, IHasOwner<Guid>, IHasParent<Guid>, IHasFields
    {
        [RequiredGuid]
        public Guid OwnerId { get; set; }

        [RequiredGuid]
        public Guid ParentId { get; set; }

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
