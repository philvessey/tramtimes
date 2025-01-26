using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "RouteSections")]
public class TransXChangeRouteSections
{
    [UsedImplicitly]
    [XmlElement(ElementName = "RouteSection")]
    public List<TransXChangeRouteSection>? RouteSection { get; set; }
}