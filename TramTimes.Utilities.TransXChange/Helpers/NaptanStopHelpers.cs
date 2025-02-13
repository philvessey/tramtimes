using System.Globalization;
using GeoUK;
using GeoUK.Coordinates;
using GeoUK.Ellipsoids;
using GeoUK.Projections;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class NaptanStopHelpers
{
    public static NaptanStop Build(Dictionary<string, NaptanStop> stops, string? reference)
    {
        if (!stops.TryGetValue(reference ?? "unknown", out var value))
        {
            return new NaptanStop
            {
                AtcoCode = reference ?? "unknown"
            };
        }

        if (string.IsNullOrEmpty(value.Easting)) return value;
        if (string.IsNullOrEmpty(value.Northing)) return value;
        
        var eastingNorthing = new EastingNorthing(double.Parse(value.Easting), double.Parse(value.Northing));
        var cartesian = GeoUK.Convert.ToCartesian(new Airy1830(), new BritishNationalGrid(), eastingNorthing);
        var coordinates = GeoUK.Convert.ToLatitudeLongitude(new Wgs84(), Transform.Osgb36ToEtrs89(cartesian));
        
        value.Longitude = coordinates.Longitude.ToString(CultureInfo.CurrentCulture);
        value.Latitude = coordinates.Latitude.ToString(CultureInfo.CurrentCulture);

        return value;
    }
}