using AutoMapper;
using VehiclePurchase.Application.DTOs.Vehicle;
using VehiclePurchase.Application.DTOs.VehicleBodyType;
using VehiclePurchase.Application.DTOs.VehicleMake;
using VehiclePurchase.Application.DTOs.VehicleModel;
using VehiclePurchase.Domain.Entities;

namespace VehiclePurchase.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Vehicle, VehicleDTO>();
            CreateMap<VehicleMake, VehicleMakeDTO>();
            CreateMap<VehicleBodyType, VehicleBodyTypeDTO>();
            CreateMap<VehicleModel, VehicleModelDTO>();
        }
    }
}
