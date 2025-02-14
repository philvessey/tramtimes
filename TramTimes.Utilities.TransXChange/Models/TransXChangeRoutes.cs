using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Routes", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeRoutes
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Route")]
    public List<TransXChangeRoute>? Route { get; set; }
}