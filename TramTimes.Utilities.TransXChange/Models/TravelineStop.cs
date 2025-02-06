using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class TravelineStop
{
    [UsedImplicitly]
    public string? StopPointReference { get; set; }
    
    [UsedImplicitly]
    public string? CommonName { get; set; }
    
    [UsedImplicitly]
    public string? LocalityName { get; set; }
}