using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class TransXChangeSchedule
{
    [UsedImplicitly]
    public string? Id { get; set; }
    
    [UsedImplicitly]
    public string? Description { get; set; }
    
    [UsedImplicitly]
    public string? Direction { get; set; }
    
    [UsedImplicitly]
    public string? Line { get; set; }
    
    [UsedImplicitly]
    public string? Mode { get; set; }
    
    [UsedImplicitly]
    public string? OperatorCode { get; set; }
    
    [UsedImplicitly]
    public string? OperatorName { get; set; }
    
    [UsedImplicitly]
    public string? ServiceCode { get; set; }
    
    [UsedImplicitly]
    public TransXChangeCalendar? Calendar { get; set; }
    
    [UsedImplicitly]
    public List<TransXChangeStopPoint>? StopPoints { get; set; }
}