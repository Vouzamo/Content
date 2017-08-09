using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vouzamo.Common.Attributes;
using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models.Item
{
    public abstract class Item : IItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [RequiredGuid]
        public Guid? ParentId { get; set; }

        [Required]
        public ItemType Type { get; protected set; }

        [Required(AllowEmptyStrings = false), StringLength(32, MinimumLength = 3)]
        public string Name { get; set; }

        protected Item()
        {

        }
    }
}
