using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class GtfsStop
{
    [UsedImplicitly]
    [Name("stop_id")]
    public string? StopId { get; set; }

    [UsedImplicitly]
    [Name("stop_code")]
    public string? StopCode { get; set; }

    [UsedImplicitly]
    [Name("stop_name")]
    public string? StopName { get; set; }

    [UsedImplicitly]
    [Name("stop_desc")]
    public string? StopDesc { get; set; }

    [UsedImplicitly]
    [Name("stop_lat")]
    public string? StopLat { get; set; }

    [UsedImplicitly]
    [Name("stop_lon")]
    public string? StopLon { get; set; }

    [UsedImplicitly]
    [Name("zone_id")]
    public string? ZoneId { get; set; }

    [UsedImplicitly]
    [Name("stop_url")]
    public string? StopUrl { get; set; }

    [UsedImplicitly]
    [Name("location_type")]
    public string? LocationType { get; set; }

    [UsedImplicitly]
    [Name("parent_station")]
    public string? ParentStation { get; set; }

    [UsedImplicitly]
    [Name("stop_timezone")]
    public string? StopTimezone { get; set; }

    [UsedImplicitly]
    [Name("wheelchair_boarding")]
    public string? WheelchairBoarding { get; set; }

    [UsedImplicitly]
    [Name("level_id")]
    public string? LevelId { get; set; }

    [UsedImplicitly]
    [Name("platform_code")]
    public string? PlatformCode { get; set; }
}