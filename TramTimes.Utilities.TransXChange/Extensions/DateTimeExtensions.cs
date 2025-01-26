using NodaTime;
using NodaTime.Extensions;

namespace TramTimes.Utilities.TransXChange.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToZonedDate(this DateTime? dateTime, string timezone)
    {
        return !dateTime.HasValue ? DateTime.MinValue : dateTime.Value.ToUniversalTime().ToInstant().InZone(DateTimeZoneProviders.Tzdb[timezone]).ToDateTimeUnspecified();
    }
}