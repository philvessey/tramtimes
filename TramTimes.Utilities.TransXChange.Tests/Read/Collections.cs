using Xunit;

namespace TramTimes.Utilities.TransXChange.Tests.Read;

[CollectionDefinition("read_blackpool")]
public class BlackpoolCollection : ICollectionFixture<BlackpoolFixture>;

[CollectionDefinition("read_docklands")]
public class DocklandsCollection : ICollectionFixture<DocklandsFixture>;

[CollectionDefinition("read_edinburgh")]
public class EdinburghCollection : ICollectionFixture<EdinburghFixture>;

[CollectionDefinition("read_glasgow")]
public class GlasgowCollection : ICollectionFixture<GlasgowFixture>;

[CollectionDefinition("read_london")]
public class LondonCollection : ICollectionFixture<LondonFixture>;

[CollectionDefinition("read_manchester")]
public class ManchesterCollection : ICollectionFixture<ManchesterFixture>;

[CollectionDefinition("read_nottingham")]
public class NottinghamCollection : ICollectionFixture<NottinghamFixture>;

[CollectionDefinition("read_south_yorkshire")]
public class SouthYorkshireCollection : ICollectionFixture<SouthYorkshireFixture>;

[CollectionDefinition("read_tyne_wear")]
public class TyneWearCollection : ICollectionFixture<TyneWearFixture>;

[CollectionDefinition("read_west_midlands")]
public class WestMidlandsCollection : ICollectionFixture<WestMidlandsFixture>;