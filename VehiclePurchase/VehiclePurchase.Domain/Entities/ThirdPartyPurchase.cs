using System;

namespace VehiclePurchase.Domain.Entities
{
    public class ThirdPartyPurchase
    {
        public int ThirdPartyPurchaseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
