using Xunit;

namespace BassVisAPI.Net.Tests
{
    public class BassVisTests
    {
        [Fact]
        public void TestGetVersion()
        {
            var version = BassVis.GetVersion();
            Assert.NotNull(version);
            Assert.Equal("2.4.4.1", version);
        }
    }
}