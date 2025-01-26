using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class GtfsTrip
{
    [UsedImplicitly]
    [Name("route_id")]
    public string? RouteId { get; set; }

    [UsedImplicitly]
    [Name("service_id")]
    public string? ServiceId { get; set; }

    [UsedImplicitly]
    [Name("trip_id")]
    public string? TripId { get; set; }

    [UsedImplicitly]
    [Name("trip_headsign")]
    public string? TripHeadsign { get; set; }

    [UsedImplicitly]
    [Name("trip_short_name")]
    public string? TripShortName { get; set; }

    [UsedImplicitly]
    [Name("direction_id")]
    public string? DirectionId { get; set; }

    [UsedImplicitly]
    [Name("block_id")]
    public string? BlockId { get; set; }

    [UsedImplicitly]
    [Name("shape_id")]
    public string? ShapeId { get; set; }

    [UsedImplicitly]
    [Name("wheelchair_accessible")]
    public string? WheelchairAccessible { get; set; }

    [UsedImplicitly]
    [Name("bikes_allowed")]
    public string? BikesAllowed { get; set; }
}