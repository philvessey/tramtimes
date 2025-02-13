using Nager.Date.Models;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TransXChangeDaysOfNonOperationTools
{
    public static List<Holiday> GetEnglandHolidays(TransXChangeDaysOfNonOperation? daysOfNonOperation, DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return [];
        if (!endDate.HasValue) return [];
        
        List<Holiday> results = [];
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.AllBankHolidays))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation?.AllHolidaysExceptChristmas))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.Christmas))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.DisplacementHolidays))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.EarlyRunOff))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.HolidayMondays))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.Holidays))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.NewYearsDay))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.NewYearsDayHoliday))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.GoodFriday))
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.EasterMonday))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.MayDay))
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.SpringBank))
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.LateSummerBankHolidayNotScotland))
        {
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.ChristmasEve))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.ChristmasDay))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.ChristmasDayHoliday))
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.BoxingDay))
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.BoxingDayHoliday))
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.NewYearsEve))
        {
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        return results;
    }
    
    public static List<Holiday> GetScotlandHolidays(TransXChangeDaysOfNonOperation? daysOfNonOperation, DateTime? startDate, DateTime? endDate)
    {
        if (!startDate.HasValue) return [];
        if (!endDate.HasValue) return [];
        
        List<Holiday> results = [];
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.AllBankHolidays))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation?.AllHolidaysExceptChristmas))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation?.Christmas))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.DisplacementHolidays))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.EarlyRunOff))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.HolidayMondays))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.Holidays))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation?.NewYearsDay))
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.NewYearsDayHoliday))
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.JanSecondScotland))
        {
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.JanSecondScotlandHoliday))
        {
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.GoodFriday))
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.EasterMonday))
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.MayDay))
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.SpringBank))
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.AugustBankHolidayScotland))
        {
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.StAndrewsDay))
        {
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.StAndrewsDayHoliday))
        {
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.ChristmasEve))
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.ChristmasDay))
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.ChristmasDayHoliday))
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.BoxingDay))
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.BoxingDayHoliday))
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (!string.IsNullOrEmpty(daysOfNonOperation?.NewYearsEve))
        {
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        return results;
    }
}