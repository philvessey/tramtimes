using Nager.Date.Models;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TransXChangeDaysOfOperationTools
{
    public static List<Holiday> GetEnglandHolidays(TransXChangeDaysOfOperation? daysOfOperation, DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return [];
        if (!endDate.HasValue) return [];
        
        List<Holiday> results = [];
        
        if (!string.IsNullOrEmpty(daysOfOperation?.AllBankHolidays))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.AllHolidaysExceptChristmas))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.Christmas))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.DisplacementHolidays))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.EarlyRunOff))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.HolidayMondays))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.Holidays))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.NewYearsDay))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.NewYearsDayHoliday))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.GoodFriday))
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.EasterMonday))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.MayDay))
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.SpringBank))
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.LateSummerBankHolidayNotScotland))
        {
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.ChristmasEve))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.ChristmasDay))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.ChristmasDayHoliday))
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.BoxingDay))
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.BoxingDayHoliday))
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.NewYearsEve))
        {
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        return results;
    }
    
    public static List<Holiday> GetScotlandHolidays(TransXChangeDaysOfOperation? daysOfOperation, DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return [];
        if (!endDate.HasValue) return [];
        
        List<Holiday> results = [];
        
        if (!string.IsNullOrEmpty(daysOfOperation?.AllBankHolidays))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.AllHolidaysExceptChristmas))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.Christmas))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.DisplacementHolidays))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.EarlyRunOff))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.HolidayMondays))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.Holidays))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfOperation?.NewYearsDay))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.NewYearsDayHoliday))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.JanSecondScotland))
        {
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.JanSecondScotlandHoliday))
        {
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.GoodFriday))
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.EasterMonday))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.MayDay))
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.SpringBank))
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.AugustBankHolidayScotland))
        {
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.StAndrewsDay))
        {
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.StAndrewsDayHoliday))
        {
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.ChristmasEve))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.ChristmasDay))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.ChristmasDayHoliday))
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.BoxingDay))
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.BoxingDayHoliday))
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfOperation?.NewYearsEve))
        {
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        return results;
    }
}