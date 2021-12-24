using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.VehicleModel;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.VehicleModels.Commands
{
    public class CreateVehicleModelCommand : IRequest<Response<VehicleModelDTO>>
    {
        public string ModelName { get; set; }
        public int VehicleMakeId { get; set; }
    }
    public class CreateVehicleModelCommandHandler : IRequestHandler<CreateVehicleModelCommand, Response<VehicleModelDTO>>
    {
        private readonly IGenericRepositoryAsync<VehicleModel> _vehicleModelRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<VehicleMake> _vehicleMakeRepository;

        public CreateVehicleModelCommandHandler(IGenericRepositoryAsync<VehicleModel> vehicleModelRepository, IMapper mapper, IGenericRepositoryAsync<VehicleMake> vehicleMakeRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _mapper = mapper;
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task<Response<VehicleModelDTO>> Handle(CreateVehicleModelCommand request, CancellationToken cancellationToken)
        {
            #region Checkers
            //check if Vehicle makeID exists
            if (!await _vehicleMakeRepository.ExistAsync(c => c.VehicleMakeId == request.VehicleMakeId))
            {
                //Invalid makeId
                return ResponseMessage.BadRequest<VehicleModelDTO>(StatusMessage.Vehicle.InValidMakeId);
            }
            //check if the model exisit
            if (await _vehicleModelRepository.ExistAsync(c => c.ModelName == request.ModelName))
            {
                return ResponseMessage.AlreadyExists<VehicleModelDTO>(StatusMessage.VehicleModelResponse.MakeAlreadyExists);
            }
            #endregion

            //create new instance of vehicle 
            var vehicleModel = new VehicleModel
            {
                ModelName = request.ModelName,
                VehicleMakeId = request.VehicleMakeId
            };

            await _vehicleModelRepository.AddAsync(vehicleModel);
            //check if the add is successful
            if (vehicleModel.VehicleModelId > 0)
            {
                //successful
                var vehicleModelDTO = _mapper.Map<VehicleModelDTO>(vehicleModel);
                return ResponseMessage.Successful<VehicleModelDTO>(vehicleModelDTO, StatusMessage.VehicleModelResponse.AddedSuccessfully);
            }
            else
            {
                return ResponseMessage.Failed<VehicleModelDTO>(StatusMessage.VehicleModelResponse.AddNotSuccessful);
            }
        }
    }
}
