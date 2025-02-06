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
    
    public static DateTime GetStartDate(DateTime? startDate, DateTime scheduleDate, int days)
    {
        days = days switch
        {
            < 1 => 0,
            > 28 => 27,
            _ => days - 1
        };
        
        if (!startDate.HasValue)
        {
            return scheduleDate;
        }

        if (startDate.Value == DateTime.MinValue)
        {
            return scheduleDate;
        }
        
        if (startDate.Value < scheduleDate) return scheduleDate;
        if (startDate.Value == scheduleDate) return scheduleDate;

        return startDate.Value.Subtract(scheduleDate).TotalDays < days ? startDate.Value : DateTime.MaxValue;
    }
    
    public static DateTime GetEndDate(DateTime? endDate, DateTime scheduleDate, int days)
    {
        days = days switch
        {
            < 1 => 0,
            > 28 => 27,
            _ => days - 1
        };
        
        if (!endDate.HasValue)
        {
            return scheduleDate.AddDays(days);
        }

        if (endDate.Value == DateTime.MinValue)
        {
            return scheduleDate.AddDays(days);
        }
        
        if (endDate.Value < scheduleDate) return DateTime.MinValue;
        if (endDate.Value == scheduleDate) return scheduleDate;
        
        return endDate.Value.Subtract(scheduleDate).TotalDays > days ? scheduleDate.AddDays(days) : endDate.Value;
    }
}