using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TravelineScheduleTools
{
    public static bool GetDuplicateMatch(Dictionary<string, TravelineSchedule> schedules, List<TravelineStopPoint>? stopPoints, List<DateTime>? runningDates, List<DateTime>? supplementRunningDates, List<DateTime>? supplementNonRunningDates, string? direction, string? line)
    {
        return TravelineCalendarRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates, direction, line) ||
               TravelineCalendarRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates, direction, line) ||
               TravelineCalendarRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates, direction, line) ||
               TravelineCalendarSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates, direction, line) ||
               TravelineCalendarSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates, direction, line) ||
               TravelineCalendarSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates, direction, line) ||
               TravelineCalendarSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates, direction, line) ||
               TravelineCalendarSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates, direction, line) ||
               TravelineCalendarSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates, direction, line);
    }
}