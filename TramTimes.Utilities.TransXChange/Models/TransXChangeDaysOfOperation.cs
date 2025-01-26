using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "DaysOfOperation")]
public class TransXChangeDaysOfOperation
{
	[UsedImplicitly]
	[XmlElement(ElementName = "AllBankHolidays")]
	public string? AllBankHolidays { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "AllHolidaysExceptChristmas")]
	public string? AllHolidaysExceptChristmas { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "Christmas")]
	public string? Christmas { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "DisplacementHolidays")]
	public string? DisplacementHolidays { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "EarlyRunOff")]
	public string? EarlyRunOff { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "HolidayMondays")]
	public string? HolidayMondays { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "Holidays")]
	public string? Holidays { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "NewYearsDay")]
	public string? NewYearsDay { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "NewYearsDayHoliday")]
	public string? NewYearsDayHoliday { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "Jan2ndScotland")]
	public string? JanSecondScotland { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "Jan2ndScotlandHoliday")]
	public string? JanSecondScotlandHoliday { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "GoodFriday")]
	public string? GoodFriday { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "EasterMonday")]
	public string? EasterMonday { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "MayDay")]
	public string? MayDay { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "SpringBank")]
	public string? SpringBank { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "AugustBankHolidayScotland")]
	public string? AugustBankHolidayScotland { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "LateSummerBankHolidayNotScotland")]
	public string? LateSummerBankHolidayNotScotland { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "StAndrewsDay")]
	public string? StAndrewsDay { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "StAndrewsDayHoliday")]
	public string? StAndrewsDayHoliday { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "ChristmasEve")]
	public string? ChristmasEve { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "ChristmasDay")]
	public string? ChristmasDay { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "ChristmasDayHoliday")]
	public string? ChristmasDayHoliday { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "BoxingDay")]
	public string? BoxingDay { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "BoxingDayHoliday")]
	public string? BoxingDayHoliday { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "NewYearsEve")]
	public string? NewYearsEve { get; set; }

	[UsedImplicitly]
	[XmlElement(ElementName = "DateRange")]
	public TransXChangeDateRange? DateRange { get; set; }
}