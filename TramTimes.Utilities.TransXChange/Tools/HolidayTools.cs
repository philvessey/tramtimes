using Nager.Date;
using Nager.Date.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class HolidayTools
{
    public static Holiday GetNewYearsDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return new Holiday
        {
            Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 1, 1),
            LocalName = "New Year's Day",
            EnglishName = "New Year's Day",
            CountryCode = CountryCode.GB,
            SubdivisionCodes = ["GB-ENG", "GB-SCT"]
        };
    }

    public static Holiday GetNewYearsDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();

        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h is { LocalName: "New Year's Day", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-ENG")) ?? new Holiday();
    }

    public static Holiday GetJanSecondScotland(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return new Holiday
        {
            Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 1, 2),
            LocalName = "New Year's Day",
            EnglishName = "New Year's Day",
            CountryCode = CountryCode.GB,
            SubdivisionCodes = ["GB-SCT"]
        };
    }

    public static Holiday GetJanSecondScotlandHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).LastOrDefault(h =>
            h is { LocalName: "New Year's Day", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-SCT")) ?? new Holiday();
    }

    public static Holiday GetGoodFriday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Good Friday") ?? new Holiday();
    }

    public static Holiday GetEasterMonday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Easter Monday") ?? new Holiday();
    }

    public static Holiday GetMayDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Early May Bank Holiday") ?? new Holiday();
    }

    public static Holiday GetSpringBank(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Spring Bank Holiday") ?? new Holiday();
    }

    public static Holiday GetAugustBankHolidayScotland(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h is { LocalName: "Summer Bank Holiday", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-SCT")) ?? new Holiday();
    }

    public static Holiday GetLateSummerBankHolidayNotScotland(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h is { LocalName: "Summer Bank Holiday", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-ENG")) ?? new Holiday();
    }

    public static Holiday GetStAndrewsDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return new Holiday
        {
            Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 11, 30),
            LocalName = "Saint Andrew's Day",
            EnglishName = "Saint Andrew's Day",
            CountryCode = CountryCode.GB,
            SubdivisionCodes = ["GB-SCT"]
        };
    }

    public static Holiday GetStAndrewsDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Saint Andrew's Day") ?? new Holiday();
    }

    public static Holiday GetChristmasEve(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return new Holiday
        {
            Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 24),
            LocalName = "Christmas Eve",
            EnglishName = "Christmas Eve",
            CountryCode = CountryCode.GB,
            SubdivisionCodes = ["GB-ENG", "GB-SCT"]
        };
    }

    public static Holiday GetChristmasDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return new Holiday
        {
            Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 25),
            LocalName = "Christmas Day",
            EnglishName = "Christmas Day",
            CountryCode = CountryCode.GB,
            SubdivisionCodes = ["GB-ENG", "GB-SCT"]
        };
    }

    public static Holiday GetChristmasDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Christmas Day") ?? new Holiday();
    }

    public static Holiday GetBoxingDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return new Holiday
        {
            Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 26),
            LocalName = "Boxing Day",
            EnglishName = "St. Stephen's Day",
            CountryCode = CountryCode.GB,
            SubdivisionCodes = ["GB-ENG", "GB-SCT"]
        };
    }

    public static Holiday GetBoxingDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Boxing Day") ?? new Holiday();
    }

    public static Holiday GetNewYearsEve(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return new Holiday();
        if (!endDate.HasValue) return new Holiday();
        
        return new Holiday
        {
            Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 31),
            LocalName = "New Year's Eve",
            EnglishName = "New Year's Eve",
            CountryCode = CountryCode.GB,
            SubdivisionCodes = ["GB-ENG", "GB-SCT"]
        };
    }
}