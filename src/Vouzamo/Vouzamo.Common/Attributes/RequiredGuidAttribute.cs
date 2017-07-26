using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Vouzamo.Common.Attributes
{
    public class RequiredGuidAttribute : RequiredAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = Convert.ToString(value, CultureInfo.CurrentCulture);

            if (Guid.TryParse(input, out Guid guid))
            {
                if(guid.Equals(Guid.Empty))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return base.IsValid(value, validationContext);
        }
    }
}
