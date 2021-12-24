using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.Vehicle;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.Vehicles.Commands
{
    public class CreateVehicleCommand : IRequest<Response<VehicleDTO>>
    {
        public string RegistrationNumber { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int VehicleBodyTypeId { get; set; }
    }
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Response<VehicleDTO>>
    {
        private readonly IGenericRepositoryAsync<Vehicle> _vehicleRepository;
        private readonly IGenericRepositoryAsync<VehicleMake> _vehicleMakeRepository;
        private readonly IGenericRepositoryAsync<VehicleModel> _vehicleModelRepository;
        private readonly IGenericRepositoryAsync<VehicleBodyType> _vehicleBodyTypeRepository;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IGenericRepositoryAsync<Vehicle> vehicleRepository,
                                           IGenericRepositoryAsync<VehicleMake> vehicleMakeRepository,
                                           IGenericRepositoryAsync<VehicleModel> vehicleModelRepository,
                                           IGenericRepositoryAsync<VehicleBodyType> vehicleBodyTypeRepository,
                                           IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleMakeRepository = vehicleMakeRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBodyTypeRepository = vehicleBodyTypeRepository;
            _mapper = mapper;
        }


        public async Task<Response<VehicleDTO>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            #region Checkers
            //check if Vehicle Model ID passed is valid
            if (request.ModelId == 0 || !(await _vehicleModelRepository.ExistAsync(c => c.VehicleModelId == request.ModelId)))
            {
                // Invalid modelIdPassed
                return ResponseMessage.BadRequest<VehicleDTO>(StatusMessage.Vehicle.InvalidModelId);
            }
            //check if Vehicle Make ID passed is valid
            if (request.MakeId == 0 || !(await _vehicleMakeRepository.ExistAsync(c => c.VehicleMakeId == request.MakeId)))
            {
                // Invalid InValidMakeId
                return ResponseMessage.BadRequest<VehicleDTO>(StatusMessage.Vehicle.InValidMakeId);
            }
            //check if Vehicle Body Type ID passed is valid
            if (request.VehicleBodyTypeId == 0 || !(await _vehicleBodyTypeRepository.ExistAsync(c => c.VehicleBodyTypeId == request.VehicleBodyTypeId)))
            {
                // InValidBodyTypeId
                return ResponseMessage.BadRequest<VehicleDTO>(StatusMessage.Vehicle.InValidBodyTypeId);
            }
            //check if the registration number exists
            if (await _vehicleRepository.ExistAsync(c => c.RegistrationNumber == request.RegistrationNumber))
            {
                //it exists we cannot creat new one
                return ResponseMessage.AlreadyExists<VehicleDTO>(StatusMessage.Vehicle.InValidBodyTypeId);
            }

            #endregion

            //create new instance of vehicle 
            var newVehicle = new Vehicle
            {
                VehicleMakeId = request.MakeId,
                VehicleModelId = request.ModelId,
                VehicleBodyTypeId = request.VehicleBodyTypeId,
                RegistrationNumber = request.RegistrationNumber
            };

            await _vehicleRepository.AddAsync(newVehicle);
            //check if the add is successful
            if (newVehicle.VehicleId > 0)
            {
                //successful
                var vehicleDTO = _mapper.Map<VehicleDTO>(newVehicle);
                return ResponseMessage.Successful<VehicleDTO>(vehicleDTO, StatusMessage.Vehicle.AddedSuccessfully);
            }
            else
            {
                return ResponseMessage.Failed<VehicleDTO>(StatusMessage.Vehicle.AddNotSuccessful);
            }
        }
    }
}
