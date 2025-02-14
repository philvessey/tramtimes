using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TravelineRunningDateTools
{
    public static List<DateTime> GetAllDates(DateTime? startDate, DateTime? endDate, bool? monday, bool? tuesday, bool? wednesday, bool? thursday, bool? friday, bool? saturday, bool? sunday)
    {
        if (!startDate.HasValue) return [];
        if (!endDate.HasValue) return [];
        
        var results = new List<DateTime>();

        while (startDate.Value <= endDate.Value)
        {
            switch (startDate.Value.DayOfWeek)
            {
                case DayOfWeek.Monday:
                {
                    if (monday.HasValue && monday.Value)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Tuesday:
                {
                    if (tuesday.HasValue && tuesday.Value)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Wednesday:
                {
                    if (wednesday.HasValue && wednesday.Value)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Thursday:
                {
                    if (thursday.HasValue && thursday.Value)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Friday:
                {
                    if (friday.HasValue && friday.Value)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Saturday:
                {
                    if (saturday.HasValue && saturday.Value)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Sunday:
                {
                    if (sunday.HasValue && sunday.Value)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                default:
                {
                    if (!results.Contains(startDate.Value))
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
            }

            startDate = startDate.Value.AddDays(1);
        }

        return results.Distinct().OrderBy(date => date).ToList();
    }
    
    public static bool GetDuplicateDates(Dictionary<string, TravelineSchedule> schedules, List<TravelineStopPoint>? stopPoints, List<DateTime>? dates, string? direction, string? line)
    {
        var results = schedules.Values.Where(schedule =>
            schedule.Calendar is { RunningDates: not null } && dates != null && direction != null && line != null &&
            schedule.Calendar.RunningDates.Intersect(dates).Any() && schedule.Direction == direction && schedule.Line == line).ToList();
        
        return results.Where(schedule =>
            schedule.StopPoints?.FirstOrDefault()?.AtcoCode == stopPoints?.FirstOrDefault()?.AtcoCode &&
            schedule.StopPoints?.FirstOrDefault()?.DepartureTime == stopPoints?.FirstOrDefault()?.DepartureTime).Any(schedule =>
            schedule.StopPoints?.LastOrDefault()?.AtcoCode == stopPoints?.LastOrDefault()?.AtcoCode &&
            schedule.StopPoints?.LastOrDefault()?.ArrivalTime == stopPoints?.LastOrDefault()?.ArrivalTime);
    }
}