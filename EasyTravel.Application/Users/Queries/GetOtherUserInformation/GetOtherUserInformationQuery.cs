using EasyTravel.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Users.Queries.GetOtherUserInformation
{
    public class GetOtherUserInformationQuery : IRequest<UserInformationVm>
    {
        public int UserId { get; set; }
    }
}
