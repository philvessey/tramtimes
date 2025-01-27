using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "RouteLink")]
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
    [XmlElement(ElementName = "Direction")]
    public string? Direction { get; set; }
}