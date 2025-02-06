using Nager.Date;
using Nager.Date.Models;
using TramTimes.Utilities.TransXChange.Models;
using TramTimes.Utilities.TransXChange.Tools;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TransXChangeDaysOfNonOperationHelpers
{
    public static List<Holiday> Build(TransXChangeDaysOfNonOperation daysOfNonOperation, TravelineCalendar calendar, string subdivision, string? key)
    {
        if (string.IsNullOrEmpty(HolidaySystem.LicenseKey)) { HolidaySystem.LicenseKey = key; }

        return subdivision == "GB-ENG"
            ? ReturnEnglandHolidays(daysOfNonOperation, calendar)
            : ReturnScotlandHolidays(daysOfNonOperation, calendar);
    }

    private static List<Holiday> ReturnEnglandHolidays(TransXChangeDaysOfNonOperation daysOfNonOperation, TravelineCalendar calendar)
    {
        List<Holiday> results = [];
        
        if (!string.IsNullOrEmpty(daysOfNonOperation.AllBankHolidays))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation.AllHolidaysExceptChristmas))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation.Christmas))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation.DisplacementHolidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetChristmasDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDayHoliday(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation.EarlyRunOff))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasEve(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetNewYearsEve(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation.HolidayMondays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetLateSummerBankHolidayNotScotland(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation.Holidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        switch (string.IsNullOrEmpty(daysOfNonOperation.NewYearsDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.NewYearsDayHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.GoodFriday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.EasterMonday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.MayDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.SpringBank))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.LateSummerBankHolidayNotScotland))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.ChristmasEve))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.ChristmasDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.ChristmasDayHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.BoxingDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.BoxingDayHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.NewYearsEve))
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

    private static List<Holiday> ReturnScotlandHolidays(TransXChangeDaysOfNonOperation daysOfNonOperation, TravelineCalendar calendar)
    {
        List<Holiday> results = [];

        if (!string.IsNullOrEmpty(daysOfNonOperation.AllBankHolidays))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation.AllHolidaysExceptChristmas))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation.Christmas))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetBoxingDay(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation.DisplacementHolidays))
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

        if (!string.IsNullOrEmpty(daysOfNonOperation.EarlyRunOff))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetChristmasEve(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetNewYearsEve(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation.HolidayMondays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetEasterMonday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetMayDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetSpringBank(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetAugustBankHolidayScotland(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        if (!string.IsNullOrEmpty(daysOfNonOperation.Holidays))
        {
            if (calendar is { StartDate: not null, EndDate: not null })
            {
                results.AddRange(HolidayTools.GetNewYearsDay(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetJanSecondScotland(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetGoodFriday(calendar.StartDate.Value, calendar.EndDate.Value));
                results.AddRange(HolidayTools.GetStAndrewsDay(calendar.StartDate.Value, calendar.EndDate.Value));
            }
        }

        switch (string.IsNullOrEmpty(daysOfNonOperation.NewYearsDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.NewYearsDayHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.JanSecondScotland))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.JanSecondScotlandHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.GoodFriday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.EasterMonday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.MayDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.SpringBank))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.AugustBankHolidayScotland))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.StAndrewsDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.StAndrewsDayHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.ChristmasEve))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.ChristmasDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.ChristmasDayHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.BoxingDay))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.BoxingDayHoliday))
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
        
        switch (string.IsNullOrEmpty(daysOfNonOperation.NewYearsEve))
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