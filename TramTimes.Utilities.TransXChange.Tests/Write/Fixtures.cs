using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using TramTimes.Utilities.TransXChange.Models;
using TramTimes.Utilities.TransXChange.Tools;

namespace TramTimes.Utilities.TransXChange.Tests.Write;

public class BlackpoolFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/Blackpool/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}

public class DocklandsFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/Docklands/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}

public class EdinburghFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/Edinburgh/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-SCT", "28/01/2025", Configuration["key"]);
}

public class GlasgowFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/Glasgow/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-SCT", "28/01/2025", Configuration["key"]);
}

public class LondonFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/London/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}

public class ManchesterFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/Manchester/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}

public class NottinghamFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/Nottingham/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}

public class SouthYorkshireFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/SouthYorkshire/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}

public class TyneWearFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/TyneWear/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}

public class WestMidlandsFixture
{
    [UsedImplicitly]
    private static string Path { get; } = "Write/WestMidlands/Data/feed.zip";
    
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build(Path, NaptanLocalityTools.GetFromArchive(Path), 
        NaptanStopTools.GetFromArchive(Path), "GB-ENG", "28/01/2025", Configuration["key"]);
}