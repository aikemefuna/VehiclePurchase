namespace VehiclePurchase.Application.DTOs.VehicleModel
{
    public class VehicleModelDTO
    {
        public int VehicleModelId { get; set; }
        public string ModelName { get; set; }
        public int VehicleMakeId { get; set; }
    }
    public class GetAllVehicleModelDTO : VehicleModelDTO
    {
        public string MakeName { get; set; }
    }
}
