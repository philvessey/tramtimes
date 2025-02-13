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
        
        if (daysOfOperation?.AllBankHolidays != null)
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

        if (daysOfOperation?.AllHolidaysExceptChristmas != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.Christmas != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.DisplacementHolidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.EarlyRunOff != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.HolidayMondays != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.Holidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.NewYearsDay != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.NewYearsDayHoliday != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.GoodFriday != null)
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.EasterMonday != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.MayDay != null)
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.SpringBank != null)
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.LateSummerBankHolidayNotScotland != null)
        {
            results.Add(HolidayTools.GetLateSummerBankHolidayNotScotland(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.ChristmasEve != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.ChristmasDay != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.ChristmasDayHoliday != null)
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.BoxingDay != null)
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.BoxingDayHoliday != null)
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.NewYearsEve != null)
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
        
        if (daysOfOperation?.AllBankHolidays != null)
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

        if (daysOfOperation?.AllHolidaysExceptChristmas != null)
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

        if (daysOfOperation?.Christmas != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.DisplacementHolidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.EarlyRunOff != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.HolidayMondays != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.Holidays != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }

        if (daysOfOperation?.NewYearsDay != null)
        {
            results.Add(HolidayTools.GetNewYearsDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.NewYearsDayHoliday != null)
        {
            results.Add(HolidayTools.GetNewYearsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.JanSecondScotland != null)
        {
            results.Add(HolidayTools.GetJanSecondScotland(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.JanSecondScotlandHoliday != null)
        {
            results.Add(HolidayTools.GetJanSecondScotlandHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.GoodFriday != null)
        {
            results.Add(HolidayTools.GetGoodFriday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.EasterMonday != null)
        {
            results.Add(HolidayTools.GetEasterMonday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.MayDay != null)
        {
            results.Add(HolidayTools.GetMayDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.SpringBank != null)
        {
            results.Add(HolidayTools.GetSpringBank(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.AugustBankHolidayScotland != null)
        {
            results.Add(HolidayTools.GetAugustBankHolidayScotland(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.StAndrewsDay != null)
        {
            results.Add(HolidayTools.GetStAndrewsDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.StAndrewsDayHoliday != null)
        {
            results.Add(HolidayTools.GetStAndrewsDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.ChristmasEve != null)
        {
            results.Add(HolidayTools.GetChristmasEve(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.ChristmasDay != null)
        {
            results.Add(HolidayTools.GetChristmasDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.ChristmasDayHoliday != null)
        {
            results.Add(HolidayTools.GetChristmasDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.BoxingDay != null)
        {
            results.Add(HolidayTools.GetBoxingDay(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.BoxingDayHoliday != null)
        {
            results.Add(HolidayTools.GetBoxingDayHoliday(startDate.Value, endDate.Value));
        }
        
        if (daysOfOperation?.NewYearsEve != null)
        {
            results.Add(HolidayTools.GetNewYearsEve(startDate.Value, endDate.Value));
        }

        return results;
    }
}