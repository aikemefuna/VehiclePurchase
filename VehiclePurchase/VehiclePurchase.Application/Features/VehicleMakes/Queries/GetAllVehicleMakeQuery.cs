using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.VehicleMake;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.VehicleMakes.Queries
{
    public class GetAllVehicleMakeQuery : IRequest<Response<List<VehicleMakeDTO>>>
    {

    }
    public class GetAllVehicleMakeQueryHandler : IRequestHandler<GetAllVehicleMakeQuery, Response<List<VehicleMakeDTO>>>
    {
        private readonly IGenericRepositoryAsync<VehicleMake> _vehicleMakeRepository;

        public GetAllVehicleMakeQueryHandler(IGenericRepositoryAsync<VehicleMake> vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }
        public async Task<Response<List<VehicleMakeDTO>>> Handle(GetAllVehicleMakeQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleMakeRepository.GetAll()
                .Select(c => new VehicleMakeDTO
                {
                    MakeName = c.MakeName,
                    VehicleMakeId = c.VehicleMakeId
                }).ToListAsync();

            return ResponseMessage.Successful<List<VehicleMakeDTO>>(vehicles, "Successful");

        }
    }
}
