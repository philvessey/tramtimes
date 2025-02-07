using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "JourneyPatternTimingLink", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeJourneyPatternTimingLink
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "From")]
    public TransXChangeFrom? From { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "To")]
    public TransXChangeTo? To { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "RouteLinkRef")]
    public string? RouteLinkRef { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "RunTime")]
    public string? RunTime { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Direction")]
    public string? Direction { get; set; }
}