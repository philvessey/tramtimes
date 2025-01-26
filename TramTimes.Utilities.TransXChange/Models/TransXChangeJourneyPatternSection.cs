using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "JourneyPatternSection")]
public class TransXChangeJourneyPatternSection
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternTimingLink")]
    public List<TransXChangeJourneyPatternTimingLink>? JourneyPatternTimingLink { get; set; }
}