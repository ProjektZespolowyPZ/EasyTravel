using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.DeleteTour
{
    public class DeleteTourCommand : IRequest
    {
        public int IdTour { get; set; }
    }
}
