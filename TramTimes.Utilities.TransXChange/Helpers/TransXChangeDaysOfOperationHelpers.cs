using Nager.Date;
using Nager.Date.Models;
using TramTimes.Utilities.TransXChange.Models;
using TramTimes.Utilities.TransXChange.Tools;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TransXChangeDaysOfOperationHelpers
{
    public static List<Holiday> Build(TransXChangeDaysOfOperation daysOfOperation, TransXChangeCalendar calendar, string subdivision, string? key)
    {
        if (string.IsNullOrEmpty(HolidaySystem.LicenseKey)) { HolidaySystem.LicenseKey = key; }

        return subdivision == "GB-ENG"
            ? ReturnEnglandHolidays(daysOfOperation, calendar)
            : ReturnScotlandHolidays(daysOfOperation, calendar);
    }

    private static List<Holiday> ReturnEnglandHolidays(TransXChangeDaysOfOperation daysOfOperation, TransXChangeCalendar calendar)
    {
        List<Holiday> results = [];
        
        if (!string.IsNullOrEmpty(daysOfOperation.AllBankHolidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetNewYearsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetLateSummerBankHolidayNotScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetChristmasDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.AllHolidaysExceptChristmas))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetLateSummerBankHolidayNotScotland(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.Christmas))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.DisplacementHolidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetChristmasDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.EarlyRunOff))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasEve(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetNewYearsEve(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.HolidayMondays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetLateSummerBankHolidayNotScotland(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.Holidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        switch (string.IsNullOrEmpty(daysOfOperation.NewYearsDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.NewYearsDayHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetNewYearsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.GoodFriday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.EasterMonday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.MayDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.SpringBank))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.LateSummerBankHolidayNotScotland))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetLateSummerBankHolidayNotScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.ChristmasEve))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetChristmasEve(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.ChristmasDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.ChristmasDayHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetChristmasDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.BoxingDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.BoxingDayHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetBoxingDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.NewYearsEve))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetNewYearsEve(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }

        return results;
    }

    private static List<Holiday> ReturnScotlandHolidays(TransXChangeDaysOfOperation daysOfOperation, TransXChangeCalendar calendar)
    {
        List<Holiday> results = [];

        if (!string.IsNullOrEmpty(daysOfOperation.AllBankHolidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetNewYearsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetJanSecondScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetJanSecondScotlandHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetAugustBankHolidayScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetStAndrewsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetStAndrewsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetChristmasDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.AllHolidaysExceptChristmas))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetJanSecondScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetAugustBankHolidayScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetStAndrewsDay(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.Christmas))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.DisplacementHolidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetJanSecondScotlandHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetStAndrewsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetChristmasDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.EarlyRunOff))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasEve(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetNewYearsEve(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.HolidayMondays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetAugustBankHolidayScotland(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfOperation.Holidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetJanSecondScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetStAndrewsDay(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        switch (string.IsNullOrEmpty(daysOfOperation.NewYearsDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.NewYearsDayHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetNewYearsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.JanSecondScotland))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetJanSecondScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.JanSecondScotlandHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetJanSecondScotlandHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.GoodFriday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.EasterMonday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.MayDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.SpringBank))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.AugustBankHolidayScotland))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetAugustBankHolidayScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.StAndrewsDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetStAndrewsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.StAndrewsDayHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetStAndrewsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.ChristmasEve))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetChristmasEve(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.ChristmasDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.ChristmasDayHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetChristmasDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.BoxingDay))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.BoxingDayHoliday))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetBoxingDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }
        
        switch (string.IsNullOrEmpty(daysOfOperation.NewYearsEve))
        {
            case false:
            {
                if (calendar is { StartDate: not null, EndDate: not null })
                {
                    results.AddRange(HolidayTools.GetNewYearsEve(calendar.StartDate.Value, calendar.EndDate.Value));
                }

                break;
            }
        }

        return results;
    }
}