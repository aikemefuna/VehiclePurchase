using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.VehicleBodyType;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.VehicleMakes.Queries
{

    public class GetAllVehicleBodyTypeQuery : IRequest<Response<List<VehicleBodyTypeDTO>>>
    {

    }
    public class GetAllVehicleBodyTypeQueryHandler : IRequestHandler<GetAllVehicleBodyTypeQuery, Response<List<VehicleBodyTypeDTO>>>
    {
        private readonly IGenericRepositoryAsync<VehicleBodyType> _vehicleBodyTpeRepository;

        public GetAllVehicleBodyTypeQueryHandler(IGenericRepositoryAsync<VehicleBodyType> vehicleBodyTpeRepository)
        {
            _vehicleBodyTpeRepository = vehicleBodyTpeRepository;
        }
        public async Task<Response<List<VehicleBodyTypeDTO>>> Handle(GetAllVehicleBodyTypeQuery request, CancellationToken cancellationToken)
        {
            var types = await _vehicleBodyTpeRepository
                .GetAll()
                .Select(c => new VehicleBodyTypeDTO
                {
                    BodyType = c.BodyType,
                    Premium = c.Premium,
                    VehicleBodyTypeId = c.VehicleBodyTypeId
                }).ToListAsync();
            return ResponseMessage.Successful<List<VehicleBodyTypeDTO>>(types, "Successful");

        }
    }
}
