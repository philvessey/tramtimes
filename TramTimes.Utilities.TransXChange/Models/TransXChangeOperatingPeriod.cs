using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "OperatingPeriod")]
public class TransXChangeOperatingPeriod
{
    [UsedImplicitly]
    [XmlElement(ElementName = "StartDate")]
    public string? StartDate { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "EndDate")]
    public string? EndDate { get; set; }
}