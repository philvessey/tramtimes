using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "VehicleJourney", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeVehicleJourney
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "SequenceNumber")]
    public string? SequenceNumber { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "PrivateCode")]
    public string? PrivateCode { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Operational")]
    public TransXChangeOperational? Operational { get; set; }
    
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
    [XmlElement(ElementName = "OperatorRef")]
    public string? OperatorRef { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "LineRef")]
    public string? LineRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternRef")]
    public string? JourneyPatternRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "DepartureTime")]
    public string? DepartureTime { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "DepartureDayShift")]
    public string? DepartureDayShift { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleJourneyTimingLink")] 
    public List<TransXChangeVehicleJourneyTimingLink>? VehicleJourneyTimingLink { get; set; }
}