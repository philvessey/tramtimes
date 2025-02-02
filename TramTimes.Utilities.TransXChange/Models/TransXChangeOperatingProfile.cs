using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "OperatingProfile", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeOperatingProfile
{
    [UsedImplicitly]
    [XmlElement(ElementName = "RegularDayType")]
    public TransXChangeRegularDayType? RegularDayType { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "BankHolidayOperation")]
    public TransXChangeBankHolidayOperation? BankHolidayOperation { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "SpecialDaysOperation")]
    public TransXChangeSpecialDaysOperation? SpecialDaysOperation { get; set; }
}