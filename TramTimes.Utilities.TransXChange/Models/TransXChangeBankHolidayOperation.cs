using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "BankHolidayOperation")]
public class TransXChangeBankHolidayOperation
{
    [UsedImplicitly]
    [XmlElement(ElementName = "DaysOfOperation")]
    public TransXChangeDaysOfOperation? DaysOfOperation { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "DaysOfNonOperation")]
    public TransXChangeDaysOfNonOperation? DaysOfNonOperation { get; set; }
}