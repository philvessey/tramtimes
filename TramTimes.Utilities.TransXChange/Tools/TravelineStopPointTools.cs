using System.Xml;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TravelineStopPointTools
{
    public static TimeSpan GetRunTime(TransXChangeJourneyPatternTimingLink? link)
    {
        var value = TimeSpan.Zero;

        if (link is { RunTime: not null })
        {
            value = value.Add(XmlConvert.ToTimeSpan(link.RunTime));
        }

        return value;
    }
    
    public static TimeSpan GetWaitTime(TransXChangeTo? to, TransXChangeFrom? from)
    {
        var value = TimeSpan.Zero;

        if (to is { WaitTime: not null })
        {
            value = value.Add(XmlConvert.ToTimeSpan(to.WaitTime));
        }

        if (from is { WaitTime: not null })
        {
            value = value.Add(XmlConvert.ToTimeSpan(from.WaitTime));
        }
        
        return value;
    }
}