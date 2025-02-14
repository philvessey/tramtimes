using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class TravelineStopPoint
{
    [UsedImplicitly]
    public string? AtcoCode { get; set; }
    
    [UsedImplicitly]
    public string? Activity { get; set; }
    
    [UsedImplicitly]
    public TimeSpan? ArrivalTime { get; set; }
    
    [UsedImplicitly]
    public TimeSpan? DepartureTime { get; set; }
    
    [UsedImplicitly]
    public NaptanStop? NaptanStop { get; set; }
    
    [UsedImplicitly]
    public TravelineStop? TravelineStop { get; set; }
}