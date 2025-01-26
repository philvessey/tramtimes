using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class GtfsCalendarDate
{
    [UsedImplicitly]
    [Name("service_id")]
    public string? ServiceId { get; set; }

    [UsedImplicitly]
    [Name("date")]
    public string? Date { get; set; }

    [UsedImplicitly]
    [Name("exception_type")]
    public string? ExceptionType { get; set; }
}