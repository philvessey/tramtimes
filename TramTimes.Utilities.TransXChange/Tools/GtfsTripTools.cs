using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class GtfsTripTools
{
    public static Dictionary<string, GtfsTrip> GetFromSchedules(Dictionary<string, TravelineSchedule> schedules)
    {
        var results = new Dictionary<string, GtfsTrip>();
        
        foreach (var value in schedules.Values)
        {
            GtfsCalendar calendar = new()
            {
                StartDate = $"{value.Calendar?.StartDate?.ToString("yyyy")}" +
                            $"{value.Calendar?.StartDate?.ToString("MM")}" +
                            $"{value.Calendar?.StartDate?.ToString("dd")}",
                
                EndDate = $"{value.Calendar?.EndDate?.ToString("yyyy")}" +
                          $"{value.Calendar?.EndDate?.ToString("MM")}" +
                          $"{value.Calendar?.EndDate?.ToString("dd")}",
                
                Monday = value.Calendar is { Monday: not null } ? value.Calendar.Monday.ToInt().ToString() : "0",
                Tuesday = value.Calendar is { Tuesday: not null } ? value.Calendar.Tuesday.ToInt().ToString() : "0",
                Wednesday = value.Calendar is { Wednesday: not null } ? value.Calendar.Wednesday.ToInt().ToString() : "0",
                Thursday = value.Calendar is { Thursday: not null } ? value.Calendar.Thursday.ToInt().ToString() : "0",
                Friday = value.Calendar is { Friday: not null } ? value.Calendar.Friday.ToInt().ToString() : "0",
                Saturday = value.Calendar is { Saturday: not null } ? value.Calendar.Saturday.ToInt().ToString() : "0",
                Sunday = value.Calendar is { Sunday: not null } ? value.Calendar.Sunday.ToInt().ToString() : "0"
            };

            if (value.Calendar is { StartDate: not null, EndDate: not null })
            {
                calendar.ServiceId = $"{value.ServiceCode}" +
                                     $"-" +
                                     $"{value.Calendar?.StartDate.Value:yyyy}" +
                                     $"{value.Calendar?.StartDate.Value:MM}" +
                                     $"{value.Calendar?.StartDate.Value:dd}" +
                                     $"-" +
                                     $"{value.Calendar?.EndDate.Value:yyyy}" +
                                     $"{value.Calendar?.EndDate.Value:MM}" +
                                     $"{value.Calendar?.EndDate.Value:dd}" +
                                     $"-" +
                                     $"{value.Calendar?.Monday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Tuesday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Wednesday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Thursday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Friday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Saturday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Sunday.ToInt().ToString()}";
            }

            GtfsTrip trip = new()
            {
                RouteId = value.ServiceCode,
                ServiceId = calendar.ServiceId,
                TripId = value.Id,
                TripHeadsign = value.StopPoints?.LastOrDefault()?.NaptanStop?.CommonName ?? value.StopPoints?.LastOrDefault()?.TravelineStop?.CommonName,
                DirectionId = value.Direction
            };

            _ = results.TryAdd(Guid.NewGuid().ToString(), trip);
        }
        
        return results.OrderBy(trip =>
            trip.Value.TripId).ToDictionary(trip =>
            trip.Key, trip =>
            trip.Value);
    }
}