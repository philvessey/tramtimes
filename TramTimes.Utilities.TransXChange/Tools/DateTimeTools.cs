using System.Globalization;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class DateTimeTools
{
    public static DateTime GetScheduleDate(DateTime result, string date)
    {
        if (DateTime.TryParse(date, CultureInfo.CreateSpecificCulture("en-GB"), out var value))
        {
            result = value;
        }

        result = date switch
        {
            "yesterday" => result.AddDays(-1),
            "today" => result.AddDays(0),
            "tomorrow" => result.AddDays(1),
            _ => result
        };

        return result;
    }
    
    public static DateTime GetStartDate(DateTime result, DateTime now, int days)
    {
        days = days switch
        {
            < 1 => 0,
            > 28 => 27,
            _ => days - 1
        };

        return result;
    }
    
    public static DateTime GetEndDate(DateTime result, DateTime now, int days)
    {
        days = days switch
        {
            < 1 => 0,
            > 28 => 27,
            _ => days - 1
        };

        return result;
    }
    
    public static DateTime GetHolidayDate(DateTime result, DateTime now, int days)
    {
        days = days switch
        {
            < 1 => 0,
            > 28 => 27,
            _ => days - 1
        };

        return result;
    }
}