using System.Globalization;
using GeoUK;
using GeoUK.Coordinates;
using GeoUK.Ellipsoids;
using GeoUK.Projections;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class NaptanStopHelpers
{
    public static NaptanStop Build(Dictionary<string, NaptanStop> stops, string reference, string commonName, string localityName)
    {
        NaptanStop result = new()
        {
            AtcoCode = reference,
            CommonName = commonName,
            LocalityName = localityName
        };

        if (!stops.TryGetValue(reference, out var value)) return result;
        
        result = value;

        if (string.IsNullOrEmpty(result.Easting) || string.IsNullOrEmpty(result.Northing)) return result;
        
        var coordinates = GeoUK.Convert.ToLatitudeLongitude(new Wgs84(),
            Transform.Osgb36ToEtrs89(GeoUK.Convert.ToCartesian(new Airy1830(),
                new BritishNationalGrid(),
                new EastingNorthing(double.Parse(result.Easting), double.Parse(result.Northing)))));
        
        result.Longitude = coordinates.Longitude.ToString(CultureInfo.InvariantCulture);
        result.Latitude = coordinates.Latitude.ToString(CultureInfo.InvariantCulture);

        return result;
    }
}