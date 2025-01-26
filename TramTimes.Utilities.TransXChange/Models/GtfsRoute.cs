using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class GtfsRoute
{
    [UsedImplicitly]
    [Name("route_id")]
    public string? RouteId { get; set; }

    [UsedImplicitly]
    [Name("agency_id")]
    public string? AgencyId { get; set; }

    [UsedImplicitly]
    [Name("route_short_name")]
    public string? RouteShortName { get; set; }

    [UsedImplicitly]
    [Name("route_long_name")]
    public string? RouteLongName { get; set; }

    [UsedImplicitly]
    [Name("route_desc")]
    public string? RouteDesc { get; set; }

    [UsedImplicitly]
    [Name("route_type")]
    public string? RouteType { get; set; }

    [UsedImplicitly]
    [Name("route_url")]
    public string? RouteUrl { get; set; }

    [UsedImplicitly]
    [Name("route_color")]
    public string? RouteColor { get; set; }

    [UsedImplicitly]
    [Name("route_text_color")]
    public string? RouteTextColor { get; set; }

    [UsedImplicitly]
    [Name("route_sort_order")]
    public string? RouteSortOrder { get; set; }
}