using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Routes")]
public class TransXChangeRoutes
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Route")]
    public List<TransXChangeRoute>? Route { get; set; }
}