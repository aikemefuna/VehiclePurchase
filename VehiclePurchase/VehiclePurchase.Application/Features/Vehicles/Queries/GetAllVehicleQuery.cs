using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.Vehicle;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.Vehicles.Queries
{
    public class GetAllVehicleQuery : IRequest<Response<List<GetAllVehicleDTO>>>
    {

    }
    public class GetAllVehicleQueryHandler : IRequestHandler<GetAllVehicleQuery, Response<List<GetAllVehicleDTO>>>
    {
        private readonly IGenericRepositoryAsync<Vehicle> _vehicleRepository;

        public GetAllVehicleQueryHandler(IGenericRepositoryAsync<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<Response<List<GetAllVehicleDTO>>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleRepository.GetAll()
                .Include(c => c.VehicleModel)
                .Include(c => c.VehicleMake)
                .Include(c => c.VehicleBodyType)
                .Select(c => new GetAllVehicleDTO
                {
                    BodyTypeName = c.VehicleBodyType.BodyType,
                    MakeName = c.VehicleMake.MakeName,
                    ModelName = c.VehicleModel.ModelName,
                    MakeId = c.VehicleMakeId,
                    ModelId = c.VehicleModelId,
                    VehicleBodyTypeId = c.VehicleBodyTypeId,
                    RegistrationNumber = c.RegistrationNumber,
                    VehicleId = c.VehicleId
                }).ToListAsync();

            return ResponseMessage.Successful<List<GetAllVehicleDTO>>(vehicles, "Successful");

        }
    }
}
