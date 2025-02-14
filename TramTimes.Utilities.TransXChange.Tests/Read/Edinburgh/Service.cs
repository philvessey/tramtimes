using System.Globalization;
using NextDepartures.Standard;
using NextDepartures.Standard.Types;
using NextDepartures.Storage.GTFS;
using TramTimes.Utilities.TransXChange.Helpers;
using Xunit;

namespace TramTimes.Utilities.TransXChange.Tests.Read.Edinburgh;

[Collection("read_edinburgh")]
public class Service(EdinburghFixture fixture)
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
    [InlineData("9400ZZEDAIR", "28/01/2025 07:00", new[] { "28/01/2025 07:07:00", "28/01/2025 07:15:00", "28/01/2025 07:22:00" })]
    [InlineData("9400ZZEDBAN", "29/01/2025 09:00", new[] { "29/01/2025 09:02:00", "29/01/2025 09:06:00", "29/01/2025 09:09:00" })]
    [InlineData("9400ZZEDHAY", "30/01/2025 11:00", new[] { "30/01/2025 11:02:00", "30/01/2025 11:06:00", "30/01/2025 11:10:00" })]
    [InlineData("9400ZZEDMUR", "31/01/2025 13:00", new[] { "31/01/2025 13:02:00", "31/01/2025 13:06:00", "31/01/2025 13:10:00" })]
    [InlineData("9400ZZEDPKS", "01/02/2025 15:00", new[] { "01/02/2025 15:03:00", "01/02/2025 15:05:00", "01/02/2025 15:10:00" })]
    [InlineData("9400ZZEDSAU", "02/02/2025 17:00", new[] { "02/02/2025 17:02:00", "02/02/2025 17:06:00", "02/02/2025 17:09:00" })]
    [InlineData("9400ZZEDSTA", "03/02/2025 19:00", new[] { "03/02/2025 19:05:00", "03/02/2025 19:05:00", "03/02/2025 19:12:00" })]
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