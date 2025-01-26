using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[UsedImplicitly]
[XmlRoot(ElementName = "Line")]
public class TransXChangeLine
{
    [UsedImplicitly]
    [XmlAttribute(AttributeName = "id")]
    public string? Id { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "LineName")]
    public string? LineName { get; set; }
}