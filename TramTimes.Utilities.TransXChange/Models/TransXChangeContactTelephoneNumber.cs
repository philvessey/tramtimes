using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "ContactTelephoneNumber", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeContactTelephoneNumber
{
    [UsedImplicitly]
    [XmlElement(ElementName = "TelNationalNumber")]
    public string? TelNationalNumber { get; set; }
}