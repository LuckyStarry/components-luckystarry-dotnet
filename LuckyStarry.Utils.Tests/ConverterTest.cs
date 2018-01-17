
using System;
using Xunit;

namespace LuckyStarry.Utils.Tests
{
    public class ConverterTest
    {
        [Fact]
        public void ToBase62Test()
        {
            Assert.Equal("0", Utils.Convert.ToBase62(0));
            Assert.Equal("-1", Utils.Convert.ToBase62(-1));
            Assert.Equal("1", Utils.Convert.ToBase62(1));
            Assert.Equal("9", Utils.Convert.ToBase62(9));
            Assert.Equal("A", Utils.Convert.ToBase62(10));
            Assert.Equal("B", Utils.Convert.ToBase62(11));
            Assert.Equal("Z", Utils.Convert.ToBase62(35));
            Assert.Equal("a", Utils.Convert.ToBase62(36));
            Assert.Equal("b", Utils.Convert.ToBase62(37));
            Assert.Equal("z", Utils.Convert.ToBase62(61));
            Assert.Equal("10", Utils.Convert.ToBase62(62));
            Assert.Equal("11", Utils.Convert.ToBase62(63));
            Assert.Equal("zz", Utils.Convert.ToBase62(3843));
            Assert.Equal("100", Utils.Convert.ToBase62(3844));
            Assert.Equal("101", Utils.Convert.ToBase62(3845));
            Assert.Equal("1000", Utils.Convert.ToBase62(238328));
            Assert.Equal("10000", Utils.Convert.ToBase62(14776336));
            Assert.Equal("100000", Utils.Convert.ToBase62(916132832));
            Assert.Equal("1000000", Utils.Convert.ToBase62(56800235584));
            Assert.Equal("10000000", Utils.Convert.ToBase62(3521614606208));
            Assert.Equal("100000000", Utils.Convert.ToBase62(218340105584896));
            Assert.Equal("1000000000", Utils.Convert.ToBase62(13537086546263552));
            Assert.Equal("10000000000", Utils.Convert.ToBase62(839299365868340224));
        }
    }
}
