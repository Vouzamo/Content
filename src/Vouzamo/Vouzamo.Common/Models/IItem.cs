using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Vouzamo.Common.Persistence;

namespace Vouzamo.Common.Models
{
    public interface IItem : IIdentifiable<Guid>
    {
        ItemType Type { get; }
        string Name { get; }
    }

    public abstract class Item : IItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public abstract ItemType Type { get; protected set; }
        public string Name { get; set; }

        protected Item()
        {

        }

        public Item(string name) : this()
        {
            Name = name;
        }
    }

    public interface IField
    {
        FieldType Type { get; }
        bool IsGlobal { get; }
    }

    public abstract class Field<T> : IField
    {
        public FieldType Type { get; protected set; }
        public bool IsGlobal { get; set; }

        protected Field(bool isGlobal)
        {
            IsGlobal = isGlobal;
        }
    }

    public class TextField : Field<string>
    {
        public TextField(bool isGlobal) : base(isGlobal)
        {
            Type = FieldType.Text;
        }
    }

    public interface IValue
    {
        
    }

    public class ContractItem : Item
    {
        public string _fields
        {
            get
            {
                return JsonConvert.SerializeObject(Fields);
            }
            set
            {
                Fields = JsonConvert.DeserializeObject<Dictionary<string, IField>>(value);
            }
        }

        public override ItemType Type { get; protected set; }

        [NotMapped]
        public Dictionary<string, IField> Fields { get; protected set; }

        protected ContractItem() : base()
        {

        }

        public ContractItem(string name) : base(name)
        {
            Type = ItemType.Contract;
            Fields = new Dictionary<string, IField>();
        }
    }

    public class ComponentItem : Item
    {
        public string _values
        {
            get
            {
                return JsonConvert.SerializeObject(Values);
            }
            set
            {
                Values = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, IValue>>>(value);
            }
        }

        public override ItemType Type { get; protected set; }

        [NotMapped]
        public Dictionary<string, Dictionary<string, IValue>> Values { get; protected set; }

        protected ComponentItem() : base()
        {

        }

        public ComponentItem(string name) : base(name)
        {
            Type = ItemType.Component;
            Values = new Dictionary<string, Dictionary<string, IValue>>();
        }
    }
}
