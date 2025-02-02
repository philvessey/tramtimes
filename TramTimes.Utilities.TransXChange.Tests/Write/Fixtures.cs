using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using TramTimes.Utilities.TransXChange.Models;

namespace TramTimes.Utilities.TransXChange.Tests.Write;

public class BlackpoolFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/Blackpool/Data/feed.zip", Naptan.Build("Write/Blackpool/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class DocklandsFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/Docklands/Data/feed.zip", Naptan.Build("Write/Docklands/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class EdinburghFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/Edinburgh/Data/feed.zip", Naptan.Build("Write/Edinburgh/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class GlasgowFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/Glasgow/Data/feed.zip", Naptan.Build("Write/Glasgow/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class LondonFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/London/Data/feed.zip", Naptan.Build("Write/London/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class ManchesterFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/Manchester/Data/feed.zip", Naptan.Build("Write/Manchester/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class NottinghamFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/Nottingham/Data/feed.zip", Naptan.Build("Write/Nottingham/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class SouthYorkshireFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
    
    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/SouthYorkshire/Data/feed.zip", Naptan.Build("Write/SouthYorkshire/Data/feed.zip"), 
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class TyneWearFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/TyneWear/Data/feed.zip", Naptan.Build("Write/TyneWear/Data/feed.zip"),
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}

public class WestMidlandsFixture
{
    [UsedImplicitly]
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

    [UsedImplicitly]
    public Dictionary<string, TransXChangeSchedule> Schedules { get; } = TransXChange.Build("Write/WestMidlands/Data/feed.zip", Naptan.Build("Write/WestMidlands/Data/feed.zip"),
        "GB-ENG", "all", ["all"], 7, "28/01/25", Configuration["key"]);
}