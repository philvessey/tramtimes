using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "JourneyPattern")]
public class TransXChangeJourneyPattern
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Direction")]
    public string? Direction { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternSectionRefs")]
    public string? JourneyPatternSectionRefs { get; set; }
}