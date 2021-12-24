using System;
using VehiclePurchase.Application.Services;

namespace VehiclePurchase.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
