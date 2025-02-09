using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "To")]
public class TransXChangeTo
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