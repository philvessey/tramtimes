using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Operational", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeOperational
{
    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleType")]
    public TransXChangeVehicleType? VehicleType { get; set; }
}