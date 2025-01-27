using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TransXChangeStopHelpers
{
    public static TransXChangeStop Build(string reference, string commonName, string localityName)
    {
        return new TransXChangeStop
        {
            StopPointReference = reference,
            CommonName = commonName,
            LocalityName = localityName
        };
    }
}