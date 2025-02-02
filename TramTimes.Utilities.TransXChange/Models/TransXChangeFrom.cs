using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "From", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeFrom
{
    [UsedImplicitly]
    [XmlElement(ElementName = "WaitTime")]
    public string? WaitTime { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Activity")]
    public string? Activity { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "StopPointRef")]
    public string? StopPointRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "TimingStatus")]
    public string? TimingStatus { get; set; }
}