using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class GtfsStopTime
{
    [UsedImplicitly]
    [Name("trip_id")]
    public string? TripId { get; set; }

    [UsedImplicitly]
    [Name("arrival_time")]
    public string? ArrivalTime { get; set; }

    [UsedImplicitly]
    [Name("departure_time")]
    public string? DepartureTime { get; set; }

    [UsedImplicitly]
    [Name("stop_id")]
    public string? StopId { get; set; }

    [UsedImplicitly]
    [Name("stop_sequence")]
    public string? StopSequence { get; set; }

    [UsedImplicitly]
    [Name("stop_headsign")]
    public string? StopHeadsign { get; set; }

    [UsedImplicitly]
    [Name("pickup_type")]
    public string? PickupType { get; set; }

    [UsedImplicitly]
    [Name("drop_off_type")]
    public string? DropOffType { get; set; }

    [UsedImplicitly]
    [Name("shape_dist_traveled")]
    public string? ShapeDistTraveled { get; set; }

    [UsedImplicitly]
    [Name("timepoint")]
    public string? Timepoint { get; set; }
}