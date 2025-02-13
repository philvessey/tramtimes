using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TravelineScheduleHelpers
{
    public static TravelineSchedule Build(TransXChangeOperators? operators, TransXChangeServices? services, TransXChangeJourneyPattern? journeyPattern, TravelineCalendar? calendar)
    {
        return new TravelineSchedule
        {
            Id = Guid.NewGuid().ToString(),
            Description = services?.Service?.Description?.Trim(),
            Direction = journeyPattern?.Direction == "inbound" ? "1" : "0",
            Line = services?.Service?.Lines?.Line?.LineName,
            Mode = "0",
            OperatorCode = operators?.Operator?.NationalOperatorCode,
            OperatorName = operators?.Operator?.TradingName ?? operators?.Operator?.OperatorNameOnLicence ?? operators?.Operator?.OperatorShortName,
            OperatorPhone = operators?.Operator?.ContactTelephoneNumber?.TelNationalNumber ?? operators?.Operator?.EnquiryTelephoneNumber?.TelNationalNumber,
            ServiceCode = services?.Service?.ServiceCode,
            Calendar = calendar,
            StopPoints = []
        };
    }
}