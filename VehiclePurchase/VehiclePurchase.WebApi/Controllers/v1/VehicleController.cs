using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclePurchase.Application.DTOs.Vehicle;
using VehiclePurchase.Application.Features.Vehicles.Commands;
using VehiclePurchase.Application.Features.Vehicles.Queries;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.WebApi.Controllers;

namespace VBooX.API.Controllers.v1
{
    // [AuthorizeApiKey]
    public class VehicleController : BaseApiController
    {
        [HttpPost]
        [Route("vehicle")]
        [ProducesResponseType(typeof(Response<VehicleDTO>), 200)]
        public async Task<IActionResult> CreateType(CreateVehicleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("get-all")]
        [ProducesResponseType(typeof(Response<List<GetAllVehicleDTO>>), 200)]
        public async Task<IActionResult> CreateType(GetAllVehicleQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
