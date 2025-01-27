using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TransXChangeCalendarHelpers
{
    public static TransXChangeCalendar Build(TransXChangeOperatingProfile operatingProfile, DateTime startDate, DateTime endDate)
    {
        TransXChangeCalendar result = new()
        {
            Monday = false,
            Tuesday = false,
            Wednesday = false,
            Thursday = false,
            Friday = false,
            Saturday = false,
            Sunday = false,
            StartDate = startDate,
            EndDate = endDate,
            RunningDates = [],
            SupplementRunningDates = [],
            SupplementNonRunningDates = []
        };

        if (operatingProfile.RegularDayType?.DaysOfWeek != null)
        {
            if (operatingProfile.RegularDayType.DaysOfWeek.MondayToFriday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = false;
                result.Sunday = false;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.MondayToSaturday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = true;
                result.Sunday = false;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.MondayToSunday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = true;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.Weekend == string.Empty)
            {
                result.Monday = false;
                result.Tuesday = false;
                result.Wednesday = false;
                result.Thursday = false;
                result.Friday = false;
                result.Saturday = true;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.NotMonday == string.Empty)
            {
                result.Monday = false;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = true;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.NotTuesday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = false;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = true;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.NotWednesday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = false;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = true;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.NotThursday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = false;
                result.Friday = true;
                result.Saturday = true;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.NotFriday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = false;
                result.Saturday = true;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.NotSaturday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = false;
                result.Sunday = true;
            }
            else if (operatingProfile.RegularDayType.DaysOfWeek.NotSunday == string.Empty)
            {
                result.Monday = true;
                result.Tuesday = true;
                result.Wednesday = true;
                result.Thursday = true;
                result.Friday = true;
                result.Saturday = true;
                result.Sunday = false;
            }
            else
            {
                if (operatingProfile.RegularDayType.DaysOfWeek.Monday == string.Empty) { result.Monday = true; }
                if (operatingProfile.RegularDayType.DaysOfWeek.Tuesday == string.Empty) { result.Tuesday = true; }
                if (operatingProfile.RegularDayType.DaysOfWeek.Wednesday == string.Empty) { result.Wednesday = true; }
                if (operatingProfile.RegularDayType.DaysOfWeek.Thursday == string.Empty) { result.Thursday = true; }
                if (operatingProfile.RegularDayType.DaysOfWeek.Friday == string.Empty) { result.Friday = true; }
                if (operatingProfile.RegularDayType.DaysOfWeek.Saturday == string.Empty) { result.Saturday = true; }
                if (operatingProfile.RegularDayType.DaysOfWeek.Sunday == string.Empty) { result.Sunday = true; }
            }
        }

        while (startDate <= endDate)
        {
            switch (startDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                {
                    if (result.Monday.HasValue && result.Monday.Value)
                    {
                        result.RunningDates.Add(startDate);
                    }

                    break;
                }
                case DayOfWeek.Tuesday:
                {
                    if (result.Tuesday.HasValue && result.Tuesday.Value)
                    {
                        result.RunningDates.Add(startDate);
                    }

                    break;
                }
                case DayOfWeek.Wednesday:
                {
                    if (result.Wednesday.HasValue && result.Wednesday.Value)
                    {
                        result.RunningDates.Add(startDate);
                    }

                    break;
                }
                case DayOfWeek.Thursday:
                {
                    if (result.Thursday.HasValue && result.Thursday.Value)
                    {
                        result.RunningDates.Add(startDate);
                    }

                    break;
                }
                case DayOfWeek.Friday:
                {
                    if (result.Friday.HasValue && result.Friday.Value)
                    {
                        result.RunningDates.Add(startDate);
                    }

                    break;
                }
                case DayOfWeek.Saturday:
                {
                    if (result.Saturday.HasValue && result.Saturday.Value)
                    {
                        result.RunningDates.Add(startDate);
                    }

                    break;
                }
                case DayOfWeek.Sunday:
                {
                    if (result.Sunday.HasValue && result.Sunday.Value)
                    {
                        result.RunningDates.Add(startDate);
                    }

                    break;
                }
                default:
                {
                    if (result.Monday.HasValue && result.Monday.Value) { result.RunningDates.Add(startDate); }
                    if (result.Tuesday.HasValue && result.Tuesday.Value) { result.RunningDates.Add(startDate); }
                    if (result.Wednesday.HasValue && result.Wednesday.Value) { result.RunningDates.Add(startDate); }
                    if (result.Thursday.HasValue && result.Thursday.Value) { result.RunningDates.Add(startDate); }
                    if (result.Friday.HasValue && result.Friday.Value) { result.RunningDates.Add(startDate); }
                    if (result.Saturday.HasValue && result.Saturday.Value) { result.RunningDates.Add(startDate); }
                    if (result.Sunday.HasValue && result.Sunday.Value) { result.RunningDates.Add(startDate); }

                    break;
                }
            }

            startDate = startDate.AddDays(1);
        }

        return result;
    }
}