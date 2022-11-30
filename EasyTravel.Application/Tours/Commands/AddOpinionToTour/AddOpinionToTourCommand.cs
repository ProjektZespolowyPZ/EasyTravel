using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.AddOpinionToTour
{
    public class AddOpinionToTourCommand : IRequest
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DateTimeAddingOpinion { get; set; }
        public int IdTour { get; set; }
    }
}
