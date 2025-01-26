using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class GtfsAgency
{
    [UsedImplicitly]
    [Name("agency_id")]
    public string? AgencyId { get; set; }
    
    [UsedImplicitly]
    [Name("agency_name")]
    public string? AgencyName { get; set; }

    [UsedImplicitly]
    [Name("agency_url")]
    public string? AgencyUrl { get; set; }

    [UsedImplicitly]
    [Name("agency_timezone")]
    public string? AgencyTimezone { get; set; }

    [UsedImplicitly]
    [Name("agency_lang")]
    public string? AgencyLang { get; set; }

    [UsedImplicitly]
    [Name("agency_phone")]
    public string? AgencyPhone { get; set; }

    [UsedImplicitly]
    [Name("agency_fare_url")]
    public string? AgencyFareUrl { get; set; }

    [UsedImplicitly]
    [Name("agency_email")]
    public string? AgencyEmail { get; set; }
}