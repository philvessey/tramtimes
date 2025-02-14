using System.Globalization;
using NextDepartures.Standard;
using NextDepartures.Standard.Types;
using NextDepartures.Storage.GTFS;
using TramTimes.Utilities.TransXChange.Helpers;
using Xunit;

namespace TramTimes.Utilities.TransXChange.Tests.Read.TyneWear;

[Collection("read_tyne_wear")]
public class Service(TyneWearFixture fixture)
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
    [InlineData("9400ZZTWBDE", "28/01/2025 07:00", new[] { "28/01/2025 07:04:00", "28/01/2025 07:05:00", "28/01/2025 07:16:00" })]
    [InlineData("9400ZZTWCST", "29/01/2025 09:00", new[] { "29/01/2025 09:04:00", "29/01/2025 09:05:00", "29/01/2025 09:10:00" })]
    [InlineData("9400ZZTWFLE", "30/01/2025 11:00", new[] { "30/01/2025 11:02:30", "30/01/2025 11:07:00", "30/01/2025 11:14:30" })]
    [InlineData("9400ZZTWJMD", "31/01/2025 13:00", new[] { "31/01/2025 13:04:00", "31/01/2025 13:05:00", "31/01/2025 13:10:00" })]
    [InlineData("9400ZZTWMFD", "01/02/2025 15:00", new[] { "01/02/2025 15:02:30", "01/02/2025 15:06:00", "01/02/2025 15:14:30" })]
    [InlineData("9400ZZTWMMT", "02/02/2025 17:00", new[] { "02/02/2025 17:02:00", "02/02/2025 17:03:00", "02/02/2025 17:05:30" })]
    [InlineData("9400ZZTWPLN", "03/02/2025 19:00", new[] { "03/02/2025 19:08:30", "03/02/2025 19:10:30", "03/02/2025 19:23:30" })]
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