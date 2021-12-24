using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclePurchase.Application.DTOs.ThirdPartyPurchases;
using VehiclePurchase.Application.Features.ThirdPartyPurchases.Commands;
using VehiclePurchase.Application.Features.ThirdPartyPurchases.Queries;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.WebApi.Controllers;

namespace VBooX.API.Controllers.v1
{
    // [AuthorizeApiKey]
    public class PurchaseController : BaseApiController
    {
        [HttpPost]
        [Route("purchase")]
        [ProducesResponseType(typeof(Response<ThirdPartyPurchasesDTO>), 200)]
        public async Task<IActionResult> CreateType(ThirdPartyPurchaseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(Response<List<GetAllThirdPartyPurchasesDTO>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new ThirdPartyPurchaseQuery()));
        }
    }
}
