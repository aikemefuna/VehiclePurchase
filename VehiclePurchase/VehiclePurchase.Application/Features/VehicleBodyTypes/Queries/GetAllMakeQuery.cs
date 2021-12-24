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

    public class GetAllMakeQuery : IRequest<Response<List<VehicleMakeDTO>>>
    {

    }
    public class GetAllMakeQueryHandler : IRequestHandler<GetAllMakeQuery, Response<List<VehicleMakeDTO>>>
    {
        private readonly IGenericRepositoryAsync<VehicleMake> _vehicleMakeRepository;

        public GetAllMakeQueryHandler(IGenericRepositoryAsync<VehicleMake> vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }
        public async Task<Response<List<VehicleMakeDTO>>> Handle(GetAllMakeQuery request, CancellationToken cancellationToken)
        {
            var makes = await _vehicleMakeRepository
                .GetAll()
                .Select(c => new VehicleMakeDTO
                {
                    VehicleMakeId = c.VehicleMakeId,
                    MakeName = c.MakeName
                }).ToListAsync();
            return ResponseMessage.Successful<List<VehicleMakeDTO>>(makes, "Successful");

        }
    }
}
