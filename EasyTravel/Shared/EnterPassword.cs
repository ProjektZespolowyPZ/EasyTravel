using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class EnterPassword
    {
        [Required(ErrorMessage = "Hasło musi być podane.")]
        public string Password { get; set; }
    }
}
