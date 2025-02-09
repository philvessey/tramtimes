using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "JourneyPatternSection", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeJourneyPatternSection
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternTimingLink")]
    public List<TransXChangeJourneyPatternTimingLink>? JourneyPatternTimingLink { get; set; }
}