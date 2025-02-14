using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "DateRange", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeDateRange
{
    [UsedImplicitly]
    [XmlElement(ElementName = "StartDate")]
    public string? StartDate { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "EndDate")]
    public string? EndDate { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Note")] 
    public string? Note { get; set; }
}