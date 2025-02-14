using System.Globalization;
using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class GtfsStopTimeTools
{
    public static Dictionary<string, GtfsStopTime> GetFromSchedules(Dictionary<string, TravelineSchedule> schedules)
    {
        var results = new Dictionary<string, GtfsStopTime>();
        
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

            var timeSpan = TimeSpan.Zero;

            for (var i = 0; i < value.StopPoints?.Count; i++)
            {
                GtfsStopTime stopTime = new()
                {
                    TripId = value.Id,
                    StopId = value.StopPoints[i].NaptanStop?.AtcoCode ?? value.StopPoints[i].TravelineStop?.AtcoCode,
                    StopSequence = Convert.ToString(i + 1)
                };

                if (value.StopPoints[i].DepartureTime < timeSpan)
                {
                    stopTime.ArrivalTime = string.Concat(Math.Round(Convert.ToDecimal(
                        value.StopPoints[i].ArrivalTime?.Add(new TimeSpan(24, 0, 0)).TotalHours), 0).ToString(CultureInfo.CurrentCulture), 
                        value.StopPoints[i].ArrivalTime?.Add(new TimeSpan(24, 0, 0)).ToString(@"hh\:mm\:ss").Substring(2, 6));
                    
                    stopTime.DepartureTime = string.Concat(Math.Round(Convert.ToDecimal(
                        value.StopPoints[i].DepartureTime?.Add(new TimeSpan(24, 0, 0)).TotalHours), 0).ToString(CultureInfo.CurrentCulture), 
                        value.StopPoints[i].DepartureTime?.Add(new TimeSpan(24, 0, 0)).ToString(@"hh\:mm\:ss").Substring(2, 6));
                        
                    timeSpan = value.StopPoints[i].DepartureTime?.Add(new TimeSpan(24, 0, 0)) ?? TimeSpan.Zero;
                }
                else
                {
                    stopTime.ArrivalTime = value.StopPoints[i].ArrivalTime?.ToString(@"hh\:mm\:ss");
                    stopTime.DepartureTime = value.StopPoints[i].DepartureTime?.ToString(@"hh\:mm\:ss");
                        
                    timeSpan = value.StopPoints[i].DepartureTime ?? TimeSpan.Zero;
                }
                
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

                _ = results.TryAdd(Guid.NewGuid().ToString(), stopTime);
            }
        }
        
        return results.OrderBy(time =>
            time.Value.TripId).ToDictionary(time =>
            time.Key, time =>
            time.Value);
    }
}