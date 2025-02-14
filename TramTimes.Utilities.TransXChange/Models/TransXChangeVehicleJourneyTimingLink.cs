using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "VehicleJourneyTimingLink", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeVehicleJourneyTimingLink
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternTimingLinkRef")] 
    public string? JourneyPatternTimingLinkRef { get; set; }
}