using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "StopClassification", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeStopClassification
{
    [UsedImplicitly]
    [XmlElement(ElementName = "StopType")]
    public string? StopType { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "OffStreet")]
    public TransXChangeOffStreet? OffStreet { get; set; }
}