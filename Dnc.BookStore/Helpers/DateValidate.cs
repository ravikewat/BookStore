using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Dnc.BookStore.Helpers
{
    public class DateValidate : ValidationAttribute
    {
        public string UpperDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var upperDate = string.IsNullOrEmpty(UpperDate) ? DateTime.Now : Convert.ToDateTime(UpperDate);

            if (value != null && Convert.ToDateTime(value) < upperDate)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? $"Date should be less than upperdate {upperDate}");
        }
    }
}
