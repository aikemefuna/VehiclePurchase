using System;

namespace VehiclePurchase.Application.DTOs.ThirdPartyPurchases
{
    public class ThirdPartyPurchasesDTO
    {
        public int ThirdPartyPurchaseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int VehicleId { get; set; }
    }
    public class GetAllThirdPartyPurchasesDTO : ThirdPartyPurchasesDTO
    {
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleBodyTypeName { get; set; }
        public double Premium { get; set; }
    }
}
