using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "BankHolidayOperation", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeBankHolidayOperation
{
    [UsedImplicitly]
    [XmlElement(ElementName = "DaysOfOperation")]
    public TransXChangeDaysOfOperation? DaysOfOperation { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "DaysOfNonOperation")]
    public TransXChangeDaysOfNonOperation? DaysOfNonOperation { get; set; }
}