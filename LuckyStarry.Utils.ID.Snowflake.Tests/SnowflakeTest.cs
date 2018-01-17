using System;
using Xunit;

namespace LuckyStarry.Utils.ID.Snowflake.Tests
{
    public class SnowflakeTest
    {
        [Fact]
        public void LuckyStarrySnowflakeTest()
        {
            const string api = "https://api.sonhaku.com/id";
            var client = new SnowflakeApiIdentifierUtils(api);
            var identifier = client.New();
            Assert.NotNull(identifier);
            Assert.True(identifier.Value > 0);
        }
    }
}
