using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclePurchase.Application.DTOs.VehicleModel;
using VehiclePurchase.Application.Features.VehicleModels.Commands;
using VehiclePurchase.Application.Features.VehicleModels.Queries;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.WebApi.Controllers;

namespace VBooX.API.Controllers.v1
{
    // [AuthorizeApiKey]
    public class ModelController : BaseApiController
    {
        [HttpPost]
        [Route("model")]
        [ProducesResponseType(typeof(Response<VehicleModelDTO>), 200)]
        public async Task<IActionResult> CreateType(CreateVehicleModelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("get-all")]
        [ProducesResponseType(typeof(Response<List<GetAllVehicleModelDTO>>), 200)]
        public async Task<IActionResult> CreateType(GetAllVehicleModelQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
