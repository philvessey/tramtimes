using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "VehicleJourneys")]
public class TransXChangeVehicleJourneys
{
    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleJourney")]
    public List<TransXChangeVehicleJourney>? VehicleJourney { get; set; }
}