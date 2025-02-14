using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Operators", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeOperators
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Operator")]
    public TransXChangeOperator? Operator { get; set; }
}