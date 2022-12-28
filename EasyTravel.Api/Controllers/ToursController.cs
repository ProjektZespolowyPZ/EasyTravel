using EasyTravel.Application.Tours.Commands.AddOpinionToTour;
using EasyTravel.Application.Tours.Commands.CreateTour;
using EasyTravel.Application.Tours.Commands.DeleteTour;
using EasyTravel.Application.Tours.Commands.DeleteTourDate;
using EasyTravel.Application.Tours.Commands.DeleteTourPhoto;
using EasyTravel.Application.Tours.Commands.DeleteTourTag;
using EasyTravel.Application.Tours.Commands.EditTour;
using EasyTravel.Application.Tours.Queries.GetSearchedTours;
using EasyTravel.Application.Tours.Queries.GetTour;
using EasyTravel.Application.Tours.Queries.GetTours;
using EasyTravel.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyTravel.Api.Controllers
{
    [Route("api/tours")]
    [Authorize]
    public class ToursController : BaseController
    {
        /// <summary>
        /// Adds tour. 
        /// </summary>
        [Route("create-tour")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateTour(CreateTourCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Edits tour. 
        /// </summary>
        [Route("edit-tour")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> EditTour(EditTourCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Returns all tours.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ToursVm>> GetAllTours()
        {
            var vm = await Mediator.Send(new GetToursQuery());
            return vm;
        }

        /// <summary>
        /// Returns searched tours.
        /// </summary>
        /// <param name="word">SearchedWord</param>
        [Route("searching/{word}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ToursVm>> GetSearchedTours(string word)
        {
            var vm = await Mediator.Send(new GetSearchedToursQuery() { SearchedWord = word});
            return vm;
        }

        /// <summary>
        /// Returns details of selected tour.
        /// </summary>
        /// <param name="id">Tour id</param>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<TourVm>> GetTour(int id)
        {
            var vm = await Mediator.Send(new GetTourQuery() { TourId = id });
            return vm;
        }

        /// <summary>
        /// Deletes tour.
        /// </summary>
        /// <param name="id">Tour id</param>
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteTour(int id)
        {
            var result = await Mediator.Send(new DeleteTourCommand() { IdTour = id });
            return Ok(result);
        }

        /// <summary>
        /// Deletes tour date.
        /// </summary>
        /// <param name="id">Date tour id</param>
        [Route("tour-dates/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteTourDate(int id)
        {
            var result = await Mediator.Send(new DeleteTourDateCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Deletes tour photo.
        /// </summary>
        /// <param name="id">Photo tour id</param>
        [Route("tour-photos/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteTourPhoto(int id)
        {
            var result = await Mediator.Send(new DeleteTourPhotoCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Deletes tour tag.
        /// </summary>
        /// <param name="id">Tag tour id</param>
        [Route("tour-tags/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteTourTag(int id)
        {
            var result = await Mediator.Send(new DeleteTourTagCommand() { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Adds opinion about tour.
        /// </summary>
        [Route("add-opinion")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> AddOpinion(AddOpinionToTourCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
