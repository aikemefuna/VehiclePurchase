using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclePurchase.Application.DTOs.VehicleBodyType;
using VehiclePurchase.Application.Features.VehicleMakes.Commands;
using VehiclePurchase.Application.Features.VehicleMakes.Queries;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.WebApi.Controllers;

namespace VBooX.API.Controllers.v1
{
    // [AuthorizeApiKey]
    public class BodyTypeController : BaseApiController
    {
        [HttpPost]
        [Route("body-type")]
        [ProducesResponseType(typeof(Response<VehicleBodyTypeDTO>), 200)]
        public async Task<IActionResult> CreateType(CreateVehicleBodyTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(Response<List<VehicleBodyTypeDTO>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllVehicleBodyTypeQuery())); ;
        }
    }
}
