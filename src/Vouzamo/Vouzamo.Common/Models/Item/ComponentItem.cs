﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{

    public class ComponentItem : Item, IHasOwner<Guid>, IHasParent<Guid>
    {
        [RequiredGuid]
        public Guid OwnerId { get; set; }

        [RequiredGuid]
        public Guid ParentId { get; set; }

        [JsonIgnore]
        public string _values
        {
            get
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                return JsonConvert.SerializeObject(Values);
            }
            set
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                Values = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Value>>>(value, serializerSettings);
            }
        }

        [NotMapped]
        public Dictionary<string, Dictionary<string, Value>> Values { get; protected set; }

        public ComponentItem() : base()
        {
            Type = ItemType.Component;
            Values = new Dictionary<string, Dictionary<string, Value>>();
        }
    }
}
