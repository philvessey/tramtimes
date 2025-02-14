using System.Globalization;
using NextDepartures.Standard;
using NextDepartures.Standard.Types;
using NextDepartures.Storage.GTFS;
using TramTimes.Utilities.TransXChange.Helpers;
using Xunit;

namespace TramTimes.Utilities.TransXChange.Tests.Read.Glasgow;

[Collection("read_glasgow")]
public class Service(GlasgowFixture fixture)
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
    [InlineData("9400ZZGLBRI", "28/01/2025 07:00", new[] { "28/01/2025 07:01:00", "28/01/2025 07:05:00", "28/01/2025 07:05:00" })]
    [InlineData("9400ZZGLCES", "29/01/2025 09:00", new[] { "29/01/2025 09:00:00", "29/01/2025 09:00:00", "29/01/2025 09:01:19" })]
    [InlineData("9400ZZGLGOV", "30/01/2025 11:00", new[] { "30/01/2025 11:00:00", "30/01/2025 11:00:00", "30/01/2025 11:00:00" })]
    [InlineData("9400ZZGLIBX", "31/01/2025 13:00", new[] { "31/01/2025 13:01:25", "31/01/2025 13:02:00", "31/01/2025 13:04:00" })]
    [InlineData("9400ZZGLPRT", "01/02/2025 15:00", new[] { "01/02/2025 15:00:00", "01/02/2025 15:02:00", "01/02/2025 15:04:00" })]
    [InlineData("9400ZZGLSTE", "02/02/2025 17:00", new[] { "02/02/2025 17:01:00", "02/02/2025 17:03:00", "02/02/2025 17:04:05" })]
    [InlineData("9400ZZGLWES", "03/02/2025 19:00", new[] { "03/02/2025 19:01:53", "03/02/2025 19:02:00", "03/02/2025 19:02:00" })]
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