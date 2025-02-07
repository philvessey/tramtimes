using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Vias", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeVias
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Via")]
    public string? Via { get; set; }
}