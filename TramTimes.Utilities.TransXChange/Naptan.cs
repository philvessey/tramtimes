using System.Globalization;
using System.IO.Compression;
using CsvHelper;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange;

public abstract class Naptan
{
    public static Dictionary<string, NaptanStop> Build(string path)
    {
        return path.EndsWith(".zip") ? ReturnStopsFromArchive(path) : ReturnStopsFromDirectory(path);
    }
    
    private static Dictionary<string, NaptanStop> ReturnStopsFromArchive(string path)
    {
        Dictionary<string, NaptanStop> results = [];
        using var archive = ZipFile.Open(path, ZipArchiveMode.Read);

        foreach (var entry in archive.Entries)
        {
            if (!entry.Name.EndsWith("csv", StringComparison.CurrentCultureIgnoreCase)) continue;
                
            using StreamReader reader = new(entry.Open());
            var records = new CsvReader(reader, CultureInfo.InvariantCulture).GetRecords<NaptanStop>();

            foreach (var record in records)
            {
                if (!string.IsNullOrEmpty(record.AtcoCode))
                {
                    _ = results.TryAdd(record.AtcoCode, record);
                }
            }
        }
        
        return results;
    }
    
    private static Dictionary<string, NaptanStop> ReturnStopsFromDirectory(string path)
    {
        Dictionary<string, NaptanStop> results = [];
        var entries = Directory.GetFiles(path);

        foreach (var entry in entries)
        {
            if (!entry.EndsWith("csv", StringComparison.CurrentCultureIgnoreCase)) continue;
                
            using StreamReader reader = new(entry);
            var records = new CsvReader(reader, CultureInfo.InvariantCulture).GetRecords<NaptanStop>();

            foreach (var record in records)
            {
                if (!string.IsNullOrEmpty(record.AtcoCode))
                {
                    _ = results.TryAdd(record.AtcoCode, record);
                }
            }
        }
        
        return results;
    }
}