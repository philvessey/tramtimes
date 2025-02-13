namespace TramTimes.Utilities.TransXChange.Tools;

public static class DateTimeTools
{
    public static DateTime GetPeriodStartDate(DateTime scheduleDate, DateTime? startDate)
    {
        if (!startDate.HasValue) return scheduleDate;
        if (startDate.Value == DateTime.MinValue) return scheduleDate;
        
        if (startDate.Value < scheduleDate) return scheduleDate;
        if (startDate.Value == scheduleDate) return scheduleDate;

        return startDate.Value.Subtract(scheduleDate).TotalDays < 6 ? startDate.Value : DateTime.MaxValue;
    }
    
    public static DateTime GetPeriodEndDate(DateTime scheduleDate, DateTime? endDate)
    {
        if (!endDate.HasValue) return scheduleDate.AddDays(6);
        if (endDate.Value == DateTime.MinValue) return scheduleDate.AddDays(6);
        
        if (endDate.Value < scheduleDate) return DateTime.MinValue;
        if (endDate.Value == scheduleDate) return scheduleDate;
        
        return endDate.Value.Subtract(scheduleDate).TotalDays > 6 ? scheduleDate.AddDays(6) : endDate.Value;
    }
    
    public static DateTime GetProfileStartDate(DateTime scheduleDate, DateTime? startDate)
    {
        if (!startDate.HasValue) return DateTime.MaxValue;
        if (startDate.Value == DateTime.MinValue) return DateTime.MaxValue;
        
        if (startDate.Value < scheduleDate) return DateTime.MaxValue;
        if (startDate.Value == scheduleDate) return startDate.Value;

        return startDate.Value.Subtract(scheduleDate).TotalDays < 6 ? startDate.Value : DateTime.MaxValue;
    }
    
    public static DateTime GetProfileEndDate(DateTime scheduleDate, DateTime? endDate)
    {
        if (!endDate.HasValue) return DateTime.MinValue;
        if (endDate.Value == DateTime.MinValue) return DateTime.MinValue;
        
        if (endDate.Value < scheduleDate) return DateTime.MinValue;
        if (endDate.Value == scheduleDate) return endDate.Value;
        
        return endDate.Value.Subtract(scheduleDate).TotalDays < 6 ? endDate.Value : DateTime.MinValue;
    }
}