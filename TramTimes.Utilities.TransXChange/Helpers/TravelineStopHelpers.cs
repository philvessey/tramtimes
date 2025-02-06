using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TravelineStopHelpers
{
    public static TravelineStop Build(string reference, string commonName, string localityName)
    {
        return new TravelineStop
        {
            StopPointReference = reference,
            CommonName = commonName,
            LocalityName = localityName
        };
    }
}