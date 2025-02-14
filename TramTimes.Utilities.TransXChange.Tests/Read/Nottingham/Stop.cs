using NextDepartures.Standard;
using NextDepartures.Storage.GTFS;
using TramTimes.Utilities.TransXChange.Helpers;
using Xunit;

namespace TramTimes.Utilities.TransXChange.Tests.Read.Nottingham;

[Collection("read_nottingham")]
public class Stop(NottinghamFixture fixture)
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
    [InlineData("9400ZZNOBCF", true)]
    [InlineData("9400ZZNOBLV", true)]
    [InlineData("9400ZZNODVL", true)]
    [InlineData("9400ZZNOHBV", true)]
    [InlineData("9400ZZNOMDW", true)]
    [InlineData("9400ZZNOOMS", true)]
    [InlineData("9400ZZNORDF", true)]
    public async Task Search_Feed_Pass(string id, bool expected)
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
            var results = await feed.GetStopsByIdAsync(id);
            
            Assert.Equal(expected, results.Count > 0);
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