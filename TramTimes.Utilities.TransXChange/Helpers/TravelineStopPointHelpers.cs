using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TravelineStopPointHelpers
{
    public static TravelineStopPoint Build(Dictionary<string, NaptanLocality> localities, Dictionary<string, NaptanStop> stops, TransXChangeStopPoints? stopPoints, string? reference, string? activity, TimeSpan? arrivalTime, TimeSpan? departureTime)
    {
        return new TravelineStopPoint
        {
            AtcoCode = reference,
            Activity = activity,
            ArrivalTime = arrivalTime ?? TimeSpan.Zero,
            DepartureTime = departureTime ?? TimeSpan.Zero,
            NaptanStop = NaptanStopHelpers.Build(stops, reference),
            TravelineStop = TravelineStopHelpers.Build(localities, stopPoints, reference)
        };
    }
}