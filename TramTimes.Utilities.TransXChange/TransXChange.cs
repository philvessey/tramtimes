using System.Globalization;
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
    public static Dictionary<string, TravelineSchedule> Build(string path, Dictionary<string, NaptanLocality> localities, Dictionary<string, NaptanStop> stops, string subdivision, string date, string? key)
    {
        return path.EndsWith(".zip")
            ? ReturnSchedulesFromArchive(path, localities, stops, subdivision, DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture).Date, key ?? string.Empty)
            : ReturnSchedulesFromDirectory(path, localities, stops, subdivision, DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture).Date, key ?? string.Empty);
    }

    private static Dictionary<string, TravelineSchedule> ReturnSchedulesFromArchive(string path, Dictionary<string, NaptanLocality> localities, Dictionary<string, NaptanStop> stops, string subdivision, DateTime date, string? key)
    {
        Dictionary<string, TravelineSchedule> results = [];
        using var archive = ZipFile.Open(path, ZipArchiveMode.Read);

        foreach (var entry in archive.Entries)
        {
            if (!entry.Name.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase)) continue;
                
            using StreamReader reader = new(entry.Open());

            if (new XmlSerializer(typeof(Models.TransXChange)).Deserialize(reader) is not Models.TransXChange xml)
            {
                continue;
            }

            if (xml.VehicleJourneys?.VehicleJourney == null) continue;
                
            foreach (var vehicleJourney in xml.VehicleJourneys.VehicleJourney)
            {
                var startDate = DateTimeTools.GetStartDate(
                    xml.Services?.Service?.OperatingPeriod?.StartDate.ToDate(),
                    date);

                var endDate = DateTimeTools.GetEndDate(
                    xml.Services?.Service?.OperatingPeriod?.EndDate.ToDate(),
                    date);

                if (startDate > endDate)
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

                var calendar = TravelineCalendarHelpers.Build(operatingProfile, startDate, endDate);

                if (operatingProfile.BankHolidayOperation != null)
                {
                    if (operatingProfile.BankHolidayOperation.DaysOfOperation != null)
                    {
                        var holidays = TransXChangeDaysOfOperationHelpers.Build(
                            operatingProfile.BankHolidayOperation.DaysOfOperation, calendar, subdivision, key);

                        foreach (var holidayDate in holidays.Where(h => h.Date >= startDate && h.Date <= endDate).Select(h => h.Date))
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
                            operatingProfile.BankHolidayOperation.DaysOfNonOperation, calendar, subdivision, key);

                        foreach (var holidayDate in holidays.Where(h => h.Date >= startDate && h.Date <= endDate).Select(h => h.Date))
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
                        startDate = DateTimeTools.GetStartDate(
                            operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.StartDate.ToDate(),
                            date);

                        endDate = DateTimeTools.GetEndDate(
                            operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.EndDate.ToDate(),
                            date);

                        while (startDate <= endDate)
                        {
                            if (calendar is { RunningDates: not null, SupplementRunningDates: not null })
                            {
                                if (!calendar.RunningDates.Contains(startDate))
                                {
                                    calendar.SupplementRunningDates.Add(startDate);
                                }
                            }

                            startDate = startDate.AddDays(1);
                        }
                    }

                    if (operatingProfile.SpecialDaysOperation.DaysOfNonOperation?.DateRange != null)
                    {
                        startDate = DateTimeTools.GetStartDate(
                            operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.StartDate.ToDate(),
                            date);

                        endDate = DateTimeTools.GetEndDate(
                            operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.EndDate.ToDate(),
                            date);

                        while (startDate <= endDate)
                        {
                            if (calendar is { RunningDates: not null, SupplementNonRunningDates: not null })
                            {
                                if (calendar.RunningDates.Contains(startDate))
                                {
                                    calendar.SupplementNonRunningDates.Add(startDate);
                                }
                            }

                            startDate = startDate.AddDays(1);
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
                    
                TravelineSchedule? schedule = null;

                if (xml.Operators?.Operator != null && xml.Services?.Service != null)
                {
                    schedule = TravelineScheduleHelpers.Build(xml.Operators.Operator, xml.Services.Service, journeyPattern, calendar);
                }

                if (schedule == null)
                {
                    continue;
                }

                var departureTime = vehicleJourney.DepartureTime?.ToTime();

                var patternSection = xml.JourneyPatternSections?.JourneyPatternSection?.FirstOrDefault(s => s.Id != null && journeyPattern.JourneyPatternSectionRefs?.Contains(s.Id) == true);
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

                    var arrivalTime = departureTime?.Add(runTime);
                    departureTime = arrivalTime?.Add(waitTime);
                    
                    if (schedule.StopPoints?.Count > 0) schedule.StopPoints?.RemoveAt(schedule.StopPoints.Count - 1);
                    
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, patternTimings[i].From?.StopPointRef, i > 0 ? "pickUpAndSetDown" : "pickUp", arrivalTime, departureTime));
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, patternTimings[i].To?.StopPointRef, i < patternTimings.Count - 1 ? "pickUpAndSetDown" : "setDown", arrivalTime, departureTime));
                }
                
                if (TravelineScheduleHelpers.ReturnSupplementNonRunningDateMatch(results, schedule)) continue;
                if (TravelineScheduleHelpers.ReturnSupplementRunningDateMatch(results, schedule)) continue;
                if (TravelineScheduleHelpers.ReturnRunningDateMatch(results, schedule)) continue;
                                
                if (!string.IsNullOrEmpty(schedule.Id))
                {
                    _ = results.TryAdd(schedule.Id, schedule);
                }
            }
        }

        return results;
    }
    
    private static Dictionary<string, TravelineSchedule> ReturnSchedulesFromDirectory(string path, Dictionary<string, NaptanLocality> localities, Dictionary<string, NaptanStop> stops, string subdivision, DateTime date, string? key)
    {
        Dictionary<string, TravelineSchedule> results = [];
        var entries = Directory.GetFiles(path);

        foreach (var entry in entries)
        {
            if (!entry.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase)) continue;
                
            using StreamReader reader = new(entry);

            if (new XmlSerializer(typeof(Models.TransXChange)).Deserialize(reader) is not Models.TransXChange xml)
            {
                continue;
            }

            if (xml.VehicleJourneys?.VehicleJourney == null) continue;
                
            foreach (var vehicleJourney in xml.VehicleJourneys.VehicleJourney)
            {
                var startDate = DateTimeTools.GetStartDate(
                    xml.Services?.Service?.OperatingPeriod?.StartDate.ToDate(),
                    date);

                var endDate = DateTimeTools.GetEndDate(
                    xml.Services?.Service?.OperatingPeriod?.EndDate.ToDate(),
                    date);

                if (startDate > endDate)
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

                var calendar = TravelineCalendarHelpers.Build(operatingProfile, startDate, endDate);

                if (operatingProfile.BankHolidayOperation != null)
                {
                    if (operatingProfile.BankHolidayOperation.DaysOfOperation != null)
                    {
                        var holidays = TransXChangeDaysOfOperationHelpers.Build(
                            operatingProfile.BankHolidayOperation.DaysOfOperation, calendar, subdivision, key);

                        foreach (var holidayDate in holidays.Where(h => h.Date >= startDate && h.Date <= endDate).Select(h => h.Date))
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
                            operatingProfile.BankHolidayOperation.DaysOfNonOperation, calendar, subdivision, key);

                        foreach (var holidayDate in holidays.Where(h => h.Date >= startDate && h.Date <= endDate).Select(h => h.Date))
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
                        startDate = DateTimeTools.GetStartDate(
                            operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.StartDate.ToDate(),
                            date);

                        endDate = DateTimeTools.GetEndDate(
                            operatingProfile.SpecialDaysOperation.DaysOfOperation.DateRange.EndDate.ToDate(),
                            date);

                        while (startDate <= endDate)
                        {
                            if (calendar is { RunningDates: not null, SupplementRunningDates: not null })
                            {
                                if (!calendar.RunningDates.Contains(startDate))
                                {
                                    calendar.SupplementRunningDates.Add(startDate);
                                }
                            }

                            startDate = startDate.AddDays(1);
                        }
                    }

                    if (operatingProfile.SpecialDaysOperation.DaysOfNonOperation?.DateRange != null)
                    {
                        startDate = DateTimeTools.GetStartDate(
                            operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.StartDate.ToDate(),
                            date);

                        endDate = DateTimeTools.GetEndDate(
                            operatingProfile.SpecialDaysOperation.DaysOfNonOperation.DateRange.EndDate.ToDate(),
                            date);

                        while (startDate <= endDate)
                        {
                            if (calendar is { RunningDates: not null, SupplementNonRunningDates: not null })
                            {
                                if (calendar.RunningDates.Contains(startDate))
                                {
                                    calendar.SupplementNonRunningDates.Add(startDate);
                                }
                            }

                            startDate = startDate.AddDays(1);
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
                    
                TravelineSchedule? schedule = null;

                if (xml.Operators?.Operator != null && xml.Services?.Service != null)
                {
                    schedule = TravelineScheduleHelpers.Build(xml.Operators.Operator, xml.Services.Service, journeyPattern, calendar);
                }

                if (schedule == null)
                {
                    continue;
                }

                var departureTime = vehicleJourney.DepartureTime?.ToTime();

                var patternSection = xml.JourneyPatternSections?.JourneyPatternSection?.FirstOrDefault(s => s.Id != null && journeyPattern.JourneyPatternSectionRefs?.Contains(s.Id) == true);
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

                    var arrivalTime = departureTime?.Add(runTime);
                    departureTime = arrivalTime?.Add(waitTime);
                    
                    if (schedule.StopPoints?.Count > 0) schedule.StopPoints?.RemoveAt(schedule.StopPoints.Count - 1);
                    
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, patternTimings[i].From?.StopPointRef, i > 0 ? "pickUpAndSetDown" : "pickUp", arrivalTime, departureTime));
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, patternTimings[i].To?.StopPointRef, i < patternTimings.Count - 1 ? "pickUpAndSetDown" : "setDown", arrivalTime, departureTime));
                }
                
                if (TravelineScheduleHelpers.ReturnSupplementNonRunningDateMatch(results, schedule)) continue;
                if (TravelineScheduleHelpers.ReturnSupplementRunningDateMatch(results, schedule)) continue;
                if (TravelineScheduleHelpers.ReturnRunningDateMatch(results, schedule)) continue;
                
                if (!string.IsNullOrEmpty(schedule.Id))
                {
                    _ = results.TryAdd(schedule.Id, schedule);
                }
            }
        }

        return results;
    }
}