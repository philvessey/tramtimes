using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Service")]
public class TransXChangeService
{
    [UsedImplicitly]
    [XmlElement(ElementName = "ServiceCode")]
    public string? ServiceCode { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Lines")]
    public TransXChangeLines? Lines { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "OperatingPeriod")]
    public TransXChangeOperatingPeriod? OperatingPeriod { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "OperatingProfile")]
    public TransXChangeOperatingProfile? OperatingProfile { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "RegisteredOperatorRef")]
    public string? RegisteredOperatorRef { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "StopRequirements")]
    public TransXChangeStopRequirements? StopRequirements { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Mode")]
    public string? Mode { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Description")]
    public string? Description { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "StandardService")]
    public TransXChangeStandardService? StandardService { get; set; }
}