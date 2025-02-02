using Nager.Date;
using Nager.Date.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class HolidayTools
{
    public static List<Holiday> GetNewYearsDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results =
        [
            new()
            {
                Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 1, 1),
                LocalName = "New Year's Day",
                EnglishName = "New Year's Day",
                CountryCode = CountryCode.GB,
                SubdivisionCodes = ["GB-ENG", "GB-SCT"]
            }
        ];

        return results;
    }

    public static List<Holiday> GetNewYearsDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h is { LocalName: "New Year's Day", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-ENG"));

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetJanSecondScotland(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results =
        [
            new()
            {
                Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 1, 2),
                LocalName = "New Year's Day",
                EnglishName = "New Year's Day",
                CountryCode = CountryCode.GB,
                SubdivisionCodes = ["GB-SCT"]
            }
        ];

        return results;
    }

    public static List<Holiday> GetJanSecondScotlandHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).LastOrDefault(h =>
            h is { LocalName: "New Year's Day", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-SCT"));

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetGoodFriday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Good Friday");

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetEasterMonday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Easter Monday");

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetMayDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Early May Bank Holiday");

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetSpringBank(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Spring Bank Holiday");

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetAugustBankHolidayScotland(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h is { LocalName: "Summer Bank Holiday", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-SCT"));

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetLateSummerBankHolidayNotScotland(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h is { LocalName: "Summer Bank Holiday", SubdivisionCodes: not null } && h.SubdivisionCodes.Contains("GB-ENG"));

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetStAndrewsDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results =
        [
            new()
            {
                Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 11, 30),
                LocalName = "Saint Andrew's Day",
                EnglishName = "Saint Andrew's Day",
                CountryCode = CountryCode.GB,
                SubdivisionCodes = ["GB-SCT"]
            }
        ];

        return results;
    }

    public static List<Holiday> GetStAndrewsDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Saint Andrew's Day");

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetChristmasEve(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results =
        [
            new()
            {
                Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 24),
                LocalName = "Christmas Eve",
                EnglishName = "Christmas Eve",
                CountryCode = CountryCode.GB,
                SubdivisionCodes = ["GB-ENG", "GB-SCT"]
            }
        ];

        return results;
    }

    public static List<Holiday> GetChristmasDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results =
        [
            new()
            {
                Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 25),
                LocalName = "Christmas Day",
                EnglishName = "Christmas Day",
                CountryCode = CountryCode.GB,
                SubdivisionCodes = ["GB-ENG", "GB-SCT"]
            }
        ];

        return results;
    }

    public static List<Holiday> GetChristmasDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Christmas Day");

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetBoxingDay(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results =
        [
            new()
            {
                Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 26),
                LocalName = "Boxing Day",
                EnglishName = "St. Stephen's Day",
                CountryCode = CountryCode.GB,
                SubdivisionCodes = ["GB-ENG", "GB-SCT"]
            }
        ];

        return results;
    }

    public static List<Holiday> GetBoxingDayHoliday(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results = [];

        var holiday = HolidaySystem.GetHolidays(startDate.Value, endDate.Value, CountryCode.GB).FirstOrDefault(h =>
            h.LocalName == "Boxing Day");

        if (holiday != null)
        {
            results.Add(holiday);
        }

        return results;
    }

    public static List<Holiday> GetNewYearsEve(DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return [];
        }
        
        List<Holiday> results =
        [
            new()
            {
                Date = new DateTime(new DateTime(Math.Max(startDate.Value.Ticks, endDate.Value.Ticks)).Year, 12, 31),
                LocalName = "New Year's Eve",
                EnglishName = "New Year's Eve",
                CountryCode = CountryCode.GB,
                SubdivisionCodes = ["GB-ENG", "GB-SCT"]
            }
        ];

        return results;
    }
}