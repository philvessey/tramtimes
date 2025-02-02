using Xunit;

namespace TramTimes.Utilities.TransXChange.Tests.Write;

[CollectionDefinition("write_blackpool")]
public class BlackpoolCollection : ICollectionFixture<BlackpoolFixture>;

[CollectionDefinition("write_docklands")]
public class DocklandsCollection : ICollectionFixture<DocklandsFixture>;

[CollectionDefinition("write_edinburgh")]
public class EdinburghCollection : ICollectionFixture<EdinburghFixture>;

[CollectionDefinition("write_glasgow")]
public class GlasgowCollection : ICollectionFixture<GlasgowFixture>;

[CollectionDefinition("write_london")]
public class LondonCollection : ICollectionFixture<LondonFixture>;

[CollectionDefinition("write_manchester")]
public class ManchesterCollection : ICollectionFixture<ManchesterFixture>;

[CollectionDefinition("write_nottingham")]
public class NottinghamCollection : ICollectionFixture<NottinghamFixture>;

[CollectionDefinition("write_south_yorkshire")]
public class SouthYorkshireCollection : ICollectionFixture<SouthYorkshireFixture>;

[CollectionDefinition("write_tyne_wear")]
public class TyneWearCollection : ICollectionFixture<TyneWearFixture>;

[CollectionDefinition("write_west_midlands")]
public class WestMidlandsCollection : ICollectionFixture<WestMidlandsFixture>;