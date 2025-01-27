using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "RegularDayType")]
public class TransXChangeRegularDayType
{
    [UsedImplicitly]
    [XmlElement(ElementName = "DaysOfWeek")]
    public TransXChangeDaysOfWeek? DaysOfWeek { get; set; }
}