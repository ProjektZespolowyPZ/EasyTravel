using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
