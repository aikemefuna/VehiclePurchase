namespace VehiclePurchase.Application.DTOs
{
    public class EmailRequest
    {
        public string To { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
    }
}
