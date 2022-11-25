using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class EditProfileForm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Imię nie może być puste.")]
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Nieprawidłowe imię.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko nie może być puste.")]
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Nieprawidłowe nazwisko.")]
        public string Surname { get; set; }

        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Pole Email nie może być puste.")]
        [RegularExpression(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$", ErrorMessage = "Nieprawidłowy adres email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Numer telefonu nie może być puste.")]
        [RegularExpression(@"^[1-9]\d{8}$", ErrorMessage = "Nieprawidłowy numer telefonu.")]
        public string PhoneNumber { get; set; }
    }
}
