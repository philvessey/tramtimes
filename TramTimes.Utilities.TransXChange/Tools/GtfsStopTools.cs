using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class GtfsStopTools
{
    public static Dictionary<string, GtfsStop> GetFromSchedules(Dictionary<string, TravelineSchedule> schedules)
    {
        var results = new Dictionary<string, GtfsStop>();
        
        foreach (var value in schedules.Values)
        {
            GtfsCalendar calendar = new()
            {
                StartDate = $"{value.Calendar?.StartDate?.ToString("yyyy")}{value.Calendar?.StartDate?.ToString("MM")}{value.Calendar?.StartDate?.ToString("dd")}",
                EndDate = $"{value.Calendar?.EndDate?.ToString("yyyy")}{value.Calendar?.EndDate?.ToString("MM")}{value.Calendar?.EndDate?.ToString("dd")}",
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

            for (var i = 0; i < value.StopPoints?.Count; i++)
            {
                GtfsStop stop = new()
                {
                    StopId = value.StopPoints[i].NaptanStop?.AtcoCode ?? value.StopPoints[i].TravelineStop?.AtcoCode,
                    StopCode = value.StopPoints[i].NaptanStop?.NaptanCode,
                    StopName = value.StopPoints[i].NaptanStop?.CommonName ?? value.StopPoints[i].TravelineStop?.CommonName,
                    StopDesc = value.StopPoints[i].NaptanStop?.LocalityName ?? value.StopPoints[i].TravelineStop?.LocalityName,
                    StopLat = value.StopPoints[i].NaptanStop?.Latitude ?? value.StopPoints[i].TravelineStop?.Latitude,
                    StopLon = value.StopPoints[i].NaptanStop?.Longitude ?? value.StopPoints[i].TravelineStop?.Longitude,
                    LocationType = "0",
                    StopTimezone = "Europe/London",
                    WheelchairBoarding = "1",
                    PlatformCode = value.StopPoints[i].NaptanStop?.AtcoCode?[^1..] ?? value.StopPoints[i].TravelineStop?.AtcoCode?[^1..]
                };

                if (stop.StopId != null)
                {
                    _ = results.TryAdd(stop.StopId, stop);
                }
            }
        }
        
        return results.OrderBy(s =>
            s.Value.StopId).ToDictionary(s =>
            s.Key, s =>
            s.Value);
    }
}