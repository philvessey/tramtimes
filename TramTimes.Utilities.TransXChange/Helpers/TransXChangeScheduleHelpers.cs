using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TransXChangeScheduleHelpers
{
    public static TransXChangeSchedule Build(TransXChangeOperator @operator, TransXChangeService service, TransXChangeJourneyPattern journeyPattern, TravelineCalendar calendar)
    {
        TransXChangeSchedule result = new()
        {
            Id = Guid.NewGuid().ToString(),
            ServiceCode = service.ServiceCode,
            Calendar = calendar,
            StopPoints = []
        };

        if (!string.IsNullOrEmpty(service.Description))
        {
            result.Description = service.Description.Trim();
        }

        if (!string.IsNullOrEmpty(journeyPattern.Direction))
        {
            result.Direction = journeyPattern.Direction == "inbound" ? "1" : "0";
        }
        else
        {
            result.Direction = "0";
        }

        if (service.Lines != null)
        {
            if (service.Lines.Line != null)
            {
                result.Line = service.Lines.Line.LineName ?? "Unknown Line";
            }
            else
            {
                result.Line = "Unknown Line";
            }
        }
        else
        {
            result.Line = "Unknown Line";
        }

        if (!string.IsNullOrEmpty(service.Mode))
        {
            result.Mode = service.Mode switch
            {
                "bus" or "coach" => "3",
                "ferry" => "4",
                "rail" when @operator.OperatorCode == "EAL" => "6",
                "rail" or "tram" => "0",
                "underground" => "1",
                _ => "3"
            };
        }
        else
        {
            result.Mode = "3";
        }

        if (!string.IsNullOrEmpty(@operator.NationalOperatorCode))
        {
            result.OperatorCode = @operator.NationalOperatorCode;
            result.OperatorName = @operator.TradingName ?? @operator.OperatorNameOnLicence ?? @operator.OperatorShortName;
        }
        else
        {
            result.OperatorCode = "ZZZZ";
            result.OperatorName = "Unknown NOC Operator";
        }

        return result;
    }

    public static bool ReturnRunningDateMatch(Dictionary<string, TransXChangeSchedule> schedules, TransXChangeSchedule schedule)
    {
        if (schedule.Calendar is not { RunningDates: not null }) return false;

        var runningDates = schedules.Values.Where(s =>
            s.Calendar is { RunningDates: not null } &&
            s.Calendar.RunningDates.Intersect(schedule.Calendar.RunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in runningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }
        
        var supplementRunningDates = schedules.Values.Where(s =>
            s.Calendar is { SupplementRunningDates: not null } &&
            s.Calendar.SupplementRunningDates.Intersect(schedule.Calendar.RunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in supplementRunningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }
        
        var supplementNonRunningDates = schedules.Values.Where(s =>
            s.Calendar is { SupplementNonRunningDates: not null } &&
            s.Calendar.SupplementNonRunningDates.Intersect(schedule.Calendar.RunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in supplementNonRunningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }

        return false;
    }
    
    public static bool ReturnSupplementRunningDateMatch(Dictionary<string, TransXChangeSchedule> schedules, TransXChangeSchedule schedule)
    {
        if (schedule.Calendar is not { SupplementRunningDates: not null }) return false;

        var runningDates = schedules.Values.Where(s =>
            s.Calendar is { RunningDates: not null } &&
            s.Calendar.RunningDates.Intersect(schedule.Calendar.SupplementRunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in runningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }
        
        var supplementRunningDates = schedules.Values.Where(s =>
            s.Calendar is { SupplementRunningDates: not null } &&
            s.Calendar.SupplementRunningDates.Intersect(schedule.Calendar.SupplementRunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in supplementRunningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }
        
        var supplementNonRunningDates = schedules.Values.Where(s =>
            s.Calendar is { SupplementNonRunningDates: not null } &&
            s.Calendar.SupplementNonRunningDates.Intersect(schedule.Calendar.SupplementRunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in supplementNonRunningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }

        return false;
    }
    
    public static bool ReturnSupplementNonRunningDateMatch(Dictionary<string, TransXChangeSchedule> schedules, TransXChangeSchedule schedule)
    {
        if (schedule.Calendar is not { SupplementNonRunningDates: not null }) return false;

        var runningDates = schedules.Values.Where(s =>
            s.Calendar is { RunningDates: not null } &&
            s.Calendar.RunningDates.Intersect(schedule.Calendar.SupplementNonRunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in runningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }
        
        var supplementRunningDates = schedules.Values.Where(s =>
            s.Calendar is { SupplementRunningDates: not null } &&
            s.Calendar.SupplementRunningDates.Intersect(schedule.Calendar.SupplementNonRunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in supplementRunningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }
        
        var supplementNonRunningDates = schedules.Values.Where(s =>
            s.Calendar is { SupplementNonRunningDates: not null } &&
            s.Calendar.SupplementNonRunningDates.Intersect(schedule.Calendar.SupplementNonRunningDates).Any() && s.Id != schedule.Id).ToList();
        
        foreach (var duplicate in supplementNonRunningDates)
        {
            if (schedule.StopPoints == null || duplicate.StopPoints == null) continue;
                
            if (schedule.StopPoints.FirstOrDefault()?.AtcoCode !=
                duplicate.StopPoints.FirstOrDefault()?.AtcoCode ||
                schedule.StopPoints.FirstOrDefault()?.DepartureTime !=
                duplicate.StopPoints.FirstOrDefault()?.DepartureTime) continue;
                    
            if (schedule.StopPoints.LastOrDefault()?.AtcoCode !=
                duplicate.StopPoints.LastOrDefault()?.AtcoCode ||
                schedule.StopPoints.LastOrDefault()?.ArrivalTime !=
                duplicate.StopPoints.LastOrDefault()?.ArrivalTime) continue;
                        
            if (schedule.Line == duplicate.Line) { return true; }
        }

        return false;
    }
}