using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class EditTourForm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Miejsce spotkania musi być podane.")]
        public string MeetingPlace { get; set; }

        [Required(ErrorMessage = "Miejsce zakończenia wycieczki musi być podane.")]
        public string EndPlace { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Nazwa wycieczki musi być podana.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Długość trwania wycieczki musi być podana.")]
        public string Length { get; set; }

        [Required(ErrorMessage = "Zdjęcie główne wycieczki musi być podane.")]
        public string MainPhoto { get; set; } = "";
        public string MapPhoto { get; set; } = "";
        [Required(ErrorMessage = "Proszę podać poprawne terminy.")]
        public List<TourDateDTO> TourDates { get; set; } = new List<TourDateDTO>();
        public List<TourPhotoDTO> TourPhotos { get; set; } = new List<TourPhotoDTO>();
        public List<TourTagDTO> TourTags { get; set; } = new List<TourTagDTO>();
    }
}
