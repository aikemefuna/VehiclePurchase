using VehiclePurchase.Domain.Common;

namespace VehiclePurchase.Domain.Entities
{
    public class VehicleModel : AuditableBaseEntity
    {
        public int VehicleModelId { get; set; }
        public string ModelName { get; set; }
        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
