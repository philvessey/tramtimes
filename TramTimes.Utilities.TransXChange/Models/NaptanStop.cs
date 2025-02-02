using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class NaptanStop
{
    [UsedImplicitly]
    [Name("ATCOCode")]
    public string? AtcoCode { get; set; }
    
    [UsedImplicitly]
    [Name("NaptanCode")]
    public string? NaptanCode { get; set; }
    
    [UsedImplicitly]
    [Name("CommonName")]
    public string? CommonName { get; set; }
    
    [UsedImplicitly]
    [Name("Indicator")]
    public string? Indicator { get; set; }
    
    [UsedImplicitly]
    [Name("LocalityName")]
    public string? LocalityName { get; set; }
    
    [UsedImplicitly]
    [Name("Easting")]
    public string? Easting { get; set; }
    
    [UsedImplicitly]
    [Name("Northing")]
    public string? Northing { get; set; }
    
    [UsedImplicitly]
    [Name("Longitude")]
    public string? Longitude { get; set; }
    
    [UsedImplicitly]
    [Name("Latitude")]
    public string? Latitude { get; set; }
    
    [UsedImplicitly]
    [Name("StopType")]
    public string? StopType { get; set; }
}