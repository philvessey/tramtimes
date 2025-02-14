using System.Globalization;
using System.IO.Compression;
using CsvHelper;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class NaptanStopTools
{
    public static Dictionary<string, NaptanStop> GetFromArchive(string path)
    {
        Dictionary<string, NaptanStop> results = [];
        using var archive = ZipFile.Open(path, ZipArchiveMode.Read);

        foreach (var entry in archive.Entries)
        {
            if (!entry.Name.Contains("stops.csv", StringComparison.CurrentCultureIgnoreCase))
            {
                continue;
            }
                
            using StreamReader reader = new(entry.Open());
            var records = new CsvReader(reader, CultureInfo.InvariantCulture).GetRecords<NaptanStop>();

            foreach (var record in records)
            {
                if (record.AtcoCode != null)
                {
                    _ = results.TryAdd(record.AtcoCode, record);
                }
            }
        }
        
        return results;
    }
    
    public static Dictionary<string, NaptanStop> GetFromDirectory(string path)
    {
        Dictionary<string, NaptanStop> results = [];
        var entries = Directory.GetFiles(path);

        foreach (var entry in entries)
        {
            if (!entry.Contains("stops.csv", StringComparison.CurrentCultureIgnoreCase))
            {
                continue;
            }
                
            using StreamReader reader = new(entry);
            var records = new CsvReader(reader, CultureInfo.InvariantCulture).GetRecords<NaptanStop>();

            foreach (var record in records)
            {
                if (record.AtcoCode != null)
                {
                    _ = results.TryAdd(record.AtcoCode, record);
                }
            }
        }
        
        return results;
    }
}