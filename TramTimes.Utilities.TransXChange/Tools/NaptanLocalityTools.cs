using System.Globalization;
using System.IO.Compression;
using CsvHelper;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tools;

public static class NaptanLocalityTools
{
    public static Dictionary<string, NaptanLocality> GetFromArchive(string path)
    {
        Dictionary<string, NaptanLocality> results = [];
        using var archive = ZipFile.Open(path, ZipArchiveMode.Read);

        foreach (var entry in archive.Entries)
        {
            if (!entry.Name.Contains("localities.csv", StringComparison.CurrentCultureIgnoreCase))
            {
                continue;
            }
                
            using StreamReader reader = new(entry.Open());
            var records = new CsvReader(reader, CultureInfo.InvariantCulture).GetRecords<NaptanLocality>();

            foreach (var record in records)
            {
                if (record.NptgLocalityCode != null)
                {
                    _ = results.TryAdd(record.NptgLocalityCode, record);
                }
            }
        }
        
        return results;
    }
    
    public static Dictionary<string, NaptanLocality> GetFromDirectory(string path)
    {
        Dictionary<string, NaptanLocality> results = [];
        var entries = Directory.GetFiles(path);

        foreach (var entry in entries)
        {
            if (!entry.Contains("localities.csv", StringComparison.CurrentCultureIgnoreCase))
            {
                continue;
            }
                
            using StreamReader reader = new(entry);
            var records = new CsvReader(reader, CultureInfo.InvariantCulture).GetRecords<NaptanLocality>();

            foreach (var record in records)
            {
                if (record.NptgLocalityCode != null)
                {
                    _ = results.TryAdd(record.NptgLocalityCode, record);
                }
            }
        }
        
        return results;
    }
}