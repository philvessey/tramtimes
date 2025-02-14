using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "RegularDayType", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeRegularDayType
{
    [UsedImplicitly]
    [XmlElement(ElementName = "DaysOfWeek")]
    public TransXChangeDaysOfWeek? DaysOfWeek { get; set; }
}