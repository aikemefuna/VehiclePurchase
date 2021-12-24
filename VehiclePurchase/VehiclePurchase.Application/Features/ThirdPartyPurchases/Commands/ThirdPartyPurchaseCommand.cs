using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehiclePurchase.Application.APIResponseHelper;
using VehiclePurchase.Application.DTOs.ThirdPartyPurchases;
using VehiclePurchase.Application.Repositories.GenericRepository;
using VehiclePurchase.Application.Wrappers;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Features.ThirdPartyPurchases.Commands
{
    public class ThirdPartyPurchaseCommand : IRequest<Response<ThirdPartyPurchasesDTO>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int VehicleId { get; set; }
    }
    public class CreateVehicleModelCommandHandler : IRequestHandler<ThirdPartyPurchaseCommand, Response<ThirdPartyPurchasesDTO>>
    {
        private readonly IGenericRepositoryAsync<ThirdPartyPurchase> _thirdPartPurchasesRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<Vehicle> _vehicleRepository;

        public CreateVehicleModelCommandHandler(IGenericRepositoryAsync<ThirdPartyPurchase> thirdPartPurchasesRepository, IMapper mapper, IGenericRepositoryAsync<Vehicle> vehicleRepository)
        {
            _thirdPartPurchasesRepository = thirdPartPurchasesRepository;
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Response<ThirdPartyPurchasesDTO>> Handle(ThirdPartyPurchaseCommand request, CancellationToken cancellationToken)
        {
            #region Checkers
            //check if Vehicle ID exists
            if (!await _vehicleRepository.ExistAsync(c => c.VehicleId == request.VehicleId))
            {
                //Invalid makeId
                return ResponseMessage.BadRequest<ThirdPartyPurchasesDTO>(StatusMessage.ThirdPartyPurchasesResponse.InvalidVehicleId);
            }

            #endregion

            //create new instance of vehicle 
            var thirdPartyPurchases = new ThirdPartyPurchase
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                VehicleId = request.VehicleId
            };

            await _thirdPartPurchasesRepository.AddAsync(thirdPartyPurchases);
            //check if the add is successful
            if (thirdPartyPurchases.ThirdPartyPurchaseId > 0)
            {
                //successful
                var thirdPartyPurchasesDTO = _mapper.Map<ThirdPartyPurchasesDTO>(thirdPartyPurchases);
                return ResponseMessage.Successful<ThirdPartyPurchasesDTO>(thirdPartyPurchasesDTO, StatusMessage.ThirdPartyPurchasesResponse.AddedSuccessfully);
            }
            else
            {
                return ResponseMessage.Failed<ThirdPartyPurchasesDTO>(StatusMessage.ThirdPartyPurchasesResponse.AddNotSuccessful);
            }
        }
    }
}
