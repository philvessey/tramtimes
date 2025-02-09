using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Location", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeLocation
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Easting")]
    public string? Easting { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Northing")]
    public string? Northing { get; set; }
}