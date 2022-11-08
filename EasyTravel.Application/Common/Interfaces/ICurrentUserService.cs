using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string Email { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
