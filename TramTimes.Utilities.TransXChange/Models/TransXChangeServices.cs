using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Services", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeServices
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Service")]
    public TransXChangeService? Service { get; set; }
}