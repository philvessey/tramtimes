using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "AnnotatedStopPointRef")]
public class TransXChangeAnnotatedStopPointRef
{
    [UsedImplicitly]
    [XmlElement(ElementName = "StopPointRef")]
    public string? StopPointRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "CommonName")]
    public string? CommonName { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "LocalityName")]
    public string? LocalityName { get; set; }
}