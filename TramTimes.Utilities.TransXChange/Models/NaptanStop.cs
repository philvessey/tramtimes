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
    [Name("PlateCode")]
    public string? PlateCode { get; set; }
    
    [UsedImplicitly]
    [Name("CleardownCode")]
    public string? CleardownCode { get; set; }
    
    [UsedImplicitly]
    [Name("CommonName")]
    public string? CommonName { get; set; }
    
    [UsedImplicitly]
    [Name("CommonNameLang")]
    public string? CommonNameLang { get; set; }
    
    [UsedImplicitly]
    [Name("ShortCommonName")]
    public string? ShortCommonName { get; set; }
    
    [UsedImplicitly]
    [Name("ShortCommonNameLang")]
    public string? ShortCommonNameLang { get; set; }
    
    [UsedImplicitly]
    [Name("Landmark")]
    public string? Landmark { get; set; }
    
    [UsedImplicitly]
    [Name("LandmarkLang")]
    public string? LandmarkLang { get; set; }
    
    [UsedImplicitly]
    [Name("Street")]
    public string? Street { get; set; }
    
    [UsedImplicitly]
    [Name("StreetLang")]
    public string? StreetLang { get; set; }
    
    [UsedImplicitly]
    [Name("Crossing")]
    public string? Crossing { get; set; }
    
    [UsedImplicitly]
    [Name("CrossingLang")]
    public string? CrossingLang { get; set; }
    
    [UsedImplicitly]
    [Name("Indicator")]
    public string? Indicator { get; set; }
    
    [UsedImplicitly]
    [Name("IndicatorLang")]
    public string? IndicatorLang { get; set; }
    
    [UsedImplicitly]
    [Name("Bearing")]
    public string? Bearing { get; set; }
    
    [UsedImplicitly]
    [Name("NptgLocalityCode")]
    public string? NptgLocalityCode { get; set; }
    
    [UsedImplicitly]
    [Name("LocalityName")]
    public string? LocalityName { get; set; }
    
    [UsedImplicitly]
    [Name("ParentLocalityName")]
    public string? ParentLocalityName { get; set; }
    
    [UsedImplicitly]
    [Name("GrandParentLocalityName")]
    public string? GrandParentLocalityName { get; set; }
    
    [UsedImplicitly]
    [Name("Town")]
    public string? Town { get; set; }
    
    [UsedImplicitly]
    [Name("TownLang")]
    public string? TownLang { get; set; }
    
    [UsedImplicitly]
    [Name("Suburb")]
    public string? Suburb { get; set; }
    
    [UsedImplicitly]
    [Name("SuburbLang")]
    public string? SuburbLang { get; set; }
    
    [UsedImplicitly]
    [Name("LocalityCentre")]
    public string? LocalityCentre { get; set; }
    
    [UsedImplicitly]
    [Name("GridType")]
    public string? GridType { get; set; }
    
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
    
    [UsedImplicitly]
    [Name("BusStopType")]
    public string? BusStopType { get; set; }
    
    [UsedImplicitly]
    [Name("TimingStatus")]
    public string? TimingStatus { get; set; }
    
    [UsedImplicitly]
    [Name("DefaultWaitTime")]
    public string? DefaultWaitTime { get; set; }
    
    [UsedImplicitly]
    [Name("Notes")]
    public string? Notes { get; set; }
    
    [UsedImplicitly]
    [Name("NotesLang")]
    public string? NotesLang { get; set; }
    
    [UsedImplicitly]
    [Name("AdministrativeAreaCode")]
    public string? AdministrativeAreaCode { get; set; }
}