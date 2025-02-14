using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Services", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeServices
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Service")]
    public TransXChangeService? Service { get; set; }
}