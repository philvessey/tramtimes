using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Rail", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeRail
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Platform")]
    public string? Platform { get; set; }
}