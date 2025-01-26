using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Operators")]
public class TransXChangeOperators
{
    [UsedImplicitly]
    [XmlElement(ElementName = "Operator")]
    public TransXChangeOperator? Operator { get; set; }
}