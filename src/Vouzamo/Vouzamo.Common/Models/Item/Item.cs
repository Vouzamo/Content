using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models.Item
{
    public abstract class Item : IItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public ItemType Type { get; protected set; }
        public string Name { get; set; }

        protected Item()
        {

        }
    }
}
