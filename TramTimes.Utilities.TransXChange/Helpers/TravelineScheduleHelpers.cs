using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TravelineScheduleHelpers
{
    public static TravelineSchedule Build(TransXChangeOperators? operators, TransXChangeServices? services, TransXChangeJourneyPattern? journeyPattern, TravelineCalendar? calendar)
    {
        TravelineSchedule value = new()
        {
            Id = Guid.NewGuid().ToString(),
            Direction = "0",
            Line = "unknown",
            Mode = "0",
            OperatorCode = "unknown",
            OperatorName = "unknown",
            ServiceCode = services?.Service?.ServiceCode,
            Calendar = calendar,
            StopPoints = []
        };

        if (!string.IsNullOrEmpty(services?.Service?.Description))
        {
            value.Description = services.Service.Description.Trim();
        }

        if (!string.IsNullOrEmpty(journeyPattern?.Direction))
        {
            value.Direction = journeyPattern.Direction == "inbound" ? "1" : "0";
        }

        if (services?.Service?.Lines?.Line != null)
        {
            value.Line = services.Service.Lines.Line.LineName ?? "unknown";
        }

        if (string.IsNullOrEmpty(operators?.Operator?.NationalOperatorCode)) return value;
        
        value.OperatorCode = operators.Operator?.NationalOperatorCode;
        value.OperatorName = operators.Operator?.TradingName ?? operators.Operator?.OperatorNameOnLicence ?? operators.Operator?.OperatorShortName;

        return value;
    }
}