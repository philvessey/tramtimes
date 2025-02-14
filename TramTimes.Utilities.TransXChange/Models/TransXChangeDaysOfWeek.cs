using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "DaysOfWeek", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeDaysOfWeek
{
    [UsedImplicitly]
    [XmlElement(ElementName = "MondayToFriday")]
    public string? MondayToFriday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "MondayToSaturday")]
    public string? MondayToSaturday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "MondayToSunday")]
    public string? MondayToSunday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Weekend")]
    public string? Weekend { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NotMonday")]
    public string? NotMonday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NotTuesday")]
    public string? NotTuesday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NotWednesday")]
    public string? NotWednesday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NotThursday")]
    public string? NotThursday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NotFriday")]
    public string? NotFriday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NotSaturday")]
    public string? NotSaturday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NotSunday")]
    public string? NotSunday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Monday")]
    public string? Monday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Tuesday")]
    public string? Tuesday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Wednesday")]
    public string? Wednesday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Thursday")]
    public string? Thursday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Friday")]
    public string? Friday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Saturday")]
    public string? Saturday { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "Sunday")]
    public string? Sunday { get; set; }
}