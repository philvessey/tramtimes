using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "WheelchairVehicleEquipment", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeWheelchairVehicleEquipment
{
    [UsedImplicitly]
    [XmlElement(ElementName = "SuitableFor")]
    public string? SuitableFor { get; set; }
}