using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "RouteSections", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeRouteSections
{
    [UsedImplicitly]
    [XmlElement(ElementName = "RouteSection")]
    public List<TransXChangeRouteSection>? RouteSection { get; set; }
}