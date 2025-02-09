using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "EnquiryTelephoneNumber", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeEnquiryTelephoneNumber
{
    [UsedImplicitly]
    [XmlElement(ElementName = "TelNationalNumber")]
    public string? TelNationalNumber { get; set; }
}