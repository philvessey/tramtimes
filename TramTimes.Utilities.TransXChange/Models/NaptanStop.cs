using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class NaptanStop
{
    [UsedImplicitly]
    public string? AtcoCode { get; set; }
    
    [UsedImplicitly]
    public string? NaptanCode { get; set; }
    
    [UsedImplicitly]
    public string? CommonName { get; set; }
    
    [UsedImplicitly]
    public string? Indicator { get; set; }
    
    [UsedImplicitly]
    public string? LocalityName { get; set; }
    
    [UsedImplicitly]
    public string? Easting { get; set; }
    
    [UsedImplicitly]
    public string? Northing { get; set; }
    
    [UsedImplicitly]
    public string? Longitude { get; set; }
    
    [UsedImplicitly]
    public string? Latitude { get; set; }
    
    [UsedImplicitly]
    public string? StopType { get; set; }
}