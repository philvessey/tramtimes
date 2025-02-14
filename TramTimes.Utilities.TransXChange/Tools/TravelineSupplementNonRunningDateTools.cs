using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TravelineSupplementNonRunningDateTools
{
    public static bool GetDuplicateDates(Dictionary<string, TravelineSchedule> schedules, List<TravelineStopPoint>? stopPoints, List<DateTime>? dates, string? direction, string? line)
    {
        var results = schedules.Values.Where(schedule =>
            schedule.Calendar is { SupplementNonRunningDates: not null } && dates != null && direction != null && line != null &&
            schedule.Calendar.SupplementNonRunningDates.Intersect(dates).Any() && schedule.Direction == direction && schedule.Line == line).ToList();
        
        return results.Where(schedule =>
            schedule.StopPoints?.FirstOrDefault()?.AtcoCode == stopPoints?.FirstOrDefault()?.AtcoCode &&
            schedule.StopPoints?.FirstOrDefault()?.DepartureTime == stopPoints?.FirstOrDefault()?.DepartureTime).Any(schedule =>
            schedule.StopPoints?.LastOrDefault()?.AtcoCode == stopPoints?.LastOrDefault()?.AtcoCode &&
            schedule.StopPoints?.LastOrDefault()?.ArrivalTime == stopPoints?.LastOrDefault()?.ArrivalTime);
    }
    
    public static List<DateTime> GetEnglandDates(DateTime scheduleDate, TransXChangeOperatingProfile? operatingProfile, DateTime? startDate, DateTime? endDate, bool? monday, bool? tuesday, bool? wednesday, bool? thursday, bool? friday, bool? saturday, bool? sunday, List<DateTime>? dates)
    {
        if (!startDate.HasValue) return [];
        if (!endDate.HasValue) return [];
        
        var results = new List<DateTime>();
        
        results.AddRange(TransXChangeDaysOfNonOperationTools.GetEnglandHolidays(operatingProfile?.BankHolidayOperation?.DaysOfNonOperation, 
            startDate.Value, endDate.Value).Where(holiday => holiday.Date >= startDate.Value && holiday.Date <= endDate.Value).Select(holiday => holiday.Date));
        
        startDate = DateTimeTools.GetProfileStartDate(scheduleDate, operatingProfile?.SpecialDaysOperation?.DaysOfNonOperation?.DateRange?.StartDate.ToDate());
        endDate = DateTimeTools.GetProfileEndDate(scheduleDate, operatingProfile?.SpecialDaysOperation?.DaysOfNonOperation?.DateRange?.EndDate.ToDate());

        while (startDate.Value <= endDate.Value)
        {
            switch (startDate.Value.DayOfWeek)
            {
                case DayOfWeek.Monday:
                {
                    if (monday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Tuesday:
                {
                    if (tuesday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Wednesday:
                {
                    if (wednesday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Thursday:
                {
                    if (thursday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Friday:
                {
                    if (friday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Saturday:
                {
                    if (saturday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Sunday:
                {
                    if (sunday.HasValue && dates?.Contains(startDate.Value) == true)
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
    
    public static List<DateTime> GetScotlandDates(DateTime scheduleDate, TransXChangeOperatingProfile? operatingProfile, DateTime? startDate, DateTime? endDate, bool? monday, bool? tuesday, bool? wednesday, bool? thursday, bool? friday, bool? saturday, bool? sunday, List<DateTime>? dates)
    {
        if (!startDate.HasValue) return [];
        if (!endDate.HasValue) return [];
        
        var results = new List<DateTime>();
        
        results.AddRange(TransXChangeDaysOfNonOperationTools.GetScotlandHolidays(operatingProfile?.BankHolidayOperation?.DaysOfNonOperation, 
            startDate.Value, endDate.Value).Where(holiday => holiday.Date >= startDate.Value && holiday.Date <= endDate.Value).Select(holiday => holiday.Date));

        startDate = DateTimeTools.GetProfileStartDate(scheduleDate, operatingProfile?.SpecialDaysOperation?.DaysOfNonOperation?.DateRange?.StartDate.ToDate());
        endDate = DateTimeTools.GetProfileEndDate(scheduleDate, operatingProfile?.SpecialDaysOperation?.DaysOfNonOperation?.DateRange?.EndDate.ToDate());

        while (startDate.Value <= endDate.Value)
        {
            switch (startDate.Value.DayOfWeek)
            {
                case DayOfWeek.Monday:
                {
                    if (monday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Tuesday:
                {
                    if (tuesday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Wednesday:
                {
                    if (wednesday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Thursday:
                {
                    if (thursday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Friday:
                {
                    if (friday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Saturday:
                {
                    if (saturday.HasValue && dates?.Contains(startDate.Value) == true)
                    {
                        results.Add(startDate.Value);
                    }

                    break;
                }
                case DayOfWeek.Sunday:
                {
                    if (sunday.HasValue && dates?.Contains(startDate.Value) == true)
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
}