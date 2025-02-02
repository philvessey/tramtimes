using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "VehicleJourney", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeVehicleJourney
{
    [UsedImplicitly]
    [XmlElement(ElementName = "OperatorRef")]
    public string? OperatorRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "OperatingProfile")]
    public TransXChangeOperatingProfile? OperatingProfile { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleJourneyCode")]
    public string? VehicleJourneyCode { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "ServiceRef")]
    public string? ServiceRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "LineRef")]
    public string? LineRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternRef")]
    public string? JourneyPatternRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "DepartureTime")]
    public string? DepartureTime { get; set; }
}