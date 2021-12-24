namespace VehiclePurchase.Application.DTOs.Vehicle
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int VehicleBodyTypeId { get; set; }
    }
    public class GetAllVehicleDTO : VehicleDTO
    {
        public string ModelName { get; set; }
        public string BodyTypeName { get; set; }
        public string MakeName { get; set; }
    }
}
