using System.Globalization;
using CsvHelper;
using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class GtfsCalendarDateHelpers
{
    public static string Build(Dictionary<string, TravelineSchedule> schedules, string path)
    {
        var results = ReturnCalendarDatesFromSchedules(schedules);

        using StreamWriter writer = new(Path.Combine(path, "calendar_dates.txt"));
        using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);

        csv.WriteHeader<GtfsCalendarDate>();
        csv.NextRecord();

        foreach (var value in results.Values)
        {
            csv.WriteRecord(value);
            csv.NextRecord();
        }
        
        return Path.Combine(path, "calendar_dates.txt");
    }

    private static Dictionary<string, GtfsCalendarDate> ReturnCalendarDatesFromSchedules(Dictionary<string, TravelineSchedule> schedules)
    {
        var results = new Dictionary<string, GtfsCalendarDate>();
        
        foreach (var value in schedules.Values)
        {
            for (var i = 0; i < value.Calendar?.SupplementRunningDates?.Count; i++)
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
                                         $"{value.Calendar?.Monday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Tuesday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Wednesday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Thursday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Friday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Saturday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Sunday.ToInt().ToString()}" +
                                         $"-" +
                                         $"{value.Calendar?.StartDate.Value:yyyy}" +
                                         $"{value.Calendar?.StartDate.Value:MM}" +
                                         $"{value.Calendar?.StartDate.Value:dd}" +
                                         $"{value.Calendar?.EndDate.Value:yyyy}" +
                                         $"{value.Calendar?.EndDate.Value:MM}" +
                                         $"{value.Calendar?.EndDate.Value:dd}";
                }
                
                GtfsCalendarDate calendarDate = new()
                {
                    ServiceId = calendar.ServiceId,
                    Date = $"{value.Calendar?.SupplementRunningDates[i]:yyyy}{value.Calendar?.SupplementRunningDates[i]:MM}{value.Calendar?.SupplementRunningDates[i]:dd}",
                    ExceptionType = "1"
                };
                
                if (!string.IsNullOrEmpty(calendarDate.ServiceId))
                {
                    _ = results.TryAdd($"{calendarDate.ServiceId}-{calendarDate.Date}", calendarDate);
                }
            }
            
            for (var i = 0; i < value.Calendar?.SupplementNonRunningDates?.Count; i++)
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
                                         $"{value.Calendar?.Monday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Tuesday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Wednesday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Thursday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Friday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Saturday.ToInt().ToString()}" +
                                         $"{value.Calendar?.Sunday.ToInt().ToString()}" +
                                         $"-" +
                                         $"{value.Calendar?.StartDate.Value:yyyy}" +
                                         $"{value.Calendar?.StartDate.Value:MM}" +
                                         $"{value.Calendar?.StartDate.Value:dd}" +
                                         $"{value.Calendar?.EndDate.Value:yyyy}" +
                                         $"{value.Calendar?.EndDate.Value:MM}" +
                                         $"{value.Calendar?.EndDate.Value:dd}";
                }
                
                GtfsCalendarDate calendarDate = new()
                {
                    ServiceId = calendar.ServiceId,
                    Date = $"{value.Calendar?.SupplementNonRunningDates[i]:yyyy}{value.Calendar?.SupplementNonRunningDates[i]:MM}{value.Calendar?.SupplementNonRunningDates[i]:dd}",
                    ExceptionType = "2"
                };
                
                if (!string.IsNullOrEmpty(calendarDate.ServiceId))
                {
                    _ = results.TryAdd($"{calendarDate.ServiceId}-{calendarDate.Date}", calendarDate);
                }
            }
        }
        
        return results.OrderBy(d =>
            d.Value.ServiceId).ToDictionary(d =>
            d.Key, d =>
            d.Value);
    }
}