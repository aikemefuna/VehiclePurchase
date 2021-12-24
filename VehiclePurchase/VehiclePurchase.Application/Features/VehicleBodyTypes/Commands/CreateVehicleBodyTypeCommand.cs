using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.VehicleBodyType;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.VehicleMakes.Commands
{
    public class CreateVehicleBodyTypeCommand : IRequest<Response<VehicleBodyTypeDTO>>
    {
        public string BodyType { get; set; }
        public double Premium { get; set; }
    }
    public class CreateVehicleBodyTypeCommandHandler : IRequestHandler<CreateVehicleBodyTypeCommand, Response<VehicleBodyTypeDTO>>
    {
        private readonly IGenericRepositoryAsync<VehicleBodyType> _vehicleBodyTypeRepository;
        private readonly IMapper _mapper;

        public CreateVehicleBodyTypeCommandHandler(IGenericRepositoryAsync<VehicleBodyType> vehicleBodyTypeRepository,
                                                   IMapper mapper)
        {
            _vehicleBodyTypeRepository = vehicleBodyTypeRepository;
            _mapper = mapper;
        }
        public async Task<Response<VehicleBodyTypeDTO>> Handle(CreateVehicleBodyTypeCommand request, CancellationToken cancellationToken)
        {
            //check if the type exists
            if (await _vehicleBodyTypeRepository.ExistAsync(c => c.BodyType == request.BodyType))
            {
                //allready exist
                return ResponseMessage.AlreadyExists<VehicleBodyTypeDTO>(StatusMessage.VehicleBodyType.TypeAlreadyExists);
            }

            var bodyType = new VehicleBodyType
            {
                BodyType = request.BodyType,
                Premium = request.Premium
            };
            await _vehicleBodyTypeRepository.AddAsync(bodyType);
            if (bodyType.VehicleBodyTypeId > 0)
            {
                //successful
                var vehicleBodyTypeDTO = _mapper.Map<VehicleBodyTypeDTO>(bodyType);
                return ResponseMessage.Successful<VehicleBodyTypeDTO>(vehicleBodyTypeDTO, StatusMessage.VehicleBodyType.AddedSuccessfully);
            }
            else
            {
                return ResponseMessage.Failed<VehicleBodyTypeDTO>(StatusMessage.VehicleBodyType.AddNotSuccessful);
            }
        }
    }
}
