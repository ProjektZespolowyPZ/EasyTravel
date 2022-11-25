using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared.CustomDataAnnotations
{
    public class FromNowAttribute : ValidationAttribute
    {
        public FromNowAttribute() { }

        public string GetErrorMessage() => "Data i godzina wycieczki nie może być wcześniejsza od aktualnej daty i godziny.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (DateTime.Compare(date, DateTime.Now) < 0) return new ValidationResult(GetErrorMessage());
            else return ValidationResult.Success;
        }
    }
}
