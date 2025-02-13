using System.Globalization;
using GeoUK;
using GeoUK.Coordinates;
using GeoUK.Ellipsoids;
using GeoUK.Projections;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TravelineStopHelpers
{
    public static TravelineStop Build(Dictionary<string, NaptanLocality> localities, TransXChangeStopPoints? stopPoints, string? reference)
    {
        var stopPoint = stopPoints?.StopPoint?.FirstOrDefault(p => p.AtcoCode == reference);
        
        if (!localities.TryGetValue(stopPoint?.Place?.NptgLocalityRef ?? "unknown", out var locality))
        {
            return new TravelineStop
            {
                AtcoCode = reference ?? "unknown"
            };
        }
        
        var value = new TravelineStop
        {
            AtcoCode = reference ?? "unknown",
            CommonName = stopPoint?.Descriptor?.CommonName,
            ShortCommonName = stopPoint?.Descriptor?.ShortCommonName,
            Landmark = stopPoint?.Descriptor?.Landmark,
            Street = stopPoint?.Descriptor?.Street,
            Crossing = stopPoint?.Descriptor?.Crossing,
            Indicator = stopPoint?.Descriptor?.Indicator,
            NptgLocalityCode = stopPoint?.Place?.NptgLocalityRef,
            LocalityName = locality.LocalityName,
            ParentLocalityName = locality.ParentLocalityName,
            GridType = locality.GridType,
            Easting = stopPoint?.Place?.Location?.Easting,
            Northing = stopPoint?.Place?.Location?.Northing,
            StopType = stopPoint?.StopClassification?.StopType,
            AdministrativeAreaCode = stopPoint?.AdministrativeAreaRef
        };
        
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