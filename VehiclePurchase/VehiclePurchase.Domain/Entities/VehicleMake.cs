using VehiclePurchase.Domain.Common;

namespace VehiclePurchase.Domain.Entities
{
    public class VehicleMake : AuditableBaseEntity
    {
        public int VehicleMakeId { get; set; }
        public string MakeName { get; set; }
    }
}
