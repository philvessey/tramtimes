using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "TransXChange", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChange
{
    [UsedImplicitly]
    [XmlElement(ElementName = "StopPoints")]
    public TransXChangeStopPoints? StopPoints { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "RouteSections")]
    public TransXChangeRouteSections? RouteSections { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Routes")]
    public TransXChangeRoutes? Routes { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternSections")]
    public TransXChangeJourneyPatternSections? JourneyPatternSections { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Operators")]
    public TransXChangeOperators? Operators { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Services")]
    public TransXChangeServices? Services { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleJourneys")]
    public TransXChangeVehicleJourneys? VehicleJourneys { get; set; }
}