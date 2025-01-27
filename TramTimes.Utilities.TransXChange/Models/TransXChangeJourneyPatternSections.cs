using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "JourneyPatternSections")]
public class TransXChangeJourneyPatternSections
{
    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternSection")]
    public List<TransXChangeJourneyPatternSection>? JourneyPatternSection { get; set; }
}