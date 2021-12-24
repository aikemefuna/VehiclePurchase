using VehiclePurchase.Domain.Common;

namespace VehiclePurchase.Domain.Entities
{
    public class VehicleBodyType : AuditableBaseEntity
    {
        public int VehicleBodyTypeId { get; set; }
        public string BodyType { get; set; }
        public double Premium { get; set; }
    }
}
