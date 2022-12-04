using EasyTravel.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Queries.GetSearchedTours
{
    public class GetSearchedToursQuery : IRequest<ToursVm>
    {
        public string SearchedWord { get; set; }
    }
}
