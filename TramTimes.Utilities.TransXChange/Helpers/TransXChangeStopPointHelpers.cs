using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class TransXChangeStopPointHelpers
{
    public static TransXChangeStopPoint Build(Dictionary<string, NaptanStop> stops, TransXChangeAnnotatedStopPointRef stopPoint)
    {
        return new TransXChangeStopPoint
        {
            AtcoCode = stopPoint.StopPointRef,
            
            NaptanStop = NaptanStopHelpers.Build(stops,
                stopPoint.StopPointRef ?? "Unknown NaPTAN Reference",
                stopPoint.CommonName ?? "Unknown NaPTAN Stop",
                stopPoint.LocalityName ?? "Unknown NaPTAN Locality"),
            
            TransXChangeStop = TransXChangeStopHelpers.Build(
                stopPoint.StopPointRef ?? "Unknown TransXChange Reference",
                stopPoint.CommonName ?? "Unknown TransXChange Stop",
                stopPoint.LocalityName ?? "Unknown TransXChange Locality")
        };
    }

    public static bool ReturnFilterMatch(IList<string> filters, TravelineSchedule schedule)
    {
        if (schedule.StopPoints == null) return false;
        
        foreach (var point in schedule.StopPoints)
        {
            if (point.NaptanStop != null)
            {
                if (!string.IsNullOrEmpty(point.NaptanStop.StopType))
                {
                    if (!filters.Contains("all"))
                    {
                        foreach (var filter in filters)
                        {
                            if (!string.IsNullOrEmpty(point.NaptanStop.AtcoCode) &&
                                point.NaptanStop.AtcoCode.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                            {
                                return true;
                            }

                            if (!string.IsNullOrEmpty(point.NaptanStop.CommonName) &&
                                point.NaptanStop.CommonName.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                            {
                                return true;
                            }

                            if (!string.IsNullOrEmpty(point.NaptanStop.LocalityName) &&
                                point.NaptanStop.LocalityName.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            if (point.TransXChangeStop == null) continue;
            
            if (!filters.Contains("all"))
            {
                foreach (var filter in filters)
                {
                    if (!string.IsNullOrEmpty(point.TransXChangeStop.StopPointReference) &&
                        point.TransXChangeStop.StopPointReference.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return true;
                    }

                    if (!string.IsNullOrEmpty(point.TransXChangeStop.CommonName) &&
                        point.TransXChangeStop.CommonName.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return true;
                    }

                    if (!string.IsNullOrEmpty(point.TransXChangeStop.LocalityName) &&
                        point.TransXChangeStop.LocalityName.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
        }
            
        return false;
    }
    
    public static bool ReturnModeMatch(string mode, TravelineSchedule schedule)
    {
        if (schedule.StopPoints == null) return false;
        
        foreach (var point in schedule.StopPoints)
        {
            if (mode != "all")
            {
                switch (mode)
                {
                    case "bus":
                    {
                        if (point.NaptanStop != null)
                        {
                            if (!string.IsNullOrEmpty(point.NaptanStop.StopType))
                            {
                                if (point.NaptanStop.StopType is "BCS" or "BCT")
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }

                        break;
                    }
                    case "city-rail":
                    {
                        if (point.NaptanStop != null)
                        {
                            if (!string.IsNullOrEmpty(point.NaptanStop.StopType))
                            {
                                if (point.NaptanStop.StopType == "RLY")
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }

                        break;
                    }
                    case "ferry":
                    {
                        if (point.NaptanStop != null)
                        {
                            if (!string.IsNullOrEmpty(point.NaptanStop.StopType))
                            {
                                if (point.NaptanStop.StopType == "FBT")
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }

                        break;
                    }
                    case "light-rail":
                    {
                        if (point.NaptanStop != null)
                        {
                            if (!string.IsNullOrEmpty(point.NaptanStop.StopType))
                            {
                                if (point.NaptanStop.StopType == "PLT")
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }

                        break;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}