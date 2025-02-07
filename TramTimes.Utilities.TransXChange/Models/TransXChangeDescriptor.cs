using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Descriptor", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeDescriptor
{
    [UsedImplicitly]
    [XmlElement(ElementName = "CommonName")]
    public string? CommonName { get; set; }
}