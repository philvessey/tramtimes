using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "StopRequirements")]
public class TransXChangeStopRequirements
{
    [UsedImplicitly]
    [XmlElement(ElementName = "NoNewStopsRequired")]
    public string? NoNewStopsRequired { get; set; }
}