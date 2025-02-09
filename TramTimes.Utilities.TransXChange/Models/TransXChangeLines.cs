using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Lines", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeLines
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Line")]
    public TransXChangeLine? Line { get; set; }
}