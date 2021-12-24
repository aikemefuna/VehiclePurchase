using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.ThirdPartyPurchases;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.ThirdPartyPurchases.Queries
{
    public class ThirdPartyPurchaseQuery : IRequest<Response<List<GetAllThirdPartyPurchasesDTO>>>
    {

    }
    public class ThirdPartyPurchaseQueryHandler : IRequestHandler<ThirdPartyPurchaseQuery, Response<List<GetAllThirdPartyPurchasesDTO>>>
    {
        private readonly IGenericRepositoryAsync<ThirdPartyPurchase> _thirdPartyPurchaseRepository;

        public ThirdPartyPurchaseQueryHandler(IGenericRepositoryAsync<ThirdPartyPurchase> thirdPartyPurchaseRepository)
        {
            _thirdPartyPurchaseRepository = thirdPartyPurchaseRepository;
        }
        public async Task<Response<List<GetAllThirdPartyPurchasesDTO>>> Handle(ThirdPartyPurchaseQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _thirdPartyPurchaseRepository.GetAll()
                .Include(c => c.Vehicle)
                .Include(c => c.Vehicle.VehicleMake)
                .Include(c => c.Vehicle.VehicleModel)
                .Include(c => c.Vehicle.VehicleBodyType)
                .Select(c => new GetAllThirdPartyPurchasesDTO
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    VehicleBodyTypeName = c.Vehicle.VehicleBodyType.BodyType,
                    VehicleMakeName = c.Vehicle.VehicleMake.MakeName,
                    VehicleModelName = c.Vehicle.VehicleModel.ModelName,
                    DateOfBirth = c.DateOfBirth,
                    Premium = c.Vehicle.VehicleBodyType.Premium,
                    ThirdPartyPurchaseId = c.ThirdPartyPurchaseId,
                    VehicleId = c.VehicleId
                }).ToListAsync();

            return ResponseMessage.Successful<List<GetAllThirdPartyPurchasesDTO>>(purchases, "Successful");

        }
    }
}
