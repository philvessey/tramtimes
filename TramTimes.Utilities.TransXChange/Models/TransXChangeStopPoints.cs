using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "StopPoints", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeStopPoints
{
    [UsedImplicitly]
    [XmlElement(ElementName = "AnnotatedStopPointRef")]
    public List<TransXChangeAnnotatedStopPointRef>? AnnotatedStopPointRef { get; set; }
}