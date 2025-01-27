using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Operator")]
public class TransXChangeOperator
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "NationalOperatorCode")]
    public string? NationalOperatorCode { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "OperatorCode")]
    public string? OperatorCode { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "OperatorShortName")]
    public string? OperatorShortName { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "OperatorNameOnLicence")]
    public string? OperatorNameOnLicence { get; set; }

    [UsedImplicitly]
    [XmlElement(ElementName = "TradingName")]
    public string? TradingName { get; set; }
}