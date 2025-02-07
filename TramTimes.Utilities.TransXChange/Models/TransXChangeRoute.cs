using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Route", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeRoute
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "PrivateCode")]
    public string? PrivateCode { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Description")]
    public string? Description { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "RouteSectionRef")]
    public List<string>? RouteSectionRef { get; set; }
}