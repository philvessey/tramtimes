using CsvHelper.Configuration.Attributes;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class NaptanLocality
{
    [UsedImplicitly]
    [Name("NptgLocalityCode")]
    public string? NptgLocalityCode { get; set; }
    
    [UsedImplicitly]
    [Name("LocalityName")]
    public string? LocalityName { get; set; }
    
    [UsedImplicitly]
    [Name("LocalityNameLang")]
    public string? LocalityNameLang { get; set; }
    
    [UsedImplicitly]
    [Name("ShortName")]
    public string? ShortName { get; set; }
    
    [UsedImplicitly]
    [Name("ShortNameLang")]
    public string? ShortNameLang { get; set; }
    
    [UsedImplicitly]
    [Name("QualifierName")]
    public string? QualifierName { get; set; }
    
    [UsedImplicitly]
    [Name("QualifierNameLang")]
    public string? QualifierNameLang { get; set; }
    
    [UsedImplicitly]
    [Name("QualifierLocalityRef")]
    public string? QualifierLocalityRef { get; set; }
    
    [UsedImplicitly]
    [Name("QualifierDistrictRef")]
    public string? QualifierDistrictRef { get; set; }
    
    [UsedImplicitly]
    [Name("ParentLocalityName")]
    public string? ParentLocalityName { get; set; }
    
    [UsedImplicitly]
    [Name("ParentLocalityNameLang")]
    public string? ParentLocalityNameLang { get; set; }
    
    [UsedImplicitly]
    [Name("AdministrativeAreaCode")]
    public string? AdministrativeAreaCode { get; set; }
    
    [UsedImplicitly]
    [Name("NptgDistrictCode")]
    public string? NptgDistrictCode { get; set; }
    
    [UsedImplicitly]
    [Name("SourceLocalityType")]
    public string? SourceLocalityType { get; set; }
    
    [UsedImplicitly]
    [Name("GridType")]
    public string? GridType { get; set; }
    
    [UsedImplicitly]
    [Name("Easting")]
    public string? Easting { get; set; }
    
    [UsedImplicitly]
    [Name("Northing")]
    public string? Northing { get; set; }
}