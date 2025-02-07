using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "OffStreet", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeOffStreet
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Rail")]
    public TransXChangeRail? Rail { get; set; }
}