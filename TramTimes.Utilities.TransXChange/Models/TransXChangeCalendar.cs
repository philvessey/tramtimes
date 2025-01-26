using JetBrains.Annotations;

namespace TramTimes.Utilities.TransXChange.Models;

public class TransXChangeCalendar
{
    [UsedImplicitly]
    public bool? Monday { get; set; }
    
    [UsedImplicitly]
    public bool? Tuesday { get; set; }
    
    [UsedImplicitly]
    public bool? Wednesday { get; set; }
    
    [UsedImplicitly]
    public bool? Thursday { get; set; }
    
    [UsedImplicitly]
    public bool? Friday { get; set; }
    
    [UsedImplicitly]
    public bool? Saturday { get; set; }
    
    [UsedImplicitly]
    public bool? Sunday { get; set; }
    
    [UsedImplicitly]
    public DateTime? StartDate { get; set; }
    
    [UsedImplicitly]
    public DateTime? EndDate { get; set; }
    
    [UsedImplicitly]
    public List<DateTime>? RunningDates { get; set; }
    
    [UsedImplicitly]
    public List<DateTime>? SupplementRunningDates { get; set; }
    
    [UsedImplicitly]
    public List<DateTime>? SupplementNonRunningDates { get; set; }
}