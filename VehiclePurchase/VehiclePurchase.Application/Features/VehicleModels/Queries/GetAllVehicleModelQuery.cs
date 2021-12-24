using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.VehicleModel;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.VehicleModels.Queries
{
    public class GetAllVehicleModelQuery : IRequest<Response<List<GetAllVehicleModelDTO>>>
    {

    }
    public class GetAllVehicleQueryHandler : IRequestHandler<GetAllVehicleModelQuery, Response<List<GetAllVehicleModelDTO>>>
    {
        private readonly IGenericRepositoryAsync<VehicleModel> _vehicleModelRepository;

        public GetAllVehicleQueryHandler(IGenericRepositoryAsync<VehicleModel> vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }
        public async Task<Response<List<GetAllVehicleModelDTO>>> Handle(GetAllVehicleModelQuery request, CancellationToken cancellationToken)
        {
            var vehiclesModel = await _vehicleModelRepository.GetAll()
                .Include(c => c.VehicleMake)
                .Select(c => new GetAllVehicleModelDTO
                {
                    MakeName = c.VehicleMake.MakeName,
                    ModelName = c.ModelName,
                    VehicleMakeId = c.VehicleMakeId,
                    VehicleModelId = c.VehicleModelId
                }).ToListAsync();

            return ResponseMessage.Successful<List<GetAllVehicleModelDTO>>(vehiclesModel, "Successful");

        }
    }
}
