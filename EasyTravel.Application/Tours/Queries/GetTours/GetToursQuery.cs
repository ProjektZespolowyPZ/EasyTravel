using EasyTravel.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Queries.GetTours
{
    public class GetToursQuery : IRequest<ToursVm>
    {
    }
}
