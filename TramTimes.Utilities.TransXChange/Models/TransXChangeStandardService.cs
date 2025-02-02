using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "StandardService", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeStandardService
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Origin")]
    public string? Origin { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Destination")]
    public string? Destination { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPattern")]
    public List<TransXChangeJourneyPattern>? JourneyPattern { get; set; }
}