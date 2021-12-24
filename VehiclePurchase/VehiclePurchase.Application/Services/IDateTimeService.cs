using System;

namespace VehiclePurchase.Application.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
