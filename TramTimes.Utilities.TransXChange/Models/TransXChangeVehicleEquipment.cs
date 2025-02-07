using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "VehicleEquipment", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeVehicleEquipment
{
    [UsedImplicitly]
    [XmlElement(ElementName = "AccessVehicleEquipment")]
    public string? AccessVehicleEquipment { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "WheelchairVehicleEquipment")]
    public TransXChangeWheelchairVehicleEquipment? WheelchairVehicleEquipment { get; set; }
}