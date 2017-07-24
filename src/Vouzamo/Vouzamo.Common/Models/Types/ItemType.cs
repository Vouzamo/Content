using System;
using System.ComponentModel.DataAnnotations;

namespace Vouzamo.Common.Types
{
    [Flags]
    public enum ItemType
    {
        [Display(Name = "Repository")]
        Repo = 1,

        [Display(Name = "Folder")]
        Folder = 2,

        [Display(Name = "Contract")]
        Contract = 4,

        [Display(Name = "Component")]
        Component = 8,
    }
}
