using System.Globalization;
using CsvHelper;
using TramTimes.Utilities.TransXChange.Extensions;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Helpers;

public static class GtfsStopHelpers
{
    public static string Build(Dictionary<string, TravelineSchedule> schedules, string path)
    {
        var results = ReturnStopsFromSchedules(schedules);

        using StreamWriter writer = new(Path.Combine(path, "stops.txt"));
        using CsvWriter csv = new(writer, CultureInfo.InvariantCulture);

        csv.WriteHeader<GtfsStop>();
        csv.NextRecord();

        foreach (var value in results.Values)
        {
            csv.WriteRecord(value);
            csv.NextRecord();
        }
        
        return Path.Combine(path, "stops.txt");
    }

    private static Dictionary<string, GtfsStop> ReturnStopsFromSchedules(Dictionary<string, TravelineSchedule> schedules)
    {
        var results = new Dictionary<string, GtfsStop>();
        
        foreach (var value in schedules.Values)
        {
            GtfsCalendar calendar = new()
            {
                StartDate = $"{value.Calendar?.StartDate?.ToString("yyyy")}{value.Calendar?.StartDate?.ToString("MM")}{value.Calendar?.StartDate?.ToString("dd")}",
                EndDate = $"{value.Calendar?.EndDate?.ToString("yyyy")}{value.Calendar?.EndDate?.ToString("MM")}{value.Calendar?.EndDate?.ToString("dd")}",
                Monday = value.Calendar is { Monday: not null } ? value.Calendar.Monday.ToInt().ToString() : "0",
                Tuesday = value.Calendar is { Tuesday: not null } ? value.Calendar.Tuesday.ToInt().ToString() : "0",
                Wednesday = value.Calendar is { Wednesday: not null } ? value.Calendar.Wednesday.ToInt().ToString() : "0",
                Thursday = value.Calendar is { Thursday: not null } ? value.Calendar.Thursday.ToInt().ToString() : "0",
                Friday = value.Calendar is { Friday: not null } ? value.Calendar.Friday.ToInt().ToString() : "0",
                Saturday = value.Calendar is { Saturday: not null } ? value.Calendar.Saturday.ToInt().ToString() : "0",
                Sunday = value.Calendar is { Sunday: not null } ? value.Calendar.Sunday.ToInt().ToString() : "0"
            };

            if (value.Calendar is { StartDate: not null, EndDate: not null })
            {
                calendar.ServiceId = $"{value.ServiceCode}" +
                                     $"-" +
                                     $"{value.Calendar?.Monday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Tuesday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Wednesday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Thursday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Friday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Saturday.ToInt().ToString()}" +
                                     $"{value.Calendar?.Sunday.ToInt().ToString()}" +
                                     $"-" +
                                     $"{value.Calendar?.StartDate.Value:yyyy}" +
                                     $"{value.Calendar?.StartDate.Value:MM}" +
                                     $"{value.Calendar?.StartDate.Value:dd}" +
                                     $"{value.Calendar?.EndDate.Value:yyyy}" +
                                     $"{value.Calendar?.EndDate.Value:MM}" +
                                     $"{value.Calendar?.EndDate.Value:dd}";
            }

            for (var i = 0; i < value.StopPoints?.Count; i++)
            {
                GtfsStop stop = new()
                {
                    StopTimezone = "Europe/London"
                };

                var stopId = string.Empty;
                
                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        stopId = value.StopPoints[i].NaptanStop?.AtcoCode ?? string.Empty;
                    }
                }
                else if (value.StopPoints[i].TransXChangeStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].TransXChangeStop?.StopPointReference))
                    {
                        stopId = value.StopPoints[i].TransXChangeStop?.StopPointReference ?? string.Empty;
                    }
                }

                var stopCode = string.Empty;

                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        stopCode = value.StopPoints[i].NaptanStop?.NaptanCode ?? string.Empty;
                    }
                }

                var stopName = string.Empty;
                
                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        stopName = value.StopPoints[i].NaptanStop?.CommonName ?? string.Empty;
                    }
                }
                else if (value.StopPoints[i].TransXChangeStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].TransXChangeStop?.CommonName))
                    {
                        stopName = value.StopPoints[i].TransXChangeStop?.CommonName ?? string.Empty;
                    }
                }

                var stopDesc = string.Empty;
                
                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        stopDesc = value.StopPoints[i].NaptanStop?.LocalityName ?? string.Empty;
                    }
                }
                else if (value.StopPoints[i].TransXChangeStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].TransXChangeStop?.LocalityName))
                    {
                        stopDesc = value.StopPoints[i].TransXChangeStop?.LocalityName ?? string.Empty;
                    }
                }

                var stopLat = string.Empty;

                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        stopLat = value.StopPoints[i].NaptanStop?.Latitude ?? string.Empty;
                    }
                }

                var stopLon = string.Empty;

                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        stopLon = value.StopPoints[i].NaptanStop?.Longitude ?? string.Empty;
                    }
                }

                var locationType = string.Empty;

                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        locationType = value.StopPoints[i].NaptanStop?.StopType switch
                        {
                            "BST" or "FER" or "GAT" or "LCB" or "MET" or "RLY" => "1",
                            "AIR" or "BCE" or "FTD" or "LSE" or "RSE" or "TMU" => "2",
                            _ => "0"
                        };
                    }
                }

                var wheelchairBoarding = string.Empty;

                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        wheelchairBoarding = value.StopPoints[i].NaptanStop?.StopType is "PLT" or "RPL" ? "1" : "0";
                    }
                }

                var platformCode = string.Empty;

                if (value.StopPoints[i].NaptanStop != null)
                {
                    if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.StopType))
                    {
                        switch (value.StopPoints[i].NaptanStop?.StopType)
                        {
                            case "BCS":
                            case "BCQ":
                            {
                                if (!string.IsNullOrEmpty(value.StopPoints[i].NaptanStop?.Indicator))
                                {
                                    if (value.StopPoints[i].NaptanStop?.Indicator?.StartsWith("bay", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.Indicator?.ToLower().Split(" ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.Indicator?.StartsWith("stance", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.Indicator?.ToLower().Split(" ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.Indicator?.StartsWith("stand", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.Indicator?.ToLower().Split(" ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.Indicator?.StartsWith("stop", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.Indicator?.ToLower().Split(" ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.CommonName?.Contains('/', StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.CommonName?.ToLower().Split("/").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.CommonName?.Contains("bay ", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.CommonName?.ToLower().Split("bay ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.CommonName?.Contains("stance ", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.CommonName?.ToLower().Split("stance ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.CommonName?.Contains("stand ", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.CommonName?.ToLower().Split("stand ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                    else if (value.StopPoints[i].NaptanStop?.CommonName?.Contains("stop ", StringComparison.CurrentCultureIgnoreCase) ?? false)
                                    {
                                        platformCode = value.StopPoints[i].NaptanStop?.CommonName?.ToLower().Split("stop ").LastOrDefault()?.Trim() ?? string.Empty;
                                    }
                                }

                                break;
                            }
                            case "LPL":
                            case "PLT":
                            case "RPL":
                            {
                                platformCode = value.StopPoints[i].NaptanStop?.AtcoCode?[^1..] ?? string.Empty;
                                
                                break;
                            }
                        }
                    }
                }

                stop.StopId = stopId;
                stop.StopCode = stopCode;
                stop.StopName = stopName;
                stop.StopDesc = stopDesc;
                stop.StopLat = stopLat;
                stop.StopLon = stopLon;
                stop.LocationType = locationType;
                stop.WheelchairBoarding = wheelchairBoarding;
                stop.PlatformCode = platformCode;

                if (!string.IsNullOrEmpty(stop.StopId))
                {
                    _ = results.TryAdd(stop.StopId, stop);
                }
            }
        }
        
        return results.OrderBy(s =>
            s.Value.StopId).ToDictionary(s =>
            s.Key, s =>
            s.Value);
    }
}