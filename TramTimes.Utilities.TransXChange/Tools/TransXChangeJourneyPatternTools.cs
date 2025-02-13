using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class TransXChangeJourneyPatternTools
{
    public static TransXChangeJourneyPattern GetJourneyPattern(TransXChangeServices? services, TransXChangeVehicleJourney? vehicleJourney)
    {
        return services?.Service?.StandardService?.JourneyPattern?.FirstOrDefault(p =>
            p.Id == vehicleJourney?.JourneyPatternRef) ?? services?.Service?.StandardService?.JourneyPattern?.FirstOrDefault() ?? new TransXChangeJourneyPattern();
    }
    
    public static List<TransXChangeJourneyPatternTimingLink> GetTimingLinks(TransXChangeJourneyPatternSections? patternSections, TransXChangeJourneyPattern? journeyPattern)
    {
        return patternSections?.JourneyPatternSection?.FirstOrDefault(p =>
            journeyPattern?.JourneyPatternSectionRefs?.Contains(p.Id ?? "unknown") == true)?.JourneyPatternTimingLink ?? [];
    }
}