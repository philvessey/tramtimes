using System.Globalization;
using CsvHelper;
using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class GtfsStopTimeHelpers
{
    public static void Build(Dictionary<string, TransXChangeSchedule> schedules, string path)
    {
        var results = ReturnStopTimesFromSchedules(schedules);

        using StreamWriter writer = new(Path.Combine(path, "stop_times.txt"));
        using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);

        csv.WriteHeader<GtfsStopTime>();
        csv.NextRecord();

        foreach (var value in results.Values)
        {
            csv.WriteRecord(value);
            csv.NextRecord();
        }
    }

    private static Dictionary<string, GtfsStopTime> ReturnStopTimesFromSchedules(Dictionary<string, TransXChangeSchedule> schedules)
    {
        var results = new Dictionary<string, GtfsStopTime>();
        
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

            var timeSpan = TimeSpan.Zero;

            for (var i = 0; i < value.StopPoints?.Count; i++)
            {
                GtfsStopTime stopTime = new()
                {
                    TripId = value.Id,
                    StopSequence = Convert.ToString(i + 1)
                };

                if (value.StopPoints[i].ArrivalTime.HasValue && value.StopPoints[i].DepartureTime.HasValue)
                {
                    if (value.StopPoints[i].DepartureTime < timeSpan)
                    {
                        value.StopPoints[i].ArrivalTime = value.StopPoints[i].ArrivalTime?
                            .Add(new TimeSpan(24, 0, 0));
                        
                        value.StopPoints[i].DepartureTime = value.StopPoints[i].DepartureTime?
                            .Add(new TimeSpan(24, 0, 0));

                        stopTime.ArrivalTime = string.Concat(Math
                                .Round(Convert.ToDecimal(value.StopPoints[i].ArrivalTime?.TotalHours), 0)
                                .ToString(CultureInfo.InvariantCulture),
                            value.StopPoints[i].ArrivalTime?
                                .ToString(@"hh\:mm\:ss")
                                .Substring(2, 6));
                        
                        stopTime.DepartureTime = string.Concat(Math
                                .Round(Convert.ToDecimal(value.StopPoints[i].DepartureTime?.TotalHours), 0)
                                .ToString(CultureInfo.InvariantCulture),
                            value.StopPoints[i].DepartureTime?
                                .ToString(@"hh\:mm\:ss")
                                .Substring(2, 6));
                    }
                    else
                    {
                        stopTime.ArrivalTime = value.StopPoints[i].ArrivalTime?
                            .ToString(@"hh\:mm\:ss");
                        
                        stopTime.DepartureTime = value.StopPoints[i].DepartureTime?
                            .ToString(@"hh\:mm\:ss");
                    }

                    timeSpan = value.StopPoints[i].DepartureTime ?? TimeSpan.Zero;
                }

                var stopId = string.Empty;
                
                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        stopId = value.StopPoints[i].NaptanStop?.AtcoCode ?? string.Empty;
                    }
                }
                else if (value.StopPoints[i].TransXChangeStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].TransXChangeStop?.StopPointReference))
                    {
                        stopId = value.StopPoints[i].TransXChangeStop?.StopPointReference ?? string.Empty;
                    }
                }

                stopTime.StopId = stopId;

                if (!string.IsNullOrEmpty(value.StopPoints[i].Activity))
                {
                    switch (value.StopPoints[i].Activity)
                    {
                        case "pickUp":
                        {
                            stopTime.PickupType = "0";
                            stopTime.DropOffType = "1";

                            break;
                        }
                        case "pickUpAndSetDown":
                        {
                            stopTime.PickupType = "0";
                            stopTime.DropOffType = "0";
                            
                            break;
                        }
                        case "setDown":
                        {
                            stopTime.PickupType = "1";
                            stopTime.DropOffType = "0";
                            
                            break;
                        }
                        default:
                        {
                            stopTime.PickupType = "1";
                            stopTime.DropOffType = "1";
                            
                            break;
                        }
                    }
                }

                _ = results.TryAdd(Guid.NewGuid().ToString(), stopTime);
            }
        }
        
        return results.OrderBy(s =>
            s.Value.TripId).ToDictionary(s =>
            s.Key, s =>
            s.Value);
    }
}