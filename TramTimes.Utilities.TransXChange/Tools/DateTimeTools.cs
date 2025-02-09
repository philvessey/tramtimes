namespace TramTimes.Utilities.TransXChange.Tools;

public static class DateTimeTools
{
    public static DateTime GetStartDate(DateTime? startDate, DateTime scheduleDate)
    {
        if (!startDate.HasValue) return scheduleDate;
        if (startDate.Value == DateTime.MinValue) return scheduleDate;
        
        if (startDate.Value < scheduleDate) return scheduleDate;
        if (startDate.Value == scheduleDate) return scheduleDate;

        return startDate.Value.Subtract(scheduleDate).TotalDays < 6 ? startDate.Value : DateTime.MaxValue;
    }
    
    public static DateTime GetEndDate(DateTime? endDate, DateTime scheduleDate)
    {
        if (!endDate.HasValue) return scheduleDate.AddDays(6);
        if (endDate.Value == DateTime.MinValue) return scheduleDate.AddDays(6);
        
        if (endDate.Value < scheduleDate) return DateTime.MinValue;
        if (endDate.Value == scheduleDate) return scheduleDate;
        
        return endDate.Value.Subtract(scheduleDate).TotalDays > 6 ? scheduleDate.AddDays(6) : endDate.Value;
    }
}