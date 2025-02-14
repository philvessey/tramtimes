using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TravelineScheduleTools
{
    public static bool GetDuplicateMatch(Dictionary<string, TravelineSchedule> schedules, List<TravelineStopPoint>? stopPoints, List<DateTime>? runningDates, List<DateTime>? supplementRunningDates, List<DateTime>? supplementNonRunningDates, string? direction, string? line)
    {
        return TravelineRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates, direction, line) ||
               TravelineRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates, direction, line) ||
               TravelineRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates, direction, line) ||
               TravelineSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates, direction, line) ||
               TravelineSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates, direction, line) ||
               TravelineSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates, direction, line) ||
               TravelineSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates, direction, line) ||
               TravelineSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates, direction, line) ||
               TravelineSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates, direction, line);
    }
}