using EasyTravel.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.EditTour
{
    public class EditTourCommand : IRequest
    {
        public int Id { get; set; }
        public string MeetingPlace { get; set; }
        public string EndPlace { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Length { get; set; }
        public string MainPhoto { get; set; }
        public string MapPhoto { get; set; }
        public List<TourDateDTO> TourDates { get; set; } = new List<TourDateDTO>();
        public List<TourPhotoDTO> TourPhotos { get; set; } = new List<TourPhotoDTO>();
        public List<TourTagDTO> TourTags { get; set; } = new List<TourTagDTO>();
    }
}
