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
    [InlineData("9400ZZTWBDE", "28/01/2025 09:00", new[] { "28/01/2025 09:00", "28/01/2025 09:10", "28/01/2025 09:20" })]
    [InlineData("9400ZZTWCST", "29/01/2025 11:00", new[] { "29/01/2025 11:00", "29/01/2025 11:10", "29/01/2025 11:20" })]
    [InlineData("9400ZZTWFLE", "30/01/2025 13:00", new[] { "30/01/2025 13:00", "30/01/2025 13:10", "30/01/2025 13:20" })]
    [InlineData("9400ZZTWJMD", "31/01/2025 15:00", new[] { "31/01/2025 15:00", "31/01/2025 15:10", "31/01/2025 15:20" })]
    [InlineData("9400ZZTWMFD", "01/02/2025 17:00", new[] { "01/02/2025 17:00", "01/02/2025 17:10", "01/02/2025 17:20" })]
    [InlineData("9400ZZTWMMT", "02/02/2025 19:00", new[] { "02/02/2025 19:00", "02/02/2025 19:10", "02/02/2025 19:20" })]
    [InlineData("9400ZZTWPLN", "03/02/2025 21:00", new[] { "03/02/2025 21:00", "03/02/2025 21:10", "03/02/2025 21:20" })]
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
            
            Assert.Equal(DateTime.ParseExact(expected.ElementAt(0), "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture), results.ElementAt(0).DepartureDateTime);
            Assert.Equal(DateTime.ParseExact(expected.ElementAt(1), "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture), results.ElementAt(1).DepartureDateTime);
            Assert.Equal(DateTime.ParseExact(expected.ElementAt(2), "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture), results.ElementAt(2).DepartureDateTime);
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