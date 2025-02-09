using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Line", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeLine
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "LineName")]
    public string? LineName { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "OutboundDescription")] 
    public TransXChangeOutboundDescription? OutboundDescription { get; set; } 
    
    [UsedImplicitly]
    [XmlElement(ElementName = "InboundDescription")] 
    public TransXChangeInboundDescription? InboundDescription { get; set; }
}