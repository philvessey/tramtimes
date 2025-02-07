using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Operator", Namespace = "http://www.transxchange.org.uk/")]
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
    
    [UsedImplicitly]
    [XmlElement(ElementName = "LicenceNumber")]
    public string? LicenceNumber { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "LicenceClassification")]
    public string? LicenceClassification { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "EnquiryTelephoneNumber")]
    public TransXChangeEnquiryTelephoneNumber? EnquiryTelephoneNumber { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "ContactTelephoneNumber")]
    public TransXChangeContactTelephoneNumber? ContactTelephoneNumber { get; set; }
}