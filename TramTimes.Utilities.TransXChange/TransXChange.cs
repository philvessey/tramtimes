using System.Globalization;
using System.IO.Compression;
using System.Xml.Serialization;
using Nager.Date;
using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Helpers;
using TramTimes.Utilities.TransXChange.Models;
using TramTimes.Utilities.TransXChange.Tools;

namespace TramTimes.Utilities.TransXChange;

public abstract class TransXChange
{
    public static Dictionary<string, TravelineSchedule> RunArchive(string path, Dictionary<string, NaptanLocality> localities, Dictionary<string, NaptanStop> stops, string subdivision, string date, string? key)
    {
        var scheduleDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture).Date;

        if (string.IsNullOrEmpty(HolidaySystem.LicenseKey))
        {
            HolidaySystem.LicenseKey = key;
        }
        
        Dictionary<string, TravelineSchedule> results = [];
        using var archive = ZipFile.Open(path, ZipArchiveMode.Read);

        foreach (var entry in archive.Entries)
        {
            if (!entry.Name.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
            {
                continue;
            }
                
            using StreamReader reader = new(entry.Open());

            if (new XmlSerializer(typeof(Models.TransXChange)).Deserialize(reader) is not Models.TransXChange xml)
            {
                continue;
            }

            if (xml.VehicleJourneys?.VehicleJourney == null) continue;
                
            foreach (var vehicleJourney in xml.VehicleJourneys.VehicleJourney)
            {
                var startDate = DateTimeTools.GetPeriodStartDate(scheduleDate, xml.Services?.Service?.OperatingPeriod?.StartDate.ToDate());
                var endDate = DateTimeTools.GetPeriodEndDate(scheduleDate, xml.Services?.Service?.OperatingPeriod?.EndDate.ToDate());

                if (startDate > endDate)
                {
                    continue;
                }
                
                var departureTime = vehicleJourney.DepartureTime?.ToTime();
                
                if (!departureTime.HasValue)
                {
                    continue;
                }
                
                var journeyPattern = TransXChangeJourneyPatternTools.GetJourneyPattern(xml.Services, 
                    vehicleJourney.JourneyPatternRef);
                
                var timingLinks = TransXChangeJourneyPatternTools.GetTimingLinks(xml.JourneyPatternSections, 
                    journeyPattern.JourneyPatternSectionRefs);

                var calendar = TravelineCalendarHelpers.Build(subdivision, scheduleDate, xml.Services, vehicleJourney, startDate, endDate);
                var schedule = TravelineScheduleHelpers.Build(xml.Operators, xml.Services, journeyPattern, calendar);
                
                for (var i = 0; i < timingLinks.Count; i++)
                {
                    var arrivalTime = departureTime?.Add(TravelineStopPointTools.GetRunTime(i > 0 ? 
                        timingLinks[i - 1] : new TransXChangeJourneyPatternTimingLink()));
                    
                    departureTime = arrivalTime?.Add(TravelineStopPointTools.GetWaitTime(i > 0 ? 
                        timingLinks[i - 1].To : new TransXChangeTo(), timingLinks[i].From));
                    
                    if (i > 0) schedule.StopPoints?.RemoveAt(schedule.StopPoints.Count - 1);
                    
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, timingLinks[i].From?.StopPointRef, 
                        i > 0 ? "pickUpAndSetDown" : "pickUp", arrivalTime, departureTime));
                    
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, timingLinks[i].To?.StopPointRef, 
                        i < timingLinks.Count - 1 ? "pickUpAndSetDown" : "setDown", arrivalTime, departureTime));
                }
                                
                if (!TravelineScheduleTools.GetDuplicateMatch(results, schedule.StopPoints, schedule.Calendar?.RunningDates,
                        schedule.Calendar?.SupplementRunningDates, schedule.Calendar?.SupplementNonRunningDates, schedule.Direction, 
                        schedule.Line)) _ = results.TryAdd(schedule.Id ?? "unknown", schedule);
            }
        }

        return results;
    }
    
    public static Dictionary<string, TravelineSchedule> RunDirectory(string path, Dictionary<string, NaptanLocality> localities, Dictionary<string, NaptanStop> stops, string subdivision, string date, string? key)
    {
        var scheduleDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture).Date;

        if (string.IsNullOrEmpty(HolidaySystem.LicenseKey))
        {
            HolidaySystem.LicenseKey = key;
        }
        
        Dictionary<string, TravelineSchedule> results = [];
        var entries = Directory.GetFiles(path);

        foreach (var entry in entries)
        {
            if (!entry.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
            {
                continue;
            }
                
            using StreamReader reader = new(entry);

            if (new XmlSerializer(typeof(Models.TransXChange)).Deserialize(reader) is not Models.TransXChange xml)
            {
                continue;
            }

            if (xml.VehicleJourneys?.VehicleJourney == null) continue;
                
            foreach (var vehicleJourney in xml.VehicleJourneys.VehicleJourney)
            {
                var startDate = DateTimeTools.GetPeriodStartDate(scheduleDate, xml.Services?.Service?.OperatingPeriod?.StartDate.ToDate());
                var endDate = DateTimeTools.GetPeriodEndDate(scheduleDate, xml.Services?.Service?.OperatingPeriod?.EndDate.ToDate());

                if (startDate > endDate)
                {
                    continue;
                }
                
                var departureTime = vehicleJourney.DepartureTime?.ToTime();
                
                if (!departureTime.HasValue)
                {
                    continue;
                }
                
                var journeyPattern = TransXChangeJourneyPatternTools.GetJourneyPattern(xml.Services, 
                    vehicleJourney.JourneyPatternRef);
                
                var timingLinks = TransXChangeJourneyPatternTools.GetTimingLinks(xml.JourneyPatternSections, 
                    journeyPattern.JourneyPatternSectionRefs);

                var calendar = TravelineCalendarHelpers.Build(subdivision, scheduleDate, xml.Services, vehicleJourney, startDate, endDate);
                var schedule = TravelineScheduleHelpers.Build(xml.Operators, xml.Services, journeyPattern, calendar);
                
                for (var i = 0; i < timingLinks.Count; i++)
                {
                    var arrivalTime = departureTime?.Add(TravelineStopPointTools.GetRunTime(i > 0 ? 
                        timingLinks[i - 1] : new TransXChangeJourneyPatternTimingLink()));
                    
                    departureTime = arrivalTime?.Add(TravelineStopPointTools.GetWaitTime(i > 0 ? 
                        timingLinks[i - 1].To : new TransXChangeTo(), timingLinks[i].From));
                    
                    if (i > 0) schedule.StopPoints?.RemoveAt(schedule.StopPoints.Count - 1);
                    
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, timingLinks[i].From?.StopPointRef, 
                        i > 0 ? "pickUpAndSetDown" : "pickUp", arrivalTime, departureTime));
                    
                    schedule.StopPoints?.Add(TravelineStopPointHelpers.Build(localities, stops, xml.StopPoints, timingLinks[i].To?.StopPointRef, 
                        i < timingLinks.Count - 1 ? "pickUpAndSetDown" : "setDown", arrivalTime, departureTime));
                }
                                
                if (!TravelineScheduleTools.GetDuplicateMatch(results, schedule.StopPoints, schedule.Calendar?.RunningDates,
                        schedule.Calendar?.SupplementRunningDates, schedule.Calendar?.SupplementNonRunningDates, schedule.Direction, 
                        schedule.Line)) _ = results.TryAdd(schedule.Id ?? "unknown", schedule);
            }
        }

        return results;
    }
}