using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "VehicleJourneys", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeVehicleJourneys
{
    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleJourney")]
    public List<TransXChangeVehicleJourney>? VehicleJourney { get; set; }
}