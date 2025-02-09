using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "OutboundDescription", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeOutboundDescription
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Origin")]
    public string? Origin { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Destination")]
    public string? Destination { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Description")] 
    public string? Description { get; set; }
}