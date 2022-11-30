using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Shared
{
    public class TourVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        public string MainPhoto { get; set; }
        public string MapPhoto { get; set; }
        public string MeetingPlace { get; set; }
        public string EndPlace { get; set; }
        public string Length { get; set; }
        public double AvarageRating { get; set; }
        public List<TourDateDTO> TourDates { get; set; } = new List<TourDateDTO>();
        public List<TourPhotoDTO> TourPhotos { get; set; } = new List<TourPhotoDTO>();
        public List<TourOpinionDTO> TourOpinions { get; set; } = new List<TourOpinionDTO>();
    }
}
