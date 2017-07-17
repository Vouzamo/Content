using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vouzamo.Common.Persistence;

namespace Vouzamo.Common.Models
{
    public class Example : IIdentifiable<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsActive { get; set; }
    }
}
