using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Helpers;
using TramTimes.Utilities.TransXChange.Models;
using TramTimes.Utilities.TransXChange.Tools;

namespace TramTimes.Utilities.TransXChange;

public abstract class TransXChange
{
    public static Dictionary<string, TransXChangeSchedule> Build(string path, Dictionary<string, NaptanStop> stops, string subdivision, string mode, IList<string> filters, int days, string date, string key)
    {
        DateTime? today = DateTime.Today;

        return path.EndsWith(".zip")
            ? ReturnSchedulesFromArchive(path, stops, subdivision, mode, filters, days,
                DateTimeTools.GetScheduleDate(today.ToZonedDate("Europe/London").Date, date), key)
            : ReturnSchedulesFromDirectory(path, stops, subdivision, mode, filters, days,
                DateTimeTools.GetScheduleDate(today.ToZonedDate("Europe/London").Date, date), key);
    }

    private static Dictionary<string, TransXChangeSchedule> ReturnSchedulesFromArchive(string path, Dictionary<string, NaptanStop> stops, string subdivision, string mode, IList<string> filters, int days, DateTime scheduleDate, string key)
    {
        Dictionary<string, TransXChangeSchedule> results = [];
        using var archive = ZipFile.Open(path, ZipArchiveMode.Read);

        foreach (var entry in archive.Entries)
        {
            if (!entry.Name.EndsWith(".xml")) continue;
                
            using StreamReader reader = new(entry.Open());

            if (new XmlSerializer(typeof(Models.TransXChange)).Deserialize(reader) is not Models.TransXChange xml)
            {
                continue;
            }

            if (xml.VehicleJourneys?.VehicleJourney == null) continue;
                
            foreach (var vehicleJourney in xml.VehicleJourneys.VehicleJourney)
            {
                DateTime? startDate = null;

                if (!string.IsNullOrEmpty(xml.Services?.Service?.OperatingPeriod?.StartDate))
                {
                    startDate = DateTimeTools.GetStartDate(
                        xml.Services.Service.OperatingPeriod.StartDate.ToDate(),
                        scheduleDate,
                        days);
                }

                DateTime? endDate = null;

                if (!string.IsNullOrEmpty(xml.Services?.Service?.OperatingPeriod?.EndDate))
                {
                    endDate = DateTimeTools.GetEndDate(
                        xml.Services.Service.OperatingPeriod.EndDate.ToDate(),
                        scheduleDate,
                        days);
                }

                if (!startDate.HasValue || !endDate.HasValue)
                {
                    continue;
                }

                if (startDate.Value > endDate.Value || endDate.Value < startDate.Value)
                {
                    continue;
                }

                var journeyPatternReference = vehicleJourney.JourneyPatternRef ?? string.Empty;

                if (string.IsNullOrEmpty(journeyPatternReference))
                {
                    continue;
                }

                var journeyPattern = xml.Services?.Service?.StandardService?.JourneyPattern?.FirstOrDefault(p => p.Id == journeyPatternReference);
                journeyPattern ??= xml.Services?.Service?.StandardService?.JourneyPattern?.FirstOrDefault();

                if (journeyPattern == null)
                {
                    continue;
                }

                var operatingProfile = vehicleJourney.OperatingProfile;
                operatingProfile ??= xml.Services?.Service?.OperatingProfile;

                if (operatingProfile == null)
                {
                    continue;
                }

                var calendar = TransXChangeCalendarHelpers.Build(operatingProfile, startDate.Value, endDate.Value);

                if (operatingProfile.BankHolidayOperation != null)
                {
                    if (operatingProfile.BankHolidayOperation.DaysOfOperation != null)
                    {
                        var holidays = TransXChangeDaysOfOperationHelpers.Build(
                            operatingProfile.BankHolidayOperation.DaysOfOperation, calendar, key, subdivision);

                        foreach (var holidayDate in holidays.Select(holiday => DateTimeTools.GetHolidayDate(holiday.Date, scheduleDate, days)))
                        {
                            if (calendar is not { RunningDates: not null, SupplementRunningDates: not null }) continue;
                                
                            if (!calendar.RunningDates.Contains(holidayDate))
                            {
                                calendar.SupplementRunningDates.Add(holidayDate);
                            }
                        }
                    }

                    if (operatingProfile.BankHolidayOperation.DaysOfNonOperation != null)
                    {
                        var holidays = TransXChangeDaysOfNonOperationHelpers.Build(
                            operatingProfile.BankHolidayOperation.DaysOfNonOperation, calendar, key, subdivision);

                        foreach (var holidayDate in holidays.Select(holiday => DateTimeTools.GetHolidayDate(holiday.Date, scheduleDate, days)))
                        {
                            if (calendar is not { RunningDates: not null, SupplementNonRunningDates: not null }) continue;
                                
                            if (calendar.RunningDates.Contains(holidayDate))
                            {
                                calendar.SupplementNonRunningDates.Add(holidayDate);
                            }
                        }
                    }
                }

                if (operatingProfile.SpecialDaysOperation != null)
                {
                    if (operatingProfile.SpecialDaysOperation.DaysOfOperation?.DateRange != null)
                    {
                        startDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.StartDate))
                        {
                            startDate = DateTimeTools.GetStartDate(
                                operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.StartDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        endDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.EndDate))
                        {
                            endDate = DateTimeTools.GetEndDate(
                                operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.EndDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        if (startDate.HasValue && endDate.HasValue && calendar is { RunningDates: not null, SupplementRunningDates: not null })
                        {
                            while (startDate.Value <= endDate.Value)
                            {
                                if (!calendar.RunningDates.Contains(startDate.Value))
                                {
                                    calendar.SupplementRunningDates.Add(startDate.Value);
                                }

                                startDate = startDate.Value.AddDays(1);
                            }
                        }
                    }

                    if (operatingProfile.SpecialDaysOperation.DaysOfNonOperation?.DateRange != null)
                    {
                        startDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.StartDate))
                        {
                            startDate = DateTimeTools.GetStartDate(
                                operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.StartDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        endDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.EndDate))
                        {
                            endDate = DateTimeTools.GetEndDate(
                                operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.EndDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        if (startDate.HasValue && endDate.HasValue && calendar is { RunningDates: not null, SupplementNonRunningDates: not null })
                        {
                            while (startDate.Value <= endDate.Value)
                            {
                                if (calendar.RunningDates.Contains(startDate.Value))
                                {
                                    calendar.SupplementNonRunningDates.Add(startDate.Value);
                                }

                                startDate = startDate.Value.AddDays(1);
                            }
                        }
                    }
                }

                if (calendar.RunningDates != null)
                {
                    calendar.RunningDates = [.. calendar.RunningDates.Distinct().OrderBy(d => d)];
                }

                if (calendar.SupplementRunningDates != null)
                {
                    calendar.SupplementRunningDates = [.. calendar.SupplementRunningDates.Distinct().OrderBy(d => d)];
                }

                if (calendar.SupplementNonRunningDates != null)
                {
                    calendar.SupplementNonRunningDates = [.. calendar.SupplementNonRunningDates.Distinct().OrderBy(d => d)];
                }
                    
                TransXChangeSchedule? schedule = null;

                if (xml.Operators?.Operator != null && xml.Services?.Service != null)
                {
                    schedule = TransXChangeScheduleHelpers.Build(xml.Operators.Operator, xml.Services.Service, journeyPattern, calendar);
                }

                if (schedule == null)
                {
                    continue;
                }

                var departureTime = vehicleJourney.DepartureTime?.ToTime();
                var stopPoints = xml.StopPoints?.AnnotatedStopPointRef ?? [];

                var patternSection = xml.JourneyPatternSections?.JourneyPatternSection?.FirstOrDefault(s => s.Id == journeyPattern.JourneyPatternSectionRefs);
                var patternTimings = patternSection?.JourneyPatternTimingLink;

                for (var i = 0; i < patternTimings?.Count; i++)
                {
                    var runTime = TimeSpan.Zero;

                    if (!string.IsNullOrEmpty(patternTimings.ElementAtOrDefault(i - 1)?.RunTime))
                    {
                        if (XmlConvert.ToTimeSpan(patternTimings[i - 1].RunTime ?? string.Empty) > TimeSpan.Zero)
                        {
                            runTime = runTime.Add(XmlConvert.ToTimeSpan(patternTimings[i - 1].RunTime ?? string.Empty));
                        }
                    }

                    var waitTime = TimeSpan.Zero;

                    if (patternTimings.ElementAtOrDefault(i - 1)?.To != null)
                    {
                        if (!string.IsNullOrEmpty(patternTimings[i - 1].To?.WaitTime))
                        {
                            if (XmlConvert.ToTimeSpan(patternTimings[i - 1].To?.WaitTime ?? string.Empty) > TimeSpan.Zero)
                            {
                                waitTime = waitTime.Add(XmlConvert.ToTimeSpan(patternTimings[i - 1].To?.WaitTime ?? string.Empty));
                            }
                        }
                    }

                    if (patternTimings.ElementAtOrDefault(i)?.From != null)
                    {
                        if (!string.IsNullOrEmpty(patternTimings[i].From?.WaitTime))
                        {
                            if (XmlConvert.ToTimeSpan(patternTimings[i].From?.WaitTime ?? string.Empty) > TimeSpan.Zero)
                            {
                                waitTime = waitTime.Add(XmlConvert.ToTimeSpan(patternTimings[i].From?.WaitTime ?? string.Empty));
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(patternTimings.ElementAtOrDefault(i - 1)?.RunTime))
                    {
                        if (XmlConvert.ToTimeSpan(patternTimings[i - 1].RunTime ?? string.Empty) == TimeSpan.Zero && waitTime == TimeSpan.Zero)
                        {
                            runTime = runTime.Add(TimeSpan.FromSeconds(30));
                        }
                    }

                    var arrivalTime = departureTime?.Add(runTime);
                    departureTime = arrivalTime?.Add(waitTime);
                        
                    switch (i)
                    {
                        case 0:
                        {
                            var originPoint = TransXChangeStopPointHelpers.Build(stops,
                                stopPoints.FirstOrDefault(s =>
                                    s.StopPointRef == patternTimings[i].From?.StopPointRef) ??
                                new TransXChangeAnnotatedStopPointRef
                                    { StopPointRef = patternTimings[i].From?.StopPointRef });
                            
                            originPoint.Activity = patternTimings[i].From?.Activity ?? "pickUp";
                            originPoint.ArrivalTime = arrivalTime ?? TimeSpan.Zero;
                            originPoint.DepartureTime = departureTime ?? TimeSpan.Zero;

                            schedule.StopPoints?.Add(originPoint);
                            
                            break;
                        }
                        case > 0:
                        {
                            var callingPoint = TransXChangeStopPointHelpers.Build(stops,
                                stopPoints.FirstOrDefault(s =>
                                    s.StopPointRef == patternTimings[i].From?.StopPointRef) ??
                                new TransXChangeAnnotatedStopPointRef
                                    { StopPointRef = patternTimings[i].From?.StopPointRef });
                            
                            callingPoint.Activity = patternTimings[i].From?.Activity ?? "pickUpAndSetDown";
                            callingPoint.ArrivalTime = arrivalTime ?? TimeSpan.Zero;
                            callingPoint.DepartureTime = departureTime ?? TimeSpan.Zero;

                            schedule.StopPoints?.Add(callingPoint);
                            
                            break;
                        }
                    }

                    if (i != patternTimings.Count - 1) continue;

                    var destinationPoint = TransXChangeStopPointHelpers.Build(stops,
                        stopPoints.FirstOrDefault(s =>
                            s.StopPointRef == patternTimings[i].To?.StopPointRef) ??
                        new TransXChangeAnnotatedStopPointRef
                            { StopPointRef = patternTimings[i].To?.StopPointRef });
                    
                    destinationPoint.Activity = patternTimings[i].To?.Activity ?? "setDown";
                    destinationPoint.ArrivalTime = arrivalTime ?? TimeSpan.Zero;
                    destinationPoint.DepartureTime = departureTime ?? TimeSpan.Zero;

                    schedule.StopPoints?.Add(destinationPoint);
                }
                
                if (schedule.StopPoints != null && TransXChangeScheduleHelpers.ReturnSupplementNonRunningDateMatch(results, schedule))
                {
                    continue;
                }
                
                if (schedule.StopPoints != null && TransXChangeScheduleHelpers.ReturnSupplementRunningDateMatch(results, schedule))
                {
                    continue;
                }
                    
                if (schedule.StopPoints != null && TransXChangeScheduleHelpers.ReturnRunningDateMatch(results, schedule))
                {
                    continue;
                }
                    
                if (schedule.StopPoints != null && !TransXChangeStopPointHelpers.ReturnModeMatch(mode, schedule))
                {
                    continue;
                }

                if (schedule.StopPoints != null && !TransXChangeStopPointHelpers.ReturnFilterMatch(filters, schedule))
                {
                    continue;
                }
                                
                if (!string.IsNullOrEmpty(schedule.Id))
                {
                    _ = results.TryAdd(schedule.Id, schedule);
                }
            }
        }

        return results;
    }
    
    private static Dictionary<string, TransXChangeSchedule> ReturnSchedulesFromDirectory(string path, Dictionary<string, NaptanStop> stops, string subdivision, string mode, IList<string> filters, int days, DateTime scheduleDate, string key)
    {
        Dictionary<string, TransXChangeSchedule> results = [];
        var entries = Directory.GetFiles(path);

        foreach (var entry in entries)
        {
            if (!entry.EndsWith(".xml")) continue;
                
            using StreamReader reader = new(entry);

            if (new XmlSerializer(typeof(Models.TransXChange)).Deserialize(reader) is not Models.TransXChange xml)
            {
                continue;
            }

            if (xml.VehicleJourneys?.VehicleJourney == null) continue;
                
            foreach (var vehicleJourney in xml.VehicleJourneys.VehicleJourney)
            {
                DateTime? startDate = null;

                if (!string.IsNullOrEmpty(xml.Services?.Service?.OperatingPeriod?.StartDate))
                {
                    startDate = DateTimeTools.GetStartDate(
                        xml.Services.Service.OperatingPeriod.StartDate.ToDate(),
                        scheduleDate,
                        days);
                }

                DateTime? endDate = null;

                if (!string.IsNullOrEmpty(xml.Services?.Service?.OperatingPeriod?.EndDate))
                {
                    endDate = DateTimeTools.GetEndDate(
                        xml.Services.Service.OperatingPeriod.EndDate.ToDate(),
                        scheduleDate,
                        days);
                }

                if (!startDate.HasValue || !endDate.HasValue)
                {
                    continue;
                }

                if (startDate.Value > endDate.Value || endDate.Value < startDate.Value)
                {
                    continue;
                }

                var journeyPatternReference = vehicleJourney.JourneyPatternRef ?? string.Empty;

                if (string.IsNullOrEmpty(journeyPatternReference))
                {
                    continue;
                }

                var journeyPattern = xml.Services?.Service?.StandardService?.JourneyPattern?.FirstOrDefault(p => p.Id == journeyPatternReference);
                journeyPattern ??= xml.Services?.Service?.StandardService?.JourneyPattern?.FirstOrDefault();

                if (journeyPattern == null)
                {
                    continue;
                }

                var operatingProfile = vehicleJourney.OperatingProfile;
                operatingProfile ??= xml.Services?.Service?.OperatingProfile;

                if (operatingProfile == null)
                {
                    continue;
                }

                var calendar = TransXChangeCalendarHelpers.Build(operatingProfile, startDate.Value, endDate.Value);

                if (operatingProfile.BankHolidayOperation != null)
                {
                    if (operatingProfile.BankHolidayOperation.DaysOfOperation != null)
                    {
                        var holidays = TransXChangeDaysOfOperationHelpers.Build(
                            operatingProfile.BankHolidayOperation.DaysOfOperation, calendar, key, subdivision);

                        foreach (var holidayDate in holidays.Select(holiday => DateTimeTools.GetHolidayDate(holiday.Date, scheduleDate, days)))
                        {
                            if (calendar is not { RunningDates: not null, SupplementRunningDates: not null }) continue;
                                
                            if (!calendar.RunningDates.Contains(holidayDate))
                            {
                                calendar.SupplementRunningDates.Add(holidayDate);
                            }
                        }
                    }

                    if (operatingProfile.BankHolidayOperation.DaysOfNonOperation != null)
                    {
                        var holidays = TransXChangeDaysOfNonOperationHelpers.Build(
                            operatingProfile.BankHolidayOperation.DaysOfNonOperation, calendar, key, subdivision);

                        foreach (var holidayDate in holidays.Select(holiday => DateTimeTools.GetHolidayDate(holiday.Date, scheduleDate, days)))
                        {
                            if (calendar is not { RunningDates: not null, SupplementNonRunningDates: not null }) continue;
                                
                            if (calendar.RunningDates.Contains(holidayDate))
                            {
                                calendar.SupplementNonRunningDates.Add(holidayDate);
                            }
                        }
                    }
                }

                if (operatingProfile.SpecialDaysOperation != null)
                {
                    if (operatingProfile.SpecialDaysOperation.DaysOfOperation?.DateRange != null)
                    {
                        startDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.StartDate))
                        {
                            startDate = DateTimeTools.GetStartDate(
                                operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.StartDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        endDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.EndDate))
                        {
                            endDate = DateTimeTools.GetEndDate(
                                operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.EndDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        if (startDate.HasValue && endDate.HasValue && calendar is { RunningDates: not null, SupplementRunningDates: not null })
                        {
                            while (startDate.Value <= endDate.Value)
                            {
                                if (!calendar.RunningDates.Contains(startDate.Value))
                                {
                                    calendar.SupplementRunningDates.Add(startDate.Value);
                                }

                                startDate = startDate.Value.AddDays(1);
                            }
                        }
                    }

                    if (operatingProfile.SpecialDaysOperation.DaysOfNonOperation?.DateRange != null)
                    {
                        startDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.StartDate))
                        {
                            startDate = DateTimeTools.GetStartDate(
                                operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.StartDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        endDate = null;

                        if (!string.IsNullOrEmpty(operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.EndDate))
                        {
                            endDate = DateTimeTools.GetEndDate(
                                operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.EndDate.ToDate(),
                                scheduleDate,
                                days);
                        }

                        if (startDate.HasValue && endDate.HasValue && calendar is { RunningDates: not null, SupplementNonRunningDates: not null })
                        {
                            while (startDate.Value <= endDate.Value)
                            {
                                if (calendar.RunningDates.Contains(startDate.Value))
                                {
                                    calendar.SupplementNonRunningDates.Add(startDate.Value);
                                }

                                startDate = startDate.Value.AddDays(1);
                            }
                        }
                    }
                }

                if (calendar.RunningDates != null)
                {
                    calendar.RunningDates = [.. calendar.RunningDates.Distinct().OrderBy(d => d)];
                }

                if (calendar.SupplementRunningDates != null)
                {
                    calendar.SupplementRunningDates = [.. calendar.SupplementRunningDates.Distinct().OrderBy(d => d)];
                }

                if (calendar.SupplementNonRunningDates != null)
                {
                    calendar.SupplementNonRunningDates = [.. calendar.SupplementNonRunningDates.Distinct().OrderBy(d => d)];
                }
                    
                TransXChangeSchedule? schedule = null;

                if (xml.Operators?.Operator != null && xml.Services?.Service != null)
                {
                    schedule = TransXChangeScheduleHelpers.Build(xml.Operators.Operator, xml.Services.Service, journeyPattern, calendar);
                }

                if (schedule == null)
                {
                    continue;
                }

                var departureTime = vehicleJourney.DepartureTime?.ToTime();
                var stopPoints = xml.StopPoints?.AnnotatedStopPointRef ?? [];

                var patternSection = xml.JourneyPatternSections?.JourneyPatternSection?.FirstOrDefault(s => s.Id == journeyPattern.JourneyPatternSectionRefs);
                var patternTimings = patternSection?.JourneyPatternTimingLink;

                for (var i = 0; i < patternTimings?.Count; i++)
                {
                    var runTime = TimeSpan.Zero;

                    if (!string.IsNullOrEmpty(patternTimings.ElementAtOrDefault(i - 1)?.RunTime))
                    {
                        if (XmlConvert.ToTimeSpan(patternTimings[i - 1].RunTime ?? string.Empty) > TimeSpan.Zero)
                        {
                            runTime = runTime.Add(XmlConvert.ToTimeSpan(patternTimings[i - 1].RunTime ?? string.Empty));
                        }
                    }

                    var waitTime = TimeSpan.Zero;

                    if (patternTimings.ElementAtOrDefault(i - 1)?.To != null)
                    {
                        if (!string.IsNullOrEmpty(patternTimings[i - 1].To?.WaitTime))
                        {
                            if (XmlConvert.ToTimeSpan(patternTimings[i - 1].To?.WaitTime ?? string.Empty) > TimeSpan.Zero)
                            {
                                waitTime = waitTime.Add(XmlConvert.ToTimeSpan(patternTimings[i - 1].To?.WaitTime ?? string.Empty));
                            }
                        }
                    }

                    if (patternTimings.ElementAtOrDefault(i)?.From != null)
                    {
                        if (!string.IsNullOrEmpty(patternTimings[i].From?.WaitTime))
                        {
                            if (XmlConvert.ToTimeSpan(patternTimings[i].From?.WaitTime ?? string.Empty) > TimeSpan.Zero)
                            {
                                waitTime = waitTime.Add(XmlConvert.ToTimeSpan(patternTimings[i].From?.WaitTime ?? string.Empty));
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(patternTimings.ElementAtOrDefault(i - 1)?.RunTime))
                    {
                        if (XmlConvert.ToTimeSpan(patternTimings[i - 1].RunTime ?? string.Empty) == TimeSpan.Zero && waitTime == TimeSpan.Zero)
                        {
                            runTime = runTime.Add(TimeSpan.FromSeconds(30));
                        }
                    }

                    var arrivalTime = departureTime?.Add(runTime);
                    departureTime = arrivalTime?.Add(waitTime);
                        
                    switch (i)
                    {
                        case 0:
                        {
                            var originPoint = TransXChangeStopPointHelpers.Build(stops,
                                stopPoints.FirstOrDefault(s =>
                                    s.StopPointRef == patternTimings[i].From?.StopPointRef) ??
                                new TransXChangeAnnotatedStopPointRef
                                    { StopPointRef = patternTimings[i].From?.StopPointRef });
                            
                            originPoint.Activity = patternTimings[i].From?.Activity ?? "pickUp";
                            originPoint.ArrivalTime = arrivalTime ?? TimeSpan.Zero;
                            originPoint.DepartureTime = departureTime ?? TimeSpan.Zero;

                            schedule.StopPoints?.Add(originPoint);
                            
                            break;
                        }
                        case > 0:
                        {
                            var callingPoint = TransXChangeStopPointHelpers.Build(stops,
                                stopPoints.FirstOrDefault(s =>
                                    s.StopPointRef == patternTimings[i].From?.StopPointRef) ??
                                new TransXChangeAnnotatedStopPointRef
                                    { StopPointRef = patternTimings[i].From?.StopPointRef });
                            
                            callingPoint.Activity = patternTimings[i].From?.Activity ?? "pickUpAndSetDown";
                            callingPoint.ArrivalTime = arrivalTime ?? TimeSpan.Zero;
                            callingPoint.DepartureTime = departureTime ?? TimeSpan.Zero;

                            schedule.StopPoints?.Add(callingPoint);
                            
                            break;
                        }
                    }

                    if (i != patternTimings.Count - 1) continue;

                    var destinationPoint = TransXChangeStopPointHelpers.Build(stops,
                        stopPoints.FirstOrDefault(s =>
                            s.StopPointRef == patternTimings[i].To?.StopPointRef) ??
                        new TransXChangeAnnotatedStopPointRef
                            { StopPointRef = patternTimings[i].To?.StopPointRef });
                    
                    destinationPoint.Activity = patternTimings[i].To?.Activity ?? "setDown";
                    destinationPoint.ArrivalTime = arrivalTime ?? TimeSpan.Zero;
                    destinationPoint.DepartureTime = departureTime ?? TimeSpan.Zero;

                    schedule.StopPoints?.Add(destinationPoint);
                }
                
                if (schedule.StopPoints != null && TransXChangeScheduleHelpers.ReturnSupplementNonRunningDateMatch(results, schedule))
                {
                    continue;
                }
                
                if (schedule.StopPoints != null && TransXChangeScheduleHelpers.ReturnSupplementRunningDateMatch(results, schedule))
                {
                    continue;
                }
                    
                if (schedule.StopPoints != null && TransXChangeScheduleHelpers.ReturnRunningDateMatch(results, schedule))
                {
                    continue;
                }
                    
                if (schedule.StopPoints != null && !TransXChangeStopPointHelpers.ReturnModeMatch(mode, schedule))
                {
                    continue;
                }

                if (schedule.StopPoints != null && !TransXChangeStopPointHelpers.ReturnFilterMatch(filters, schedule))
                {
                    continue;
                }
                                
                if (!string.IsNullOrEmpty(schedule.Id))
                {
                    _ = results.TryAdd(schedule.Id, schedule);
                }
            }
        }

        return results;
    }
}