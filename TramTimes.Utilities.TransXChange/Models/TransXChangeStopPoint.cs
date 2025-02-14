using System.Xml.Serialization;
using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

[XmlRoot(ElementName = "StopPoint", Namespace = "http://www.transxchange.org.uk/")]
public class TransXChangeStopPoint
{
    [UsedImplicitly]
    [XmlElement(ElementName = "AtcoCode")]
    public string? AtcoCode { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Descriptor")]
    public TransXChangeDescriptor? Descriptor { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Place")]
    public TransXChangePlace? Place { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "StopClassification")]
    public TransXChangeStopClassification? StopClassification { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "AdministrativeAreaRef")] 
    public string? AdministrativeAreaRef { get; set; }
    
    [UsedImplicitly]
    [XmlElement(ElementName = "Notes")] 
    public string? Notes { get; set; }
}