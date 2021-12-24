using VehiclePurchase.Domain.Common;

namespace VehiclePurchase.Domain.Entities
{
    public class Vehicle : AuditableBaseEntity
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public int VehicleMakeId { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleBodyTypeId { get; set; }

        public VehicleMake VehicleMake { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public VehicleBodyType VehicleBodyType { get; set; }
    }
}
