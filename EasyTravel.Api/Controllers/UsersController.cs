using EasyTravel.Application.Users.Commands.CreateUser;
using EasyTravel.Application.Users.Commands.UpdateAvatar;
using EasyTravel.Application.Users.Commands.UpdateLoginDate;
using EasyTravel.Application.Users.Commands.UpdateProfile;
using EasyTravel.Application.Users.Queries.GetUserInformation;
using EasyTravel.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyTravel.Api.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : BaseController
    {
        /// <summary>
        /// Create user.
        /// </summary>
        [Route("create-user")]
        [HttpPost]
        [AllowAnonymous]

        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update user login date.
        /// </summary>
        [Route("update-login")]
        [HttpPut]
        [AllowAnonymous]

        public async Task<ActionResult> UpdateLoginDate(UpdateLoginDateCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Returns general information about user.
        /// </summary>
        [HttpGet]
        [Route("GetAllInformation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<UserInformationVm>> GetAllInformation()
        {
            var vm = await Mediator.Send(new GetUserInformationQuery());
            return vm;
        }

        /// <summary>
        /// Updates Avatar. 
        /// </summary>
        [Route("update-avatar")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> UpdateAvatar(UpdateAvatarCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Updates Avatar. 
        /// </summary>
        [Route("update-profile")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> UpdateProfile(UpdateProfileCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
