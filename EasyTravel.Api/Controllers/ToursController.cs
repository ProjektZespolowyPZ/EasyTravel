﻿using EasyTravel.Application.Tours.Commands.CreateTour;
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
    }
}