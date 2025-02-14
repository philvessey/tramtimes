using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "JourneyPatternSections", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeJourneyPatternSections
{
    [UsedImplicitly]
    [XmlElement(ElementName = "JourneyPatternSection")]
    public List<TransXChangeJourneyPatternSection>? JourneyPatternSection { get; set; }
}