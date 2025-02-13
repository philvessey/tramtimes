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
        
        if (daysOfNonOperation?.AllBankHolidays != null)
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

        if (daysOfNonOperation?.AllHolidaysExceptChristmas != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.Christmas != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.DisplacementHolidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.EarlyRunOff != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.HolidayMondays != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.Holidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.NewYearsDay != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.NewYearsDayHoliday != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.GoodFriday != null)
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.EasterMonday != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.MayDay != null)
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.SpringBank != null)
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.LateSummerBankHolidayNotScotland != null)
        {
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.ChristmasEve != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.ChristmasDay != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.ChristmasDayHoliday != null)
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.BoxingDay != null)
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.BoxingDayHoliday != null)
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.NewYearsEve != null)
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
        
        if (daysOfNonOperation?.AllBankHolidays != null)
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

        if (daysOfNonOperation?.AllHolidaysExceptChristmas != null)
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

        if (daysOfNonOperation?.Christmas != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.DisplacementHolidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.EarlyRunOff != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.HolidayMondays != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.Holidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }

        if (daysOfNonOperation?.NewYearsDay != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.NewYearsDayHoliday != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.JanSecondScotland != null)
        {
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.JanSecondScotlandHoliday != null)
        {
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.GoodFriday != null)
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.EasterMonday != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.MayDay != null)
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.SpringBank != null)
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.AugustBankHolidayScotland != null)
        {
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.StAndrewsDay != null)
        {
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.StAndrewsDayHoliday != null)
        {
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.ChristmasEve != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.ChristmasDay != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.ChristmasDayHoliday != null)
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.BoxingDay != null)
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.BoxingDayHoliday != null)
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfNonOperation?.NewYearsEve != null)
        {
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        return results;
    }
}