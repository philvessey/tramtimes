namespace TramTimes.Utilities.TransXChange.Extensions;

public static class StringExtensions
{
    public static DateTime ToDate(this string? baseString)
    {
        if (baseString == null) return DateTime.MinValue;
        
        var year = int.Parse(baseString[..4]);
        var month = int.Parse(baseString.Substring(5, 2));
        var day = int.Parse(baseString.Substring(8, 2));

        return new DateTime(year, month, day);
    }

    public static TimeSpan ToTime(this string? baseString)
    {
        if (baseString == null) return TimeSpan.MinValue;
        
        var hour = int.Parse(baseString[..2]);
        var minute = int.Parse(baseString.Substring(3, 2));
        var second = int.Parse(baseString.Substring(6, 2));

        return new TimeSpan(hour, minute, second);
    }
}