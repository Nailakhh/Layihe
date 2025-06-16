using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ValidationAttributes
{
    public class LowercaseOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var stringValue = value.ToString();
            if (stringValue != stringValue.ToLower())
            {
                return new ValidationResult("Yalnız kiçik hərflərlə daxil edin");
            }

            return ValidationResult.Success;
        }
    }
}
