using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "RouteLink", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeRouteLink
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "From")]
    public TransXChangeFrom? From { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "To")]
    public TransXChangeTo? To { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Distance")]
    public string? Distance { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Direction")]
    public string? Direction { get; set; }
}