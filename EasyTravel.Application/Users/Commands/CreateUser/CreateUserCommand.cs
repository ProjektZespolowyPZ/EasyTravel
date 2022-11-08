using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime RecentLoginDate { get; set; }
    }
}
