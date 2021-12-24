using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclePurchase.Application.DTOs.VehicleMake;
using VehiclePurchase.Application.Features.VehicleMakes.Queries;
using VehiclePurchase.Application.Features.Vehicles.Commands;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.WebApi.Controllers;

namespace VBooX.API.Controllers.v1
{
    // [AuthorizeApiKey]
    public class MakeController : BaseApiController
    {
        [HttpPost]
        [Route("make")]
        [ProducesResponseType(typeof(Response<VehicleMakeDTO>), 200)]
        public async Task<IActionResult> CreateType(CreateVehicleMakeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(Response<List<VehicleMakeDTO>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllVehicleMakeQuery()));
        }
    }
}
