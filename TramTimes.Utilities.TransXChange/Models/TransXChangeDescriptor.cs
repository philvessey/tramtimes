using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Descriptor", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeDescriptor
{
    [UsedImplicitly]
    [XmlElement(ElementName = "CommonName")]
    public string? CommonName { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "ShortCommonName")]
    public string? ShortCommonName { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Landmark")]
    public string? Landmark { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Street")]
    public string? Street { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Crossing")]
    public string? Crossing { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Indicator")]
    public string? Indicator { get; set; }
}