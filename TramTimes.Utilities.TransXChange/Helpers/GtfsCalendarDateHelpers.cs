using System.Globalization;
using CsvHelper;
using TramTimes.Utilities.TransXChange.Models;
using TramTimes.Utilities.TransXChange.Tools;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class GtfsCalendarDateHelpers
{
    public static string Build(Dictionary<string, TravelineSchedule> schedules, string path)
    {
        using StreamWriter writer = new(Path.Combine(path, "calendar_dates.txt"));
        using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);

        csv.WriteHeader<GtfsCalendarDate>();
        csv.NextRecord();

        foreach (var value in GtfsCalendarDateTools.GetFromSchedules(schedules).Values)
        {
            csv.WriteRecord(value);
            csv.NextRecord();
        }
        
        return Path.Combine(path, "calendar_dates.txt");
    }
}