using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class GtfsCalendar
{
    [UsedImplicitly]
    [Name("service_id")]
    public string? ServiceId { get; set; }

    [UsedImplicitly]
    [Name("monday")]
    public string? Monday { get; set; }

    [UsedImplicitly]
    [Name("tuesday")]
    public string? Tuesday { get; set; }

    [UsedImplicitly]
    [Name("wednesday")]
    public string? Wednesday { get; set; }

    [UsedImplicitly]
    [Name("thursday")]
    public string? Thursday { get; set; }

    [UsedImplicitly]
    [Name("friday")]
    public string? Friday { get; set; }

    [UsedImplicitly]
    [Name("saturday")]
    public string? Saturday { get; set; }

    [UsedImplicitly]
    [Name("sunday")]
    public string? Sunday { get; set; }

    [UsedImplicitly]
    [Name("start_date")]
    public string? StartDate { get; set; }
    
    [UsedImplicitly]
    [Name("end_date")]
    public string? EndDate { get; set; }
}