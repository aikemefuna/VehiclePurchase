using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.VehicleMake;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.Vehicles.Commands
{
    public class CreateVehicleMakeCommand : IRequest<Response<VehicleMakeDTO>>
    {
        public string MakeName { get; set; }
    }
    public class CreateVehicleMakeCommandHandler : IRequestHandler<CreateVehicleMakeCommand, Response<VehicleMakeDTO>>
    {
        private readonly IGenericRepositoryAsync<VehicleMake> _vehicleMakeRepository;
        private readonly IMapper _mapper;

        public CreateVehicleMakeCommandHandler(IGenericRepositoryAsync<VehicleMake> vehicleMakeRepository, IMapper mapper)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _mapper = mapper;
        }


        public async Task<Response<VehicleMakeDTO>> Handle(CreateVehicleMakeCommand request, CancellationToken cancellationToken)
        {
            #region Checkers
            //check if Vehicle make exists
            if (await _vehicleMakeRepository.ExistAsync(c => c.MakeName == request.MakeName))
            {
                //allready exist
                return ResponseMessage.AlreadyExists<VehicleMakeDTO>(StatusMessage.VehicleBodyType.TypeAlreadyExists);
            }

            #endregion

            //create new instance of vehicle 
            var vehicleMake = new VehicleMake
            {
                MakeName = request.MakeName
            };

            await _vehicleMakeRepository.AddAsync(vehicleMake);
            //check if the add is successful
            if (vehicleMake.VehicleMakeId > 0)
            {
                //successful
                var vehicleMakeDTO = _mapper.Map<VehicleMakeDTO>(vehicleMake);
                return ResponseMessage.Successful<VehicleMakeDTO>(vehicleMakeDTO, StatusMessage.VehicleMakeResponse.AddedSuccessfully);
            }
            else
            {
                return ResponseMessage.Failed<VehicleMakeDTO>(StatusMessage.VehicleMakeResponse.AddNotSuccessful);
            }
        }
    }
}
