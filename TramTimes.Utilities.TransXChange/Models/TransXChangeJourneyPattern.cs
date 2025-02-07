using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "JourneyPattern", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeJourneyPattern
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "DestinationDisplay")]
    public string? DestinationDisplay { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Direction")]
    public string? Direction { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Operational")] 
    public TransXChangeOperational? Operational { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "RouteRef")]
    public string? RouteRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternSectionRefs")]
    public List<string>? JourneyPatternSectionRefs { get; set; }
}