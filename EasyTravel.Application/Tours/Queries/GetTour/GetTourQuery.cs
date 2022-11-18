using EasyTravel.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Queries.GetTour
{
    public class GetTourQuery : IRequest<TourVm>
    {
        public int TourId { get; set; }
    }
}
