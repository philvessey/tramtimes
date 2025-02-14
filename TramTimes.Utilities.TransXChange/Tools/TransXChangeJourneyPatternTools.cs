using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TransXChangeJourneyPatternTools
{
    public static TransXChangeJourneyPattern GetJourneyPattern(TransXChangeServices? services, string? reference)
    {
        return services?.Service?.StandardService?.JourneyPattern?.FirstOrDefault(pattern =>
            pattern.Id == reference) ?? new TransXChangeJourneyPattern();
    }
    
    public static List<TransXChangeJourneyPatternTimingLink> GetTimingLinks(TransXChangeJourneyPatternSections? patternSections, List<string>? references)
    {
        return references?.SelectMany(reference =>
            patternSections?.JourneyPatternSection?.FirstOrDefault(pattern =>
                pattern.Id == reference)?.JourneyPatternTimingLink ?? []).ToList() ?? [];
    }
}