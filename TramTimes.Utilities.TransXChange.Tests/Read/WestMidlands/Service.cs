using System.Globalization;
using NextDepartures.Standard;
using NextDepartures.Standard.Types;
using NextDepartures.Storage.GTFS;
using TramTimes.Utilities.TransXChange.Helpers;
using Xunit;

namespace TramTimes.Utilities.TransXChange.Tests.Read.WestMidlands;

[Collection("read_west_midlands")]
public class Service(WestMidlandsFixture fixture)
{
    [Fact]
    public void Fixtures_Build_Pass()
    {
        var storage = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
        
        try
        {
            Assert.NotEmpty(fixture.Schedules);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        finally
        {
            storage.Delete(true);
        }
    }
    
    [Fact]
    public void Helpers_Build_Pass()
    {
        var storage = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));

        try
        {
            Assert.True(File.Exists(GtfsAgencyHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsCalendarHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsCalendarDateHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsRouteHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsStopHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsStopTimeHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsTripHelpers.Build(fixture.Schedules, storage.FullName)));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        finally
        {
            storage.Delete(true);
        }
    }
    
    [Theory]
    [InlineData("9400ZZWMST", "28/01/2025 07:00", new[] { "28/01/2025 07:01:00", "28/01/2025 07:03:00", "28/01/2025 07:09:00" })]
    [InlineData("9400ZZWMTR", "29/01/2025 09:00", new[] { "29/01/2025 09:04:00", "29/01/2025 09:05:00", "29/01/2025 09:12:00" })]
    [InlineData("9400ZZWMWB", "30/01/2025 11:00", new[] { "30/01/2025 11:03:00", "30/01/2025 11:06:00", "30/01/2025 11:11:00" })]
    [InlineData("9400ZZWMWI", "31/01/2025 13:00", new[] { "31/01/2025 13:02:00", "31/01/2025 13:07:00", "31/01/2025 13:10:00" })]
    [InlineData("9400ZZWMWP", "01/02/2025 15:00", new[] { "01/02/2025 15:02:00", "01/02/2025 15:06:00", "01/02/2025 15:10:00" })]
    [InlineData("9400ZZWMRO", "02/02/2025 17:00", new[] { "02/02/2025 17:02:00", "02/02/2025 17:06:00", "02/02/2025 17:14:00" })]
    [InlineData("9400ZZWMWW", "03/02/2025 19:00", new[] { "03/02/2025 19:02:00", "03/02/2025 19:05:00", "03/02/2025 19:10:00" })]
    public async Task Search_Feed_Pass(string id, string target, string[] expected)
    {
        var storage = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));

        try
        {
            Assert.True(File.Exists(GtfsAgencyHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsCalendarHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsCalendarDateHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsRouteHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsStopHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsStopTimeHelpers.Build(fixture.Schedules, storage.FullName)));
            Assert.True(File.Exists(GtfsTripHelpers.Build(fixture.Schedules, storage.FullName)));
            
            var feed = await Feed.Load(GtfsStorage.Load(storage.FullName));
            var results = await feed.GetServicesByStopAsync(id, DateTime.ParseExact(target, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture), TimeSpan.Zero, ComparisonType.Partial);
            
            Assert.Equal(DateTime.ParseExact(expected.ElementAt(0), "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture), results.ElementAt(0).DepartureDateTime);
            Assert.Equal(DateTime.ParseExact(expected.ElementAt(1), "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture), results.ElementAt(1).DepartureDateTime);
            Assert.Equal(DateTime.ParseExact(expected.ElementAt(2), "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture), results.ElementAt(2).DepartureDateTime);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        finally
        {
            storage.Delete(true);
        }
    }
}