using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Tours.Commands.DeleteTourTag
{
    public class DeleteTourTagCommand : IRequest
    {
        public int Id { get; set; }
    }
}
