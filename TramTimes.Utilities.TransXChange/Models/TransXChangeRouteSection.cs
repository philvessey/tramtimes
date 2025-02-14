using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "RouteSection", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeRouteSection
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "RouteLink")]
    public List<TransXChangeRouteLink>? RouteLink { get; set; }
}