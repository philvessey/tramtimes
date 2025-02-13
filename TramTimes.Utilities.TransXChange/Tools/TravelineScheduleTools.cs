using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TravelineScheduleTools
{
    public static bool GetDuplicateMatch(Dictionary<string, TravelineSchedule> schedules, List<TravelineStopPoint>? stopPoints, List<DateTime>? runningDates, List<DateTime>? supplementRunningDates, List<DateTime>? supplementNonRunningDates)
    {
        return TravelineRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates) ||
               TravelineRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates) ||
               TravelineRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates) ||
               TravelineSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates) ||
               TravelineSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates) ||
               TravelineSupplementRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates) ||
               TravelineSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, runningDates) ||
               TravelineSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementRunningDates) ||
               TravelineSupplementNonRunningDateTools.GetDuplicateDates(schedules, stopPoints, supplementNonRunningDates);
    }
}