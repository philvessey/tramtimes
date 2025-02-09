using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "AnnotatedStopPointRef", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeAnnotatedStopPointRef
{
    [UsedImplicitly]
    [XmlElement(ElementName = "StopPointRef")]
    public string? StopPointRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "CommonName")]
    public string? CommonName { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Indicator")]
    public string? Indicator { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "LocalityName")]
    public string? LocalityName { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "LocalityQualifier")]
    public string? LocalityQualifier { get; set; }
}