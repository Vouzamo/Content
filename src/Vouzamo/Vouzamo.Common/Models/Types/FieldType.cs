using System;
using System.ComponentModel.DataAnnotations;

namespace Vouzamo.Common.Types
{
    [Flags]
    public enum FieldType
    {
        [Display(Name = "Text")]
        Text = 1,

        [Display(Name = "Boolean")]
        Bool = 2
    }
}
