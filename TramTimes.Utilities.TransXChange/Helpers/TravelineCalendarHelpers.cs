using TramTimes.Utilities.TransXChange.Models;
using TramTimes.Utilities.TransXChange.Tools;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TravelineCalendarHelpers
{
    public static TravelineCalendar Build(string subdivision, DateTime scheduleDate, TransXChangeServices? services, TransXChangeVehicleJourney? vehicleJourney, DateTime? startDate, DateTime? endDate)
    {
        var operatingProfile = vehicleJourney?.OperatingProfile ?? services?.Service?.OperatingProfile;
        
        TravelineCalendar value = new()
        {
            Monday = false,
            Tuesday = false,
            Wednesday = false,
            Thursday = false,
            Friday = false,
            Saturday = false,
            Sunday = false,
        };
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.MondayToFriday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.MondayToSaturday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.MondayToSunday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Weekend != null)
        {
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotMonday != null)
        {
            value.Tuesday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotTuesday != null)
        {
            value.Monday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotTuesday != null)
        {
            value.Monday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotWednesday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotWednesday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotWednesday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotWednesday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotThursday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Wednesday = true;
            value.Friday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotFriday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Saturday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotSaturday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Sunday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.NotSunday != null)
        {
            value.Monday = true;
            value.Tuesday = true;
            value.Wednesday = true;
            value.Thursday = true;
            value.Friday = true;
            value.Saturday = true;
        }
        
        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Monday != null)
        {
            value.Monday = true;
        }

        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Tuesday != null)
        {
            value.Tuesday = true;
        }

        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Wednesday != null)
        {
            value.Wednesday = true;
        }

        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Thursday != null)
        {
            value.Thursday = true;
        }

        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Friday != null)
        {
            value.Friday = true;
        }

        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Saturday != null)
        {
            value.Saturday = true;
        }

        if (operatingProfile?.RegularDayType?.DaysOfWeek?.Sunday != null)
        {
            value.Sunday = true;
        }

        value.StartDate = startDate;
        value.EndDate = endDate;
        
        value.RunningDates = TravelineRunningDateTools.GetAllDates(value.StartDate, value.EndDate, value.Monday, value.Tuesday,
            value.Wednesday, value.Thursday, value.Friday, value.Saturday, value.Sunday);
        
        value.SupplementRunningDates = subdivision == "GB-ENG"
            ? TravelineSupplementRunningDateTools.GetEnglandDates(scheduleDate, operatingProfile, value.StartDate, value.EndDate,
                value.Monday, value.Tuesday, value.Wednesday, value.Thursday, value.Friday, value.Saturday, value.Sunday, value.RunningDates)
            : TravelineSupplementRunningDateTools.GetScotlandDates(scheduleDate, operatingProfile, value.StartDate, value.EndDate,
                value.Monday, value.Tuesday, value.Wednesday, value.Thursday, value.Friday, value.Saturday, value.Sunday, value.RunningDates);
        
        value.SupplementNonRunningDates = subdivision == "GB-ENG"
            ? TravelineSupplementNonRunningDateTools.GetEnglandDates(scheduleDate, operatingProfile, value.StartDate, value.EndDate,
                value.Monday, value.Tuesday, value.Wednesday, value.Thursday, value.Friday, value.Saturday, value.Sunday, value.RunningDates)
            : TravelineSupplementNonRunningDateTools.GetScotlandDates(scheduleDate, operatingProfile, value.StartDate, value.EndDate,
                value.Monday, value.Tuesday, value.Wednesday, value.Thursday, value.Friday, value.Saturday, value.Sunday, value.RunningDates);

        return value;
    }
}