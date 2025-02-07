using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "VehicleType", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeVehicleType
{
    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleEquipment")] 
    public TransXChangeVehicleEquipment? VehicleEquipment { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "WheelchairAccessible")] 
    public string? WheelchairAccessible { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "VehicleTypeCode")] 
    public string? VehicleTypeCode { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Description")] 
    public string? Description { get; set; }
}