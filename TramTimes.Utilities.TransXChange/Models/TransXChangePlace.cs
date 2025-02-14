using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "Place", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangePlace
{
    [UsedImplicitly]
    [XmlElement(ElementName = "NptgLocalityRef")]
    public string? NptgLocalityRef { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Location")]
    public TransXChangeLocation? Location { get; set; }
}