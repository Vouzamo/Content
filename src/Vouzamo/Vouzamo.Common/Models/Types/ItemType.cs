using System;
using System.ComponentModel.DataAnnotations;

namespace Vouzamo.Common.Types
{
    [Flags]
    public enum ItemType
    {
        [Display(Name = "Space")]
        Space = 1,

        [Display(Name = "Repository")]
        Repo = 2,

        [Display(Name = "Root Folder")]
        RootFolder = 4,

        [Display(Name = "Folder")]
        Folder = 8,

        [Display(Name = "Contract")]
        Contract = 16,

        [Display(Name = "Component")]
        Component = 32,
    }
}
