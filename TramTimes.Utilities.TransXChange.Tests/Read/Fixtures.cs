using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tests.Read;

public class BlackpoolFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/Blackpool/Data/feed.zip", 
        Naptan.Build("Read/Blackpool/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class DocklandsFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/Docklands/Data/feed.zip", 
        Naptan.Build("Read/Docklands/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class EdinburghFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/Edinburgh/Data/feed.zip", 
        Naptan.Build("Read/Edinburgh/Data/feed.zip"), "GB-SCT", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class GlasgowFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/Glasgow/Data/feed.zip", 
        Naptan.Build("Read/Glasgow/Data/feed.zip"), "GB-SCT", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class LondonFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/London/Data/feed.zip", 
        Naptan.Build("Read/London/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class ManchesterFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/Manchester/Data/feed.zip", 
        Naptan.Build("Read/Manchester/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class NottinghamFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/Nottingham/Data/feed.zip", 
        Naptan.Build("Read/Nottingham/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class SouthYorkshireFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/SouthYorkshire/Data/feed.zip", 
        Naptan.Build("Read/SouthYorkshire/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class TyneWearFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/TyneWear/Data/feed.zip", 
        Naptan.Build("Read/TyneWear/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}

public class WestMidlandsFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

    [UsedImplicitly]
    public Dictionary<string, TravelineSchedule> Schedules { get; } = TransXChange.Build("Read/WestMidlands/Data/feed.zip", 
        Naptan.Build("Read/WestMidlands/Data/feed.zip"), "GB-ENG", "all", ["all"], "28/01/2025", 
        Configuration["key"]);
}