using EasyTravel.Shared.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class TourDateDTO
    {
        public int Id { get; set; }
        [FromNow]
        public DateTime TourDate { get; set; }
        public float Price { get; set; }

        [Required(ErrorMessage = "Hasło musi być podane.")]
        public string Password { get; set; }
    }
}
